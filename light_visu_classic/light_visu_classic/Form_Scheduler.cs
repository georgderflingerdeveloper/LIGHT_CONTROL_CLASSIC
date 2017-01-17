using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scheduler;
using System.IO;
using System.Xml.Serialization;
using Communication.HAProtocoll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeAutomation.HardConfig;


namespace light_visu_classic
{
    public partial class Form_Scheduler : Form
    {
        #region DECLARATIONS
        SchedulerControl SControl  = new SchedulerControl();
        // used for apply as eventargument
        SchedulerControl_ ArgumentSchedulerControl = new SchedulerControl_();
        
        List<CheckBox> CheckBoxes = new List<CheckBox>();

        Dictionary<string, int> DaysDic = new Dictionary<string,int>
        { 
                { TimeConstants.Monday,    1},
                { TimeConstants.Tuesday,   2},
                { TimeConstants.Wednesday, 3},
                { TimeConstants.Thursday,  4},
                { TimeConstants.Friday,    5},
                { TimeConstants.Saturday,  6},
                { TimeConstants.Sunday,    7},
                { TimeConstants.Daily,     8},
        };
        int NextElement            = 0;
        int sc_index               = 0;
        int PrevElement            = 0;
        const int NumericElements  = 3;
        int InhibitNumericCnt;  // prevents undesired update
        List<DayTime> _StoredDays_Times;
        Dictionary<int,string> SelectedDaysDic = new Dictionary<int, string>();
        List<string> OrderedDaysList           = new List<string>();
        bool LoadedOnce = false;
        string _ActualJobStatus   = "";
        int    _ActualJobStatusID =  0;
        #endregion

        #region CONSTANTS
        const int    MaxNumberOfTimes              = 6;
        const int    FirstListElement              = 1;
        const int    SecondListElement             = 2;
        const int    NoListElementsAvailable       = 0;
        const char   daysSeperator                = ',';
        const string StoredDataExtension          = ".xml";
        const string TextStartTime                = "StartTime";
        const string TextStopTime                 = "StopTime";
        #endregion

        #region EVENT_DECLARATIONS
        public delegate void              SchedControl( object sender, SchedulerControl_ e );
        public event                      SchedControl ESchedControl;

        public delegate void              SchedRequestStatus( object sender, string jobId );
        public event                      SchedRequestStatus ESchedRequestStatus;

        delegate void                     ListIsEmpty();
        event                             ListIsEmpty EListIsEmpty;

        delegate void                     ListContainsData( int count );
        event                             ListContainsData EListContainsData;

        delegate void                     NumericControlUpdated( int hour, int min, int sec );
        event                             NumericControlUpdated ENumericControlUpdated;

        delegate void                     IsStopTime_( bool info );
        event                             IsStopTime_ EIsStopTime_;
        #endregion

        #region CONSTRUCTOR
        public Form_Scheduler( string title )
        {
            InitializeComponent( );

            this.Text = title;

            CheckBoxes.Add( cbMon );
            CheckBoxes.Add( cbTue );
            CheckBoxes.Add( cbWed );
            CheckBoxes.Add( cbThu );
            CheckBoxes.Add( cbFr );
            CheckBoxes.Add( cbSat );
            CheckBoxes.Add( cbSun );
            CheckBoxes.Add( cbDaily );

            cbDaily.Name  = TimeConstants.Daily;
            cbMon.Name    = TimeConstants.Monday;
            cbTue.Name    = TimeConstants.Tuesday;
            cbWed.Name    = TimeConstants.Wednesday;
            cbThu.Name    = TimeConstants.Thursday;
            cbFr.Name     = TimeConstants.Friday;
            cbSat.Name    = TimeConstants.Saturday;
            cbSun.Name    = TimeConstants.Sunday;

            SchedulerControl.Day_Time = ReadData();

            sc_index = 0;
            bStartScheduler.Enabled = false;
            bStopScheduler.Enabled  = false;

            if( SchedulerControl.Day_Time == null )
            {
                SchedulerControl.Day_Time = new List<DayTime>();
                SchedulerControl.Day_Time.Add( new DayTime() );
                SchedulerControl.Day_Time[sc_index].Number         = SchedulerControl.Day_Time.Count;
                SchedulerControl.Day_Time[sc_index].Comand         = SComand.Idle;
                SchedulerControl.Day_Time[sc_index].Days           = SComand.FromNow;
                SchedulerControl.Day_Time[sc_index].SchedulerJobID = FindJobId( 1 );
                bPreviousScheduleJob.Enabled = false;
                bNextScheduleJob.Enabled     = false;
            }

            if( SchedulerControl.Day_Time != null )
            {
                if( SchedulerControl.Day_Time.Count > 0 )
                {
                    UpdateNumericControl( SchedulerControl.Day_Time[sc_index].Hour,
                                          SchedulerControl.Day_Time[sc_index].Minute,
                                          SchedulerControl.Day_Time[sc_index].Second );

                    PreCheckBoxesFromStoredData( SchedulerControl.Day_Time[sc_index].Days, ref CheckBoxes );
                    TextStartStopTime();
                    if( (SchedulerControl.Day_Time[sc_index].Days != null) && (SchedulerControl.Day_Time[sc_index].Days.Contains(TimeConstants.Daily)) )
                    {
                        EnableAllCheckBoxes( ref CheckBoxes, false );
                    }

                }
            }
            EListIsEmpty                +=  Form_Scheduler_EListIsEmpty;
            EListContainsData           +=  Form_Scheduler_EListContainsData;
            ENumericControlUpdated      +=  Form_Scheduler_ENumericControlUpdated;
            EIsStopTime_                +=  Form_Scheduler_EIsStopTime_;

            this.bNextScheduleJob.Click     += new System.EventHandler( this.EbNavigation_Click );
            this.bPreviousScheduleJob.Click += new System.EventHandler( this.EbNavigation_Click );

            CheckForStartStoptime();

            pictureBoxShowSchedulerStatus.Image = Properties.Resources.clock_active;
            pictureBoxShowSchedulerStatus.Enabled = false;
        }
        #endregion

        #region PROPERTIES
        // additional information about stored time data
        public List<DayTime> StoredDays_Times
        {
            get
            {
                return _StoredDays_Times;
            }
        }

        public string ActualJobStatus
        {
            set
            {
                _ActualJobStatus = value;
                if( _ActualJobStatus == SchedulerInfo.Status.Started.ToString() )
                {
                    pictureBoxShowSchedulerStatus.Enabled = true;                    
                }
                else
                {
                    pictureBoxShowSchedulerStatus.Enabled = false;
                }
            }
        }

        public string ActualJobStatusID
        {
            set
            {
                _ActualJobStatusID = Convert.ToInt32( value );
            }
        }
        #endregion

        #region PRIVATE_METHODS
        // 1,2 => 1, 2,3 => 2, 3,4 => 3 aso...
        string FindJobId( int value )
        {
            int result = 0;

            if( value > 1 )
            {
                result =  ( value % 2 == 0 ) ? ( value / 2 ) : ( value / 2 ) + 1;
            }
            else if( value == 1 )
            {
                result = value;
            }

            return ( result.ToString() );
        }
        // for some cases the index is usefull
        void CheckForStartStoptime( )
        {
            if( ( SchedulerControl.Day_Time == null ) || ( SchedulerControl.Day_Time.Count == 0 ) || (sc_index < 0) || ( sc_index >= SchedulerControl.Day_Time.Count ) )
            {
                return;
            }

            if( sc_index % 2 != 0 )
            {
                SchedulerControl.Day_Time[sc_index].IsStopTime = true;
                if( EIsStopTime_ != null )
                {
                    EIsStopTime_( true );
                }
            }
            else
            {
                SchedulerControl.Day_Time[sc_index].IsStopTime = false;
                if( EIsStopTime_ != null )
                {
                    EIsStopTime_( false );
                }
            }
        }

        void Form_Scheduler_ENumericControlUpdated( int hour ,int min, int sec )
        {
             lbTime.Text = MyCroneConverter.TimeToString( hour, min, sec );
        }

        void EnableCheckboxes( bool en )
        {   
            int cnt = 0; 
            foreach( var elements in CheckBoxes )
            {
                CheckBoxes[cnt++].Enabled = en;
            }
        }

        void DisablePrevNextButtons(  )
        {
             bPreviousScheduleJob.Enabled = false;
             bNextScheduleJob.Enabled     = false;
        }

        void EnableControls( bool en )
        {
            bRemoveScheduleJob.Enabled             = en;
            bStartScheduler.Enabled                = en;
            numericUpDownHourSelector.Enabled      = en;
            numericUpDownMinuteSelector.Enabled    = en;
            numericUpDownSecondSelector.Enabled    = en;
        }

        void Form_Scheduler_EIsStopTime_( bool info )
        {
            bStartScheduler.Enabled = info ? true : false;
            bStopScheduler.Enabled = bStartScheduler.Enabled;
        }

        void UpdateNumericControl( int hour, int minute, int second )
        {
            numericUpDownHourSelector.Value   = hour;
            numericUpDownMinuteSelector.Value = minute;
            numericUpDownSecondSelector.Value = second;
            if( ENumericControlUpdated != null )
            {
                ENumericControlUpdated(  hour, minute, second );
            }
        }

        void PresetNumericControl( int value )
        {
            numericUpDownHourSelector.Value   = value;
            numericUpDownMinuteSelector.Value = value;
            numericUpDownSecondSelector.Value = value;
            if( ENumericControlUpdated != null )
            {
                ENumericControlUpdated( value ,value, value  );
            }
        }

        void TextStartStopTime()
        {
            if( sc_index >= 0 && sc_index < SchedulerControl.Day_Time.Count )
            {
                lbStartStop.Text = SchedulerControl.Day_Time[sc_index].IsStopTime ? TextStopTime : TextStartTime;
                SchedulerControl.Day_Time[sc_index].WhichComandedTime = lbStartStop.Text;
            }
        }

        private void SetTime( object sender, EventArgs e )
        {
            // actualise only once when navigate
            if( InhibitNumericCnt > 0  )
            {
                InhibitNumericCnt--;
                return;
            }

            if( (SchedulerControl.Day_Time != null) && (SchedulerControl.Day_Time.Count > 0) )
            {
                switch( ( sender as NumericUpDown ).Name )
                {
                    case "numericUpDownHourSelector":
                          SchedulerControl.Day_Time[sc_index].Hour = Convert.ToInt16( numericUpDownHourSelector.Value );
                          break;

                    case "numericUpDownMinuteSelector":
                          SchedulerControl.Day_Time[sc_index].Minute = Convert.ToInt16( numericUpDownMinuteSelector.Value );
                          break;

                    case "numericUpDownSecondSelector":
                          SchedulerControl.Day_Time[sc_index].Second = Convert.ToInt16( numericUpDownSecondSelector.Value );
                          break;
                }
                SchedulerControl.Day_Time[sc_index].Time = MyCroneConverter.TimeToString( SchedulerControl.Day_Time[sc_index].Hour,
                                                                                          SchedulerControl.Day_Time[sc_index].Minute, 
                                                                                          SchedulerControl.Day_Time[sc_index].Second );
                lbTime.Text = SchedulerControl.Day_Time[sc_index].Time;
            }
         }

        private List<DayTime> ReadData()
        {
           try
           {
               XmlSerializer ser = new XmlSerializer( typeof( List<DayTime> ) );
               string currentDir = Environment.CurrentDirectory;
               StreamReader sr = new StreamReader( @currentDir + "\\" + this.Text + StoredDataExtension );                              // @"c:\"
               List<DayTime> DayTime_ = ( List<DayTime> ) ser.Deserialize( sr );
               sr.Close();
               _StoredDays_Times = DayTime_;
               return DayTime_;
           }
           catch( Exception ex )
           {
               MessageBox.Show( ex.Message, "Data read error" );
               return null;
           }
        }

        private void SaveData( )
        {
           try
           {
               XmlSerializer ser = new XmlSerializer( typeof( List<DayTime> ) );
               string currentDir = Environment.CurrentDirectory;
               FileStream str = new FileStream( @currentDir + "\\" + this.Text + StoredDataExtension, FileMode.Create );
               ser.Serialize( str, SchedulerControl.Day_Time );
               str.Close();
           }
           catch( Exception ex )
           {
               MessageBox.Show( ex.Message, "Data save error" );
           }
        }

        void EnableAllCheckBoxes( ref List<CheckBox> checkboxes, bool value )
        {
            int i = 0;
            foreach( CheckBox box in checkboxes )
            {
                if( value )
                {
                    checkboxes[i].Enabled = true;
                }
                else
                {
                    if( checkboxes[i].Name != TimeConstants.Daily )
                    {
                        checkboxes[i].Enabled = false;
                    }
                }
                i++;
            }
        }

        // shows selected data as checked
        void PreCheckBoxesFromStoredData( string days, ref List<CheckBox> checkboxes )
        {
            int i = 0;
            foreach( CheckBox box in checkboxes )
            {
                if( days != null )
                {
                    if( days.Contains( checkboxes[i].Name ) )
                    {
                        checkboxes[i].Checked = true;
                    }
                    else
                    {
                        checkboxes[i].Checked = false;
                    }
                }
                else
                {
                    checkboxes[i].Checked = false;
                }
                i++;
            }
        }

        // converts a string in list into a crone understandble string
        // example:
        // Mon
        // Tue
        // Wed
        // ..
        // days = Mon,Tue,Wed
        string DayListToCronDays( ref List<string> DayList )
        {
            string days = "";
            int i = 0;

            foreach( var elements in DayList )
            {
                days += DayList[i];
                if( ( i < ( DayList.Count - 1 ) ) && ( DayList.Count > 0 ) )
                {
                    days += daysSeperator;
                }
                i++;
            }
            return ( days );
        }
        #endregion

        #region EVENT_HANDLERS

        void Form_Scheduler_EListContainsData( int count )
        {
            if( count >= FirstListElement )
            {
                 bNextScheduleJob.Enabled          = true;
                 EnableControls( true );
                 EnableCheckboxes( true );
            }
            if( count >= SecondListElement )
            {
                bPreviousScheduleJob.Enabled = true;
            }
            if( count == FirstListElement )
            {
                bPreviousScheduleJob.Enabled = false;
            }
        }

        void Form_Scheduler_EListIsEmpty()
        {
            EnableControls( false );
            DisablePrevNextButtons();
            EnableCheckboxes( false );
        }
                             
        private void bStartScheduler_Click( object sender, EventArgs e )
        {
            if( SchedulerControl.Day_Time.Count > NoListElementsAvailable )
            {
                if( (ESchedControl != null) && (SControl != null)  )
                {
                    if( SchedulerControl.Day_Time != null && SchedulerControl.Day_Time.Count > 0 )
                    {
                        SchedulerControl.Day_Time[sc_index].Comand = SComand.Start;
                        ArgumentSchedulerControl.Day_Time = SchedulerControl.Day_Time;
                        ESchedControl( this, ArgumentSchedulerControl );
                        pictureBoxShowSchedulerStatus.Enabled = true;
                    }
                }
            }
        }

        private void bStopScheduler_Click( object sender, EventArgs e )
        {
            if( SchedulerControl.Day_Time.Count > NoListElementsAvailable )
            {
                if( ( ESchedControl != null ) && ( SControl != null ) )
                {
                    if( SchedulerControl.Day_Time != null && SchedulerControl.Day_Time.Count > 0 )
                    {
                        SchedulerControl.Day_Time[sc_index].Comand = SComand.Stop;
                        ArgumentSchedulerControl.Day_Time = SchedulerControl.Day_Time;
                        ESchedControl( this, ArgumentSchedulerControl );
                        pictureBoxShowSchedulerStatus.Enabled = false;
                    }
                }
            }
        }

        private void bAddScheduleJob_Click( object sender, EventArgs e )
        {
            InhibitNumericCnt = 0;
            if( SchedulerControl.Day_Time.Count < MaxNumberOfTimes )
            {
                SchedulerControl.Day_Time.Add( new DayTime() );
                if( SchedulerControl.Day_Time.Count > FirstListElement )
                {
                    sc_index++;
                }
                if( sc_index >= 0 )
                {
                    SchedulerControl.Day_Time[sc_index].Number = SchedulerControl.Day_Time.Count;
                    SchedulerControl.Day_Time[sc_index].Comand = SComand.Idle;
                    SchedulerControl.Day_Time[sc_index].Time   = SComand.DefaultTime;
                    SchedulerControl.Day_Time[sc_index].Days   = "";
                    SchedulerControl.Day_Time[sc_index].SchedulerJobID = FindJobId( SchedulerControl.Day_Time.Count );
                }
                PrevElement = sc_index;
                NextElement = sc_index;
                PresetNumericControl( 0 );
                lbNumber.Text = SchedulerControl.Day_Time.Count.ToString();
                TextStartStopTime();
                if( EListContainsData != null )
                {
                    EListContainsData( SchedulerControl.Day_Time.Count ); 
                }
            }
            else
            {
                MessageBox.Show( Properties.Resources.SchedulerMessage_LimitReached + " " + MaxNumberOfTimes.ToString() );
            }
            if( SchedulerControl.Day_Time.Count == FirstListElement )
            {
                DisablePrevNextButtons();
            }
            PreCheckBoxesFromStoredData( SchedulerControl.Day_Time[sc_index].Days, ref CheckBoxes );
            pictureBoxShowSchedulerStatus.Enabled = false;
            if( String.IsNullOrEmpty( SchedulerControl.Day_Time[sc_index].Time ) )
            {
                String.IsNullOrEmpty( SchedulerControl.Day_Time[sc_index].Time = SComand.DefaultTime );
            }
        }

        private void bRemoveScheduleJob_Click( object sender, EventArgs e )
        {
            if( SchedulerControl.Day_Time != null && SchedulerControl.Day_Time.Count > 0 )
            {
                if( (sc_index >= 0) && (sc_index < MaxNumberOfTimes) )
                {
                    SchedulerControl.Day_Time.Remove( SchedulerControl.Day_Time[sc_index] );
                }
                if( sc_index >= 1 )
                {
                    sc_index--;
                    PrevElement = sc_index;
                    UpdateNumericControl( SchedulerControl.Day_Time[sc_index].Hour,
                                          SchedulerControl.Day_Time[sc_index].Minute,
                                          SchedulerControl.Day_Time[sc_index].Second );
                SchedulerControl.Day_Time[sc_index].SchedulerJobID = FindJobId( SchedulerControl.Day_Time.Count ); 
                }
                lbNumber.Text = SchedulerControl.Day_Time.Count.ToString();
                TextStartStopTime();
            }

            if( SchedulerControl.Day_Time.Count == NoListElementsAvailable )
            {
                if( EListIsEmpty != null )
                {
                    EListIsEmpty();
                }
                PresetNumericControl( 0 );
            }

            if( SchedulerControl.Day_Time.Count == FirstListElement )
            {
                DisablePrevNextButtons();
            }

            if( (sc_index > 0) && (SchedulerControl.Day_Time.Count > 0) )
            {
                PreCheckBoxesFromStoredData( SchedulerControl.Day_Time[sc_index].Days, ref CheckBoxes );
            }
        }

        private void bPreviousScheduleJob_Click( object sender, EventArgs e )
        {
            InhibitNumericCnt = NumericElements;
            if( PrevElement >= 1 && (PrevElement < SchedulerControl.Day_Time.Count) )
            {
                PrevElement--;
                int nexthour   = SchedulerControl.Day_Time[PrevElement].Hour;
                int nextminute = SchedulerControl.Day_Time[PrevElement].Minute;
                int nextsecond = SchedulerControl.Day_Time[PrevElement].Second;
                UpdateNumericControl( nexthour, nextminute, nextsecond );
                lbNumber.Text = ( PrevElement + 1 ).ToString();
                NextElement = PrevElement;
            }
            sc_index = PrevElement;
            if( ( sc_index >= 0 ) && ( SchedulerControl.Day_Time.Count > 0 ) && (sc_index < SchedulerControl.Day_Time.Count) )
            {
                PreCheckBoxesFromStoredData( SchedulerControl.Day_Time[sc_index].Days, ref CheckBoxes );
            }
            TextStartStopTime();
            pictureBoxShowSchedulerStatus.Enabled = false;
        }

        private void bNextScheduleJob_Click( object sender, EventArgs e )
        {
            InhibitNumericCnt = NumericElements;
            NextElement++;
            if( NextElement < SchedulerControl.Day_Time.Count )
            {
                int nexthour   = SchedulerControl.Day_Time[NextElement].Hour;
                int nextminute = SchedulerControl.Day_Time[NextElement].Minute;
                int nextsecond = SchedulerControl.Day_Time[NextElement].Second;
                UpdateNumericControl( nexthour, nextminute, nextsecond );
                lbNumber.Text = ( NextElement + 1 ).ToString();
                PrevElement = NextElement;
            }
            else
            {
                NextElement = SchedulerControl.Day_Time.Count - 1;
            }
            sc_index = NextElement;
            if( ( sc_index >= 0 ) && ( SchedulerControl.Day_Time.Count > 0 ) )
            {
                PreCheckBoxesFromStoredData( SchedulerControl.Day_Time[sc_index].Days, ref CheckBoxes );
            }
            TextStartStopTime();
            pictureBoxShowSchedulerStatus.Enabled = false;
            if( String.IsNullOrEmpty( SchedulerControl.Day_Time[sc_index].Time ) )
            {
                String.IsNullOrEmpty( SchedulerControl.Day_Time[sc_index].Time = SComand.DefaultTime );
            }
        }

        // common event handler for navigation button click ( previous, next )
        private void EbNavigation_Click( object sender, EventArgs e )
        {
            CheckForStartStoptime();
        }

        private void ShapeMouseEnter( object sender, EventArgs e )
        {
            InhibitNumericCnt = 0;
        }

        private void SchedClosed( object sender, FormClosedEventArgs e )
        {
           if( SchedulerControl.Day_Time != null )
           {
               SaveData();
           }
        }

        private void EDaysChanged( object sender, EventArgs e )
        {
           int key = 0;
           CheckBox ChangedCheckBox = sender as CheckBox;
           if( ChangedCheckBox.Checked )
           {
                DaysDic.TryGetValue( ChangedCheckBox.Name, out key );
                SelectedDaysDic.Add( key, ChangedCheckBox.Name );
                if( ChangedCheckBox.Name == TimeConstants.Daily )
                {
                    EnableAllCheckBoxes( ref CheckBoxes, false );
                }
           }
           else
           {
                DaysDic.TryGetValue( ChangedCheckBox.Name, out key );
                if( ChangedCheckBox.Name == TimeConstants.Daily )
                {
                    EnableAllCheckBoxes( ref CheckBoxes, true );
                }
                SelectedDaysDic.Remove( key );
           }

           var items = from pair in SelectedDaysDic orderby pair.Key ascending select pair;

           foreach( var item in items )
           {
              OrderedDaysList.Add( item.Value );
           }

           if( ChangedCheckBox.Checked )
           {
               // daily is selected - use all days
               if( ChangedCheckBox.Name == TimeConstants.Daily )
               {
                   SchedulerControl.Day_Time[sc_index].Days = null;
                   SchedulerControl.Day_Time[sc_index].Days += TimeConstants.Monday;
                   SchedulerControl.Day_Time[sc_index].Days += daysSeperator;
                   SchedulerControl.Day_Time[sc_index].Days += TimeConstants.Tuesday;
                   SchedulerControl.Day_Time[sc_index].Days += daysSeperator;
                   SchedulerControl.Day_Time[sc_index].Days += TimeConstants.Wednesday;
                   SchedulerControl.Day_Time[sc_index].Days += daysSeperator;
                   SchedulerControl.Day_Time[sc_index].Days += TimeConstants.Thursday;
                   SchedulerControl.Day_Time[sc_index].Days += daysSeperator;
                   SchedulerControl.Day_Time[sc_index].Days += TimeConstants.Friday;
                   SchedulerControl.Day_Time[sc_index].Days += daysSeperator;
                   SchedulerControl.Day_Time[sc_index].Days += TimeConstants.Saturday;
                   SchedulerControl.Day_Time[sc_index].Days += daysSeperator;
                   SchedulerControl.Day_Time[sc_index].Days += TimeConstants.Sunday;
                   OrderedDaysList.Clear();
                   return;
               }
           }

           // selected days only
           SchedulerControl.Day_Time[sc_index].Days = DayListToCronDays( ref OrderedDaysList );
           OrderedDaysList.Clear();
        }

        // detects when the form object is complete loaded
        protected override void OnLoad( EventArgs args )
        {
            Application.Idle += new EventHandler( OnLoaded );
        }

        private void OnLoaded( object sender, EventArgs e )
        {
            if( ESchedRequestStatus != null )
            {
                if( !LoadedOnce )
                {
                    ESchedRequestStatus( this, SchedulerControl.Day_Time[sc_index].SchedulerJobID );
                    LoadedOnce = true;
                }
            }
            if( String.IsNullOrEmpty( SchedulerControl.Day_Time[0].Time ) )
            {
                String.IsNullOrEmpty( SchedulerControl.Day_Time[0].Time = SComand.DefaultTime );
            }
        }        
        #endregion
   }

    #region UNITTEST_SCHEDULER
    [TestClass]
    public class UnitTestScheduler
    {
        [TestMethod]
        public void SchedulerStringComands()
        {
            Form_Scheduler Sched = new Form_Scheduler( "Test" );

            SchedulerControl_ SchedControl = new SchedulerControl_();
            SchedControl.Day_Time = Sched.StoredDays_Times;

            string comandostring = SchedControl.PrepareComandString( 0, SComand.Start );
            Assert.AreEqual( "", comandostring );

            comandostring = SchedControl.PrepareComandString( 1, SComand.Start );
            //1_Start_01:01:01_02:02:02_FromNow - example with test file
            Assert.AreEqual( "1_Start_01:01:01_02:02:02_FromNow", comandostring );

            comandostring = SchedControl.PrepareComandString( 1, SComand.Stop );
            //1_Start_01:01:01_02:02:02_FromNow - example with test file
            Assert.AreEqual( "1_Stop_01:01:01_02:02:02_FromNow", comandostring );

            // EXAMPLE:
            //  000000000_ASKFORSCHEDULERSTATUSJOB_job
            decimal transaction = 0;
            comandostring = MessageBuilder.GetCurrentSchedulerJobStatus( "job", transaction );
            Assert.AreEqual( String.Format( FormatConstants.TransactionNumberFormat, transaction ) + 
                "_" + 
                MessageTyp.ASK_SCHEDULER_JOB_STATUS +"_" + "job" , comandostring ); 

        }
    }
    #endregion
}
