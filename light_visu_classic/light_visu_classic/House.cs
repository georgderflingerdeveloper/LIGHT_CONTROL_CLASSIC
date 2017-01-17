using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Communication.HAProtocoll;
using Communication.Server_;
using Communication.UDP;
using HAHardware;
using HomeAutomation.HardConfig;
using SystemServices;

namespace light_visu_classic
{
    public partial class MY_HOME_MAIN : Form, IDigitalIO
    {
        #region DECLARATIONS
        HEATING_SYSTEM      HeatingSystem    = new HEATING_SYSTEM( );
        Form_RoofGallery    RoofGallery      = new Form_RoofGallery( );
        Form_RoofRoomNorth  RoofRoomNorth    = new Form_RoofRoomNorth( );
        SleepingRoom        SleepingRoom_    = new SleepingRoom( );
        FormAnteRoom        Anteroom_        = new FormAnteRoom( );
        Form_AlarmSystem    AlarmSystem      = new Form_AlarmSystem( );
        Form_GroupControl   GroupControl     = new Form_GroupControl( );
        Form_Kitchen        Kitchen          = new Form_Kitchen( );
        Form_LivingRoomEast LivingRoomEast   = new Form_LivingRoomEast( );
        Form_LivingRoomWest LivingRoomWest   = new Form_LivingRoomWest( );
        Form_BathRoom       BathRoom         = new Form_BathRoom( );
        Form_Outside        Outside          = new Form_Outside( );
        Form_Networking     Networking       = new Form_Networking( );
        SERVICE             Service_;
        ServerQueue         Server;
        UdpSend             UDP_InviteClients;
        Timer               Timer_UDP_InviteClients;
        decimal             TransactionNumberSentTo_CENTER          = 0;
        decimal             TransactionNumberSentTo_LIVINGROOM_EAST = 0;
        //decimal             TransactionNumberSentTo_LIVINGROOM_WEST = 0;
        //decimal             TransactionNumberSentTo_SLEEPINGROOM    = 0;
        //decimal             TransactionNumberSentTo_ANTEROOM        = 0;

        public delegate void IO_MessageFromKitchenLivingRoom( object sender, IOState state );
        public event         IO_MessageFromKitchenLivingRoom IOMessageFromKitchenLivingRoom_;

        public delegate void SchedulerStatus( object sender, string device, string jobId, string Jobstatus );
        public event         SchedulerStatus ESchedulerStatus;
        #endregion

        #region CONSTRUCTOR
        public MY_HOME_MAIN()
        {
            InitializeComponent();
            Services.RunApplicationOnce();
            try
            {
                Server = new ServerQueue( IPConfiguration.Port.PORT_SERVER );
                Server.MessageReceivedFromClient += Server_MessageReceivedFromClient;
                Server.CLientHasDisconnected     += Server_CLientHasDisconnected;
                Server.CLientHasConnected        += Server_CLientHasConnected;
                Server.CLientHasReConnected      += Server_CLientHasReConnected;
                Server.EProtocollError_          += Server_EProtocollError_;
                Server.EFirstMessageUpdated      += Server_EFirstMessageUpdated;
                IOMessageFromKitchenLivingRoom_  += MY_HOME_MAIN_IOMessageFromKitchenLivingRoom_;
            }
            catch( Exception ex )
            {
                MessageBox.Show( InfoString.FailedToEstablishServer + ex.Message );
            }

            try
            {
                UDP_InviteClients  = new UdpSend( IPConfiguration.Address.IP_ADRESS_BROADCAST, IPConfiguration.Port.PORT_CLIENT_INVITE );
                UDP_InviteClients.SendString( InfoString.RequestForClientConnection );
            }
            catch( Exception ex )
            {
                MessageBox.Show( InfoString.FailedToEstablishUDPBroadcast + ex.Message );
            }

            Timer_UDP_InviteClients               = new Timer( );
            Timer_UDP_InviteClients.Interval      = Parameters.Intervall_ClientInvite;
            Timer_UDP_InviteClients.Tick         += Timer_UDP_InviteClients_Tick;
            Timer_UDP_InviteClients.Start( );

            HeatingSystem.EBoiler                += Heaters__EBoiler;
            HeatingSystem.EPrepareStartScheduler += ECentralControl_PrepareStartScheduler;
            HeatingSystem.Device_                += HeatingSystem_Device_;
            RoofGallery.Device_                  += RoofGallery_Device_;
            HeatingSystem.ESchedRequestStatus_   += HeatingSystem_ESchedRequestStatus_;
            this.ESchedulerStatus                += MY_HOME_MAIN_ESchedulerStatus;
        }
        #endregion

        #region SEND_COMANDOS_TO_CLIENTS

        #region HEATER_WARMWATER
        void HeatingSystem_Device_( object sender, string device, bool value )
        {
            TransactionNumberSentTo_CENTER++;
            string Comando = MessageBuilder.BuildIOSingleComandoMessage( ref TransactionNumberSentTo_CENTER, device, value );
            Server.SendMessageToClient( Comando, IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.CENTER_KITCHEN_AND_LIVING_ROOM );
        }

        // sends scheduled data ( times and days ) to clients
        void ECentralControl_PrepareStartScheduler( object sender, SchedulerControl_ e )
        {
            // the "device" itself is used as jobname, the full job is jobname + jobID
            string[] ContainsDevice = ( sender as Form ).Text.Split( MessageBuilder.Seperator );
            string Device = ContainsDevice[1]; 
            int i = 0;
            int PrevJobId = 0;
            if( (e.Day_Time != null) && (e.Day_Time.Count > 0) )
            {
                foreach( var times in e.Day_Time )
                {
                    // job list contains already the job ID
                    int ActualJobId = Convert.ToInt16( e.Day_Time[i].SchedulerJobID );
                    if( e.Day_Time[i].Comand == SComand.Start )
                    {
                        TransactionNumberSentTo_CENTER++;
                        string Comando = MessageBuilder.BuildSchedulerJobs(
                                           ref TransactionNumberSentTo_CENTER,
                                           Device,
                                           e.PrepareComandString( ActualJobId, SComand.Start ) ); // comando string is extracted from list
                        Server.SendMessageToClient( Comando, IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.CENTER_KITCHEN_AND_LIVING_ROOM );
                        PrevJobId = ActualJobId;
                    }
                    if( e.Day_Time[i].Comand == SComand.Stop )
                    {
                        TransactionNumberSentTo_CENTER++;
                        string Comando = MessageBuilder.BuildSchedulerJobs(
                                           ref TransactionNumberSentTo_CENTER,
                                           Device,
                                           e.PrepareComandString( ActualJobId, SComand.Stop ) ); // comando string is extracted from list
                        Server.SendMessageToClient( Comando, IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.CENTER_KITCHEN_AND_LIVING_ROOM );
                    }
                    i++;
                }
            }
        }

        void HeatingSystem_ESchedRequestStatus_( object sender, string jobId )
        {
            // the "device" itself is used as jobname, the full job is jobname + jobID
            string[] ContainsDevice = ( sender as Form ).Text.Split( MessageBuilder.Seperator );
            string Device = ContainsDevice[1];
            string Job = Device + MessageBuilder.Seperator + jobId;
            string Comando = MessageBuilder.GetCurrentSchedulerJobStatus( Job, TransactionNumberSentTo_CENTER++ );
            Server.SendMessageToClient( Comando, IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.CENTER_KITCHEN_AND_LIVING_ROOM );
        }

        void Boiler( bool value )
        {
            TransactionNumberSentTo_CENTER++;
            string Comando = MessageBuilder.BuildIOSingleComandoMessage( ref TransactionNumberSentTo_CENTER, HardwareDevices.Boiler, value );
            Server.SendMessageToClient( Comando, IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.CENTER_KITCHEN_AND_LIVING_ROOM );   
        }

        void Heaters__EBoiler( object o, bool value )
        {
            Boiler( value );
        }
        #endregion

        // gallery is controlled by living room east unit
        #region GALLERY   
        void RoofGallery_Device_( object sender, string device, bool value )
        {
            string Commando = "";
            TransactionNumberSentTo_LIVINGROOM_EAST++;
            switch( device )
            {
                case VirtualDevice.GroupGalleryFloor:
                     if( value == GeneralConstants.ON )
                     {
                         Commando = MessageBuilder.BuildComandoMessage( ref TransactionNumberSentTo_LIVINGROOM_EAST, Section.GalleryFloor, HomeAutomationCommandos.ALL_LIGHTS_ON );
                     }
                     else if( value == GeneralConstants.OFF )
                     {
                         Commando = MessageBuilder.BuildComandoMessage( ref TransactionNumberSentTo_LIVINGROOM_EAST, Section.GalleryFloor, HomeAutomationCommandos.ALL_LIGHTS_OFF );
                     }
                     break;
            }
            Server.SendMessageToClient( Commando, IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.LIVING_ROOM_EAST );
        }
        #endregion

        #endregion

        #region IOINTERFACE
        bool[] _DigitalInputState;
        bool[] _DigitalOutputState;
        public bool[] DigitalInputs
        {
            get
            {
                return _DigitalInputState;
            }
            set
            {
                _DigitalInputState = value;
            }
        }
        public bool[] DigitalOutputs
        {
            get
            {
                return _DigitalOutputState;
            }
            set
            {
                _DigitalOutputState = value;
            }
        }
        #endregion

        #region COMUNICATION_INITIATION_OBSERVATION
        void Server_EProtocollError_( string msg )
        {
            MessageBox.Show( msg, InfoString .ComunicationProtocollError );
        }

        void SendWhatsUpInquiryToClient( string WhichClient )
        {
            string command       = "";
            string askforversion = "";

            switch( WhichClient )
            {
                case IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.CENTER_KITCHEN_AND_LIVING_ROOM:
                     command = MessageBuilder.WhatsUpWithYourDigitalIOs( InfoOperationMode.CENTER_KITCHEN_AND_LIVING_ROOM );
                     askforversion = MessageBuilder.GetCurrentSoftwareVersion( InfoOperationMode.CENTER_KITCHEN_AND_LIVING_ROOM );
                     Server.SendMessageToClient( command, WhichClient );
                     Server.SendMessageToClient( askforversion, WhichClient );
                     break;
                case IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.LIVING_ROOM_EAST:
                     command = MessageBuilder.WhatsUpWithYourDigitalIOs( InfoOperationMode.LIVING_ROOM_EAST );
                     askforversion = MessageBuilder.GetCurrentSoftwareVersion( InfoOperationMode.LIVING_ROOM_EAST );
                     Server.SendMessageToClient( command, WhichClient );
                     Server.SendMessageToClient( askforversion, WhichClient );
                     break;
                case IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.ANTEROOM:
                     command = MessageBuilder.WhatsUpWithYourDigitalIOs( InfoOperationMode.ANTEROOM );
                     askforversion = MessageBuilder.GetCurrentSoftwareVersion( InfoOperationMode.ANTEROOM );
                     Server.SendMessageToClient( command, WhichClient );
                     Server.SendMessageToClient( askforversion, WhichClient );
                     break;
                default:
                     return;
            }
        }

        // when server received first message its sending a "whatsup inquiry" back to the client
        void Server_EFirstMessageUpdated( string clientid )
        {
            SendWhatsUpInquiryToClient( clientid );
        }
 
        void Server_CLientHasReConnected( string GivenName )
        {
            AppendTextBox( TimeUtil.GetTimestamp() + " " + "Client " + GivenName + " has reconnected with server: " );

            switch( GivenName )
            {
                case IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.CENTER_KITCHEN_AND_LIVING_ROOM:
                     HeatingSystem.BackColor = Color.LightGoldenrodYellow;
                     break;
                case IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.LIVING_ROOM_EAST:
                     RoofGallery.BackColor =  Color.LightGoldenrodYellow;
                     break;
            }
        }

        void Server_CLientHasConnected( KeyValuePair<string, string> WhichClient )
        {
            AppendTextBox( TimeUtil.GetTimestamp( ) + " "     +
                           "Client has connected to server: " + 
                           WhichClient.Key                    +
                           WhichClient.Value
                         );
            switch( WhichClient.Key )
            {
                case IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.CENTER_KITCHEN_AND_LIVING_ROOM:
                     HeatingSystem.BackColor = Color.LightGoldenrodYellow;
                     break;
                case IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.LIVING_ROOM_EAST:
                     RoofGallery.BackColor =  Color.LightGoldenrodYellow;
                     break;
            }
        }

        void Server_CLientHasDisconnected( KeyValuePair<string, string> WhichClient )
        {
            AppendTextBox( TimeUtil.GetTimestamp( ) + " "          +
                           "Client has disconnected from server: " + 
                           WhichClient.Key                         +
                           WhichClient.Value
                         );
            switch( WhichClient.Key )
            {
                case IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.CENTER_KITCHEN_AND_LIVING_ROOM:
                     HeatingSystem.BackColor = Color.Gray;
                     break;
                case IPConfiguration.Prefix.TCPCLIENT + InfoOperationMode.LIVING_ROOM_EAST:
                     RoofGallery.BackColor =  Color.Gray;
                     break;
            }
        }

        void Timer_UDP_InviteClients_Tick( object sender, EventArgs e )
        {
            if( UDP_InviteClients == null )
            {
                return;
            }
            UDP_InviteClients.SendString( InfoString.RequestForClientConnection );
        }

        void Server_MessageReceivedFromClient( string receivedmessage )
        {
            // thread save
            AppendTextBox( receivedmessage + EscapeSequences.CRLF );
            AppendMessage( receivedmessage );
        }

       #endregion

        #region RECEIVED_ANALYZED_DATA
        void MY_HOME_MAIN_IOMessageFromKitchenLivingRoom_( object sender, IOState state )
        {
            if( HeatingSystem != null )
            {
                try
                {
                    if( state.IsIOState )
                    {
                        HeatingSystem.DigitalInputs  = state.DigitalInputs;
                        HeatingSystem.DigitalOutputs = state.DigitalOutputs;
                    }

                    if( state.IsIOSingle )
                    {
                        if( state.IsInput )
                        {
                            HeatingSystem.SingleInputIndex = state.SingleInputIndex;
                            HeatingSystem.SingleInputValue = state.SingleInputValue;
                        }
                        if( state.IsOutput )
                        {
                            HeatingSystem.SingleOutputIndex = state.SingleOutputIndex;
                            HeatingSystem.SingleOutputValue = state.SingleOutputValue;
                        }
                    }
                }
                catch( Exception ex )
                {
                    MessageBox.Show( InfoString.ComunicationProtocollError + ex.Message );
                }
            }
        }
        #endregion

        #region EVENTHANDLERS_MAIN_BUTTONS
        private void bAnteRoom_Click(object sender, EventArgs e)
        {
            Form fAnteroom_ = Anteroom_ as Form;
            FormControl.ShowAligned( ref fAnteroom_, Rooms.NamesGerman.Anteroom );
        }

        private void bSleepingRoom_Click(object sender, EventArgs e)
        {
            Form fSleepingRoom_ = SleepingRoom_ as Form;
            FormControl.ShowAligned( ref fSleepingRoom_, Rooms.NamesGerman.SleepingRoom );
        }

        private void bBathRoom_Click( object sender, EventArgs e )
        {
            Form fBathRoom = BathRoom as Form;
            FormControl.ShowAligned( ref fBathRoom, Rooms.NamesGerman.BathRoom );
        }

        private void bNetwork_Click( object sender, EventArgs e )
        {
            Form fNetworking = Networking as Form;
            FormControl.ShowAligned( ref fNetworking, Rooms.NamesGerman.Networking );
        }

        private void bAlarm_Click( object sender, EventArgs e )
        {
            Form fAlarmSystem = AlarmSystem as Form;
            FormControl.ShowAligned( ref fAlarmSystem, Rooms.NamesGerman.AlarmSystem );
        }

        private void bHeaterWarmWater_Click( object sender, EventArgs e )
        {
            Form fHeater = HeatingSystem as Form;
            FormControl.ShowAligned( ref fHeater, Rooms.NamesGerman.Heaters );
        }

        private void bKitchen_Click( object sender, EventArgs e )
        {
            Form fKitchen = Kitchen as Form;
            FormControl.ShowAligned( ref fKitchen, Rooms.NamesGerman.Kitchen );
        }

        private void bRoofNorth_Click( object sender, EventArgs e )
        {
            Form fRoofRoomNorth = RoofRoomNorth as Form;
            FormControl.ShowAligned( ref fRoofRoomNorth, Rooms.NamesGerman.RoofRoomNorth );
        }

        private void bLivingRoomEast_Click( object sender, EventArgs e )
        {
            Form fLivingRoomEast = LivingRoomEast as Form;
            FormControl.ShowAligned( ref fLivingRoomEast, Rooms.NamesGerman.LivingRoomEast );
        }

        private void bLivingRoomWest_Click( object sender, EventArgs e )
        {
            Form fLivingRoomWest = LivingRoomWest as Form;
            FormControl.ShowAligned( ref fLivingRoomWest, Rooms.NamesGerman.LivingRoomWest );
        }

        private void bGallerie_Click( object sender, EventArgs e )
        {
            Form fRoofGallery = RoofGallery as Form;
            FormControl.ShowAligned( ref fRoofGallery, Rooms.NamesGerman.RoofGallery );
        }

        private void bOutside_Click( object sender, EventArgs e )
        {
            Form fOutside = Outside as Form;
            FormControl.ShowAligned( ref fOutside, Rooms.NamesGerman.Outside );
        }

        private void bGroupControl_Click( object sender, EventArgs e )
        {
            Form fGroupControl = GroupControl as Form;
            FormControl.ShowAligned( ref fGroupControl, Rooms.NamesGerman.GroupControl );
        }
 
        private void House_CLosed( object sender, FormClosedEventArgs e )
        {
            Server.Abort( );
            Environment.Exit( 0 );
        }
        
        private void bService_Click( object sender, EventArgs e )
        {
            Service_ = new SERVICE( );
            Service_.Show( );
            if( Server.MessageQueue.Count > 0 )
            {
                for( int i = Server.MessageQueue.Count; i >= 1; i-- )
                {
                   Service_.MessageText = Server.MessageQueue.Dequeue( );
                }
            }
        }

        private void bInfo_Click( object sender, EventArgs e )
        {
            String Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            MessageBox.Show( "Version: " + Version + " " + "Date last build: " + BuildInformation.BuildDate.ToString(), "Version Information" );
        }
        #endregion

        #region EVENT_HANDLERS
        void MY_HOME_MAIN_ESchedulerStatus( object sender, string device, string jobId, string Jobstatus )
        {
            if( HeatingSystem != null )
            {
                HeatingSystem.ActualJobStatus   = Jobstatus;
                HeatingSystem.ActualJobStatusID = jobId;
            }
        }
        #endregion

        #region SERVICE_INFORMATION

        public void AppendTextBox( string value )
        {
            if( Service_ != null )
            {
                if( InvokeRequired )
                {
                    this.Invoke( new Action<string>( AppendTextBox ), new object[] { value } );
                    return;
                }
                Service_.MessageText += value;
            }
        }

        public void AppendMessage( string value )
        {
            if( InvokeRequired )
            {
                this.Invoke( new Action<string>( AppendMessage ), new object[] { value } );
                return;
            }

            string[] receivedmessageparts = receivedmessageparts = value.Split( Seperators.delimiterChars );

            // ANALYZING SCHEDULERSTATUS
            // Example:
            // 0143 000000005 01062015:14h20m37s069ms NB-PRG02 answers: CENTER_KITCHEN_LIVING_ROOM_ANSWEROF_ASKFORSCHEDULERSTATUSJOB_Boiler_1_JobNotFound
            if( value.Contains( HomeAutomationAnswers.ANSWER_SCHEDULER_STATUS ) )
            {
                string Device, JobId, JobStatus = "";
                const int IndJobId     = 1;
                const int IndJobStatus = 2;
                string keyword = MessageTyp.ASK_SCHEDULER_JOB_STATUS;
                Device    = MessageAnalyzer.GetMessagePartAfterKeyWord( value, keyword );
                JobId     = MessageAnalyzer.GetMessagePartAfterKeyWord( value, keyword, IndJobId );
                JobStatus = MessageAnalyzer.GetMessagePartAfterKeyWord( value, keyword, IndJobStatus );
                if( ESchedulerStatus != null )
                {
                    ESchedulerStatus( this, Device, JobId, JobStatus ); 
                }
            }
            // ANALYZING IO STATUS
            if( MessageAnalyzer.ExpectedQuickAnswerMessageIndex.Room < receivedmessageparts.Length )
            {
                switch( receivedmessageparts [MessageAnalyzer.ExpectedQuickAnswerMessageIndex.Room] )
                {
                    case InfoOperationMode.CENTER_KITCHEN_AND_LIVING_ROOM:
                        // which message type did we get ?
                        switch( receivedmessageparts [MessageAnalyzer.ExpectedQuickAnswerMessageIndex.IndMessageTyp] )
                        {
                            case MessageTyp.IO_QUICKSTATE_PRIMER:
                            case MessageTyp.IO_SINGLE_INPUT_STATUS:
                            case MessageTyp.IO_SINGLE_OUTPUT_STATUS:
                                // fire event which contains IO status information
                                if( IOMessageFromKitchenLivingRoom_ != null )
                                {
                                    IOState state = MessageAnalyzer.GetIOStateInquiryAnswer( value );
                                    IOMessageFromKitchenLivingRoom_( this, state );
                                }
                                break;
                        }
                        break;
                }
            }
        }
        #endregion
    }

    #region FORM_CONTROL
    static class FormControl
    {
        public static void ShowAligned( ref Form form_, string title )
        {
            if( form_ != null )
            {
                form_.Size = new Size( HardConfig.RoomWindow.Witdh, HardConfig.RoomWindow.Height );
                form_.MaximumSize = form_.Size;
                form_.Text = title;
                form_.ShowDialog();
            }
        }
    }
    #endregion
}
