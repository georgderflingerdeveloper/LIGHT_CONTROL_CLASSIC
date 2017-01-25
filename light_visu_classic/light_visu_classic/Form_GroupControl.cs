using System;
using System.Windows.Forms;
using Communication.UDP;
using HomeAutomation.HardConfig;

namespace light_visu_classic
{
    public partial class Form_GroupControl : Form
    {
        Form_PowerMeter PowerMeter = new Form_PowerMeter();
        UdpSend CommandoSender;

        public Form_GroupControl()
        {
            InitializeComponent();
            CommandoSender = new UdpSend( "127.0.0.1", IPConfiguration.Port.PORT_LIGHT_CONTROL_COMMON );
        }

        private void bPowerMeter_Click( object sender, EventArgs e )
        {
            Form fPowerMeter = PowerMeter as Form;
            FormControl.ShowAligned( ref fPowerMeter, Devices.NamesGerman.PowerMeter );
        }

        private void buttonLightGroupKitchenOn_Click(object sender, EventArgs e)
        {
            CommandoSender?.SendString( ComandoString.TURN_ALL_LIGHTS_ON );
        }
    }
}
