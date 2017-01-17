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

namespace light_visu_classic
{
    public partial class Form_RoofGallery : Form
    {
        #region DECLARATIONS
        public delegate void Device( object sender, string device, bool value );
        public event         Device Device_;
        Dictionary<Button, string> ButtonDeviceNames = new Dictionary<Button, string>();  // off contains device names to corresponding off buttons
        bool[] Toggle;
        #endregion

        #region CONSTRUCTOR
        public Form_RoofGallery( )
        {
            InitializeComponent( );
            Toggle = new bool[this.Controls.Count];
            ButtonDeviceNames.Add( bSpotGallery1, HardwareDevices.Gallery.FloorSpotGroup1);
            ButtonDeviceNames.Add( bAllLights, VirtualDevice.GroupGalleryFloor );

           
        }
        #endregion

        #region EVENTHANDLERS
        private void ELightOnOff( object sender, EventArgs e )
        {
            Button ClickedButton = ( sender as Button );
            int index = FormsServices.GetIndexOfControl( this.Controls,ClickedButton.Name );
            string devicename = "";
            ButtonDeviceNames.TryGetValue( ClickedButton, out devicename );
            if( Device_ != null )
            {
                if( !String.IsNullOrEmpty( devicename ) )
                {
                    if( !Toggle[index] )
                    {
                        Device_( this, devicename, GeneralConstants.ON );
                    }
                    else
                    {
                        Device_( this, devicename, GeneralConstants.OFF );
                    }
                    Toggle[index] = !Toggle[index];
                }
            }
         }

        private void GroupCommandAllLightsFloor( object sender, EventArgs e )
        {
            Button ClickedButton = ( sender as Button );
            int index = FormsServices.GetIndexOfControl( this.Controls, ClickedButton.Name );
            if( !Toggle[index] )
            {
                Device_( this, VirtualDevice.GroupGalleryFloor, GeneralConstants.ON );
                ClickedButton.BackColor = Color.Yellow;
            }
            else
            {
                Device_( this, VirtualDevice.GroupGalleryFloor, GeneralConstants.OFF );
                ClickedButton.BackColor = Color.Gray;
            }
            Toggle[index] = !Toggle[index];
        }
         #endregion

        #region PRIVATE_METHODS
        #endregion
    }
}
