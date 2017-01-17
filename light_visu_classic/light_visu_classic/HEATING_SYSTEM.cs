using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomeAutomation.HardConfig;
using HAHardware;

namespace light_visu_classic
{
    public partial class HEATING_SYSTEM : Form, IDigitalIO
    {
        #region DECLARATIONES
        public delegate void Boiler( object o, bool value );
        public event         Boiler EBoiler;

        public delegate void HPump( object o, bool value );
        public event         HPump HPump_;

        public delegate void Device( object sender, string device, bool value );
        public event         Device Device_;

        public delegate void PrepareStartScheduler( object sender, SchedulerControl_ e );
        public event         PrepareStartScheduler EPrepareStartScheduler;

        public delegate void AllHeaters( object sender, bool value );
        public event         AllHeaters EAllHeaters;

        public delegate void SchedRequestStatus_( object sender, string jobId );
        public event         SchedRequestStatus_ ESchedRequestStatus_;

        Color DefaultColor = new Color( );
        
        Dictionary<int, Button>    bDicOn;        // dictionary contains ON buttons   
        Dictionary<int, Button>    bDicOff;       // dictionary contains OFF buttons
        Dictionary<Button, string> bDicSettings;  // dictionary contrains settings buttons
        Dictionary<string, string> DeviceOnOffButtonNames = new Dictionary<string, string>(); // used for locating corresponding button pairs
        Dictionary<Button, string> OffButtonDeviceNames = new Dictionary<Button, string>();  // off contains device names to corresponding off buttons
        Dictionary<Button, string> OnButtonDeviceNames = new Dictionary<Button, string>();  // off contains device names to corresponding on buttons

        string _ActualJobStatus, _ActualJobStatusID;
        Form_Scheduler Scheduler;

        #endregion

        #region CONSTRUCTOR
        public HEATING_SYSTEM( )
        {
            InitializeComponent( );

            DefaultColor    = bBoiler_ON.BackColor;
            bDicOn          = new Dictionary<int, Button>( );
            bDicOff         = new Dictionary<int, Button>( );
            bDicSettings    = new Dictionary<Button, string>( );

            bDicOn.Add( CenterLivingRoomIODeviceIndices.indDigitalOutputBoiler,                     bBoiler_ON             );
            bDicOn.Add( CenterLivingRoomIODeviceIndices.indDigitalOutputPumpHeatingSystem,          bPumpHeaterOn          );
            bDicOn.Add( WaterHeatingSystemIODeviceIndices.indDigitalOutputWarmWaterCirculationPump, bPumpCircOn            );
            bDicOn.Add( AnteRoomIODeviceIndices.indDigitalOutputAnteRoomHeater,                     bHeaterAnteRoomOn      );
            bDicOn.Add( KitchenLivingRoomIOAssignment.indFirstHeater,                               bHeaterEastOn          );
            bDicOn.Add( KitchenLivingRoomIOAssignment.indLastHeater,                                bHeaterWestOn          );

            bDicOff.Add( CenterLivingRoomIODeviceIndices.indDigitalOutputBoiler,                    bBoilerOff             );
            bDicOff.Add( CenterLivingRoomIODeviceIndices.indDigitalOutputPumpHeatingSystem,         bPumpHeaterOff         );
            bDicOff.Add( WaterHeatingSystemIODeviceIndices.indDigitalOutputWarmWaterCirculationPump,bPumpCircOff           );
            bDicOff.Add( AnteRoomIODeviceIndices.indDigitalOutputAnteRoomHeater,                    bHeaterAnteRoomOff     );
            bDicOff.Add( KitchenLivingRoomIOAssignment.indFirstHeater,                              bHeaterEastWestOff     );
            bDicOff.Add( KitchenLivingRoomIOAssignment.indLastHeater,                               bHeaterEastWestOff     );

            bDicSettings.Add( bSettingsBoiler,                                                      HardwareDevices.Boiler );
            bDicSettings.Add( bSettingsPumpWarmwater,                                               HardwareDevices.PumpWarmwater );
            bDicSettings.Add( bSettingsPumpHeaters,                                                 HardwareDevices.PumpCirculation );

            DeviceOnOffButtonNames.Add( bAllHeatersOff.Name,                                        bAllHeatersOn.Name                    );
            DeviceOnOffButtonNames.Add( bHeaterAnteRoomOff.Name,                                    bHeaterAnteRoomOn.Name                );
            DeviceOnOffButtonNames.Add( bHeaterBathroomOff.Name,                                    bHeaterBathroomOn.Name                );
            DeviceOnOffButtonNames.Add( bHeaterDryerOff.Name,                                       bHeaterDryerOn.Name                   );
            DeviceOnOffButtonNames.Add( bHeaterEastWestOff.Name,                                    bHeaterEastOn.Name                    );
            DeviceOnOffButtonNames.Add( bHeaterSleepingRoomOff.Name,                                bHeaterSleepingRoomOn.Name            );
            DeviceOnOffButtonNames.Add( bHeaterNurseryOff.Name,                                     bHeaterNurseryOn.Name                 );

            OffButtonDeviceNames.Add( bHeaterAnteRoomOff,                                           HardwareDevices.HeaterAnteRoom         );
            OffButtonDeviceNames.Add( bHeaterBathroomOff,                                           HardwareDevices.HeaterBathRoom         );
            OffButtonDeviceNames.Add( bHeaterDryerOff,                                              HardwareDevices.HeaterDryerBathRoom    );
            OffButtonDeviceNames.Add( bHeaterSleepingRoomOff,                                       HardwareDevices.HeaterSleepingRoom     );
            OffButtonDeviceNames.Add( bHeaterNurseryOff,                                            HardwareDevices.HeaterNursery          );
            OffButtonDeviceNames.Add( bHeaterEastWestOff,                                           HardwareDevices.HeaterLivingRoomWest   );

            OnButtonDeviceNames.Add( bHeaterAnteRoomOn,                                             HardwareDevices.HeaterAnteRoom         );
            OnButtonDeviceNames.Add( bHeaterBathroomOn,                                             HardwareDevices.HeaterBathRoom         );
            OnButtonDeviceNames.Add( bHeaterDryerOn,                                                HardwareDevices.HeaterDryerBathRoom    );
            OnButtonDeviceNames.Add( bHeaterSleepingRoomOn,                                         HardwareDevices.HeaterSleepingRoom     );
            OnButtonDeviceNames.Add( bHeaterNurseryOn,                                              HardwareDevices.HeaterNursery          );
            OnButtonDeviceNames.Add( bHeaterEastOn,                                                 HardwareDevices.HeaterLivingRoomEast   );
            OnButtonDeviceNames.Add( bHeaterWestOn,                                                 HardwareDevices.HeaterLivingRoomWest   );
        }
        #endregion

        #region IO_INTERFACE_PRIMER
        bool[] _DigitalInputState;
        public bool[] DigitalInputs
        {
            set
            {
                _DigitalInputState = value;
            }           
            get
            {
                return _DigitalInputState;
            }
        }

        Button bActBtn;
        bool[] _DigitalOutputState;
        public bool[] DigitalOutputs
        {
            get
            {
                return _DigitalOutputState;
            }
            set
            {
                _DigitalOutputState = value;
                for( int i = 0; i < _DigitalOutputState.Length; i++ )
                {
                    // BUTTON COLOR ACTIVE WHEN DEVICE IS ON
                    if( _DigitalOutputState[i] )
                    {
                        if( bDicOn.TryGetValue( i, out bActBtn ) )
                        {
                            bActBtn.BackColor = Color.Green;
                        }
                    }
                    else
                    {
                        // BUTTON COLOR INCACTIVE WHEN DEVICE IS OFF
                        if( bDicOn.TryGetValue( i, out bActBtn ) )
                        {
                            bActBtn.BackColor               = DefaultBackColor;
                            bActBtn.UseVisualStyleBackColor = true;
                        }
                    }
                }
            }
        }

        int _SingleInputIndex;
        public int SingleInputIndex 
        { 
            set
            {
                _SingleInputIndex = value;
            } 
        }
       
        bool _SingleInputValue;
        public bool SingleInputValue 
        {
            set
            {
                _SingleInputValue = value;
            }
        }

        int _SingleOutputIndex;
        public int SingleOutputIndex
        {
            set
            {
                _SingleOutputIndex = value;
            }
        }

        bool _SingleOutputValue;
        public bool SingleOutputValue
        {
            set
            {
                _SingleOutputValue = value;
                // BUTTON COLOR ACTIVE WHEN DEVICE IS ON
                if( _SingleOutputValue )
                {
                    if( bDicOn.TryGetValue( _SingleOutputIndex, out bActBtn ) )
                    {
                        bActBtn.BackColor = Color.Green;
                    }
                }
                else
                {
                    // BUTTON COLOR INCACTIVE WHEN DEVICE IS OFF
                    if( bDicOn.TryGetValue( _SingleOutputIndex, out bActBtn ) )
                    {
                        bActBtn.BackColor               = DefaultBackColor;
                        bActBtn.UseVisualStyleBackColor = true;
                    }
                }
            }
        } 
        #endregion

        #region COMMANDO_EVENTHANDLERS
        private void bBoiler_ON_Click( object sender, EventArgs e )
        {
            if( EBoiler != null )
            {
                EBoiler( this, true );
            }
            bBoiler_ON.BackColor = Color.Green;
        }

        private void bBoilerOff_Click( object sender, EventArgs e )
        {
            if( EBoiler != null )
            {
                EBoiler( this, false );
            }
            bBoiler_ON.BackColor = DefaultColor;
            bBoiler_ON.UseVisualStyleBackColor = true;
        }

        private void bPumpHeaterOn_Click( object sender, EventArgs e )
        {
            if( HPump_ != null )
            {
                HPump_( this, true );
            }
            bPumpHeaterOn.BackColor = Color.Green;
            if( Device_ != null )
            {
                Device_( this, HardwareDevices.PumpWarmwater, true );
            }
        }

        private void bPumpHeaterOff_Click( object sender, EventArgs e )
        {
            if( HPump_ != null )
            {
                HPump_( this, false );
            }
            bPumpHeaterOn.BackColor              = DefaultColor;
            bPumpHeaterOn.UseVisualStyleBackColor = true;
            if( Device_ != null )
            {
                Device_( this, HardwareDevices.PumpWarmwater, false );
            }
        }

        private void bPumpCircOn_Click( object sender, EventArgs e )
        {
            bPumpCircOn.BackColor = Color.Green;
            if( Device_ != null )
            {
                Device_( this, HardwareDevices.PumpCirculation, true );
            }
        }

        private void bPumpCircOff_Click( object sender, EventArgs e )
        {
            bPumpCircOn.BackColor               = DefaultColor;
            bPumpCircOn.UseVisualStyleBackColor = true;
            if( Device_ != null )
            {
                Device_( this, HardwareDevices.PumpCirculation, false );
            }
        }
        private void bHeaterDevicesOn_Click( object sender, EventArgs e )
        {
            Button ClickedButton = ( sender as Button );

             // ALL HEATERS ON
            if( ClickedButton.Name == bAllHeatersOn.Name )
            {
                if( EAllHeaters != null )
                {
                    EAllHeaters( this, GeneralConstants.ON );
                }
            }

            // Common heater devices ON
            string devicename = "";
            OnButtonDeviceNames.TryGetValue( ClickedButton, out devicename );
            if( Device_ != null )
            {
                if( !String.IsNullOrEmpty( devicename ) )
                {
                    Device_( this, devicename, GeneralConstants.ON );
                }
            }

            int i = 0;
            foreach( var control in Controls )
            {                   
                if( ClickedButton.Name == Controls[i].Name )
                {
                    Controls[i].BackColor = Color.Green;
                    return;
                }
                i++;
            }
        }

        private void bHeaterDevicesOff_Click( object sender, EventArgs e )
        {
            Button ClickedButton = ( sender as Button );

            // ALL HEATERS OFF
            if( ClickedButton.Name == bAllHeatersOff.Name )
            {
                if( EAllHeaters != null )
                {
                    EAllHeaters( this, GeneralConstants.OFF );
                }
            }

            // Common heater devices OFF
            string devicename = ""; 
            OffButtonDeviceNames.TryGetValue( ClickedButton, out devicename );
            if( Device_ != null )
            {
                if( !String.IsNullOrEmpty( devicename ) )
                {
                    if( devicename == HardwareDevices.HeaterLivingRoomWest )
                    {
                        Device_( this, HardwareDevices.HeaterLivingRoomEast, GeneralConstants.OFF );
                        Device_( this, HardwareDevices.HeaterLivingRoomWest, GeneralConstants.OFF );
                    }
                    else
                    {
                        Device_( this, devicename, GeneralConstants.OFF );
                    }
                }
            }

            // on and off buttons belong to one group - so each of button has a corresponding on button
            string CorrespondingOnButton = "";
            DeviceOnOffButtonNames.TryGetValue( ClickedButton.Name, out CorrespondingOnButton );
            int i = 0;
            foreach( var control in Controls )
            {
                if( CorrespondingOnButton == Controls[i].Name )
                {
                    Controls[i].BackColor = Color.Silver;
                    break;
                }
                i++;
            }

            if( ClickedButton.Name == bHeaterEastWestOff.Name )
            {
                bHeaterEastOn.BackColor = Color.Silver;
                bHeaterWestOn.BackColor = Color.Silver;
            }
        }
        #endregion

        #region SCHEDULER
        string ActualScheduler = "";
        private void bSettingsHeaterSystemClick( object sender, EventArgs e )
        {
            bDicSettings.TryGetValue( ( sender as Button ), out ActualScheduler );
            Scheduler                       = new Form_Scheduler( Definitions.Scheduler + ActualScheduler);
            Scheduler.ESchedControl        += Scheduler_ESchedControl;
            Scheduler.ESchedRequestStatus  += Scheduler_ESchedRequestStatus;
            Scheduler.ShowDialog( );
       }


        void Scheduler_ESchedRequestStatus( object sender, string jobId )
        {
            if( ESchedRequestStatus_ != null )
            {
                ESchedRequestStatus_( sender, jobId );
            }
        }

        void Scheduler_ESchedControl( object sender, SchedulerControl_ e )
        {
            if( EPrepareStartScheduler != null )
            {
                EPrepareStartScheduler( sender, e ); 
            }
        }

        public string ActualJobStatus
        {
            set
            {
                _ActualJobStatus = value;
                if( Scheduler != null )
                {
                    Scheduler.ActualJobStatus = _ActualJobStatus;
                }
            }
        }

        public string ActualJobStatusID
        {
            set
            {
                _ActualJobStatusID = value;
                if( Scheduler != null )
                {
                    Scheduler.ActualJobStatusID = _ActualJobStatusID;
                }
            }
        }

        #endregion
    }
    static class Definitions
    {
        public const string Scheduler = "Scheduler_";
    }
}
