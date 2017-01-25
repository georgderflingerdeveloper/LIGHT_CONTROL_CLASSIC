using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace light_visu_classic
{
    public static class HardConfig
    {
        public static class RoomWindow
        {
            public static readonly int Witdh = 1024;
            public static readonly int Height = 600;
        }
    }

    public static class Parameters
    {
        public static readonly int Intervall_ClientInvite = 5000;
    }

    public static class Rooms
    {
        public static class NamesGerman
        {
            public static readonly string Anteroom       = "Vorhaus";
            public static readonly string LivingRoomEast = "WohnzimmerOst";
            public static readonly string LivingRoomWest = "WohnzimmerWest";
            public static readonly string AlarmSystem    = "Alarmanlage";
            public static readonly string Outside        = "Aussenbereich";
            public static readonly string Networking     = "Netzwerksystem";
            public static readonly string RoofRoomNorth  = "DachbodenRaum";
            public static readonly string Heaters        = "Heizung und Warmwasser";
            public static readonly string RoofGallery    = "Gallerie";
            public static readonly string SleepingRoom   = "Schlafzimmer";
            public static readonly string Kitchen        = "Küche";
            public static readonly string BathRoom       = "Badezimmer";
            public static readonly string GroupControl   = "Gruppenansteuerung";
        }
    }

    public static class Devices
    {
        public static class NamesGerman
        {
            public static readonly string PowerMeter       = "Leistungszähler";
        }
    }

}
