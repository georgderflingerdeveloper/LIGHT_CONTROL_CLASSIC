using System;
using System.Windows.Forms;
using Communication.UDP;

namespace light_visu_classic
{
    public partial class Form_GroupControl : Form
    {
        Form_PowerMeter PowerMeter = new Form_PowerMeter();

        public Form_GroupControl()
        {
            InitializeComponent();
        }

        private void bPowerMeter_Click( object sender, EventArgs e )
        {
            Form fPowerMeter = PowerMeter as Form;
            FormControl.ShowAligned( ref fPowerMeter, Devices.NamesGerman.PowerMeter );
        }

        private void buttonLightGroupKitchenOn_Click(object sender, EventArgs e)
        {

        }
    }
}
