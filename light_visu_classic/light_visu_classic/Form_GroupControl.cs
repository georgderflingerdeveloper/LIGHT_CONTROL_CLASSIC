﻿using System;
using System.Windows.Forms;
using Communication.UDP;
using HomeAutomation.HardConfig;

namespace light_visu_classic
{
    public partial class Form_GroupControl : Form
    {
        Form_PowerMeter PowerMeter = new Form_PowerMeter();
        UdpSend CommandoSender;
        UdpSend CommandoSenderEast;

        public Form_GroupControl()
        {
            InitializeComponent();
            CommandoSender     = new UdpSend( "127.0.0.1", IPConfiguration.Port.PORT_LIGHT_CONTROL_COMMON );
            CommandoSenderEast = new UdpSend( "127.0.0.1", IPConfiguration.Port.PORT_UDP_LIVINGROOM_EAST );
        }

        private void bPowerMeter_Click( object sender, EventArgs e )
        {
            Form fPowerMeter = PowerMeter as Form;
            FormControl.ShowAligned( ref fPowerMeter, Devices.NamesGerman.PowerMeter );
        }

        private void buttonLightGroupKitchenOn_Click(object sender, EventArgs e)
        {
            CommandoSender?.SendString( ComandoString.TURN_ALL_KITCHEN_LIGHTS_ON );
        }

        private void buttonLightGroupKitchenOff_Click(object sender, EventArgs e)
        {
            CommandoSender?.SendString( ComandoString.TURN_ALL_KITCHEN_LIGHTS_OFF );
        }

        private void buttonGalleryDownOn_Click(object sender, EventArgs e)
        {
            CommandoSenderEast?.SendString( ComandoString.TURN_GALLERY_DOWN_ON );
        }

        private void buttonGalleryDownOff_Click(object sender, EventArgs e)
        {
            CommandoSenderEast?.SendString( ComandoString.TURN_GALLERY_DOWN_OFF );
        }
    }
}
