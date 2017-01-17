using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
