using System;
using System.Collections.Generic;

namespace HomeAutomation
{
    namespace HardConfig
    {
        static class TimeConverter
        {
            static public double ToMiliseconds ( double seconds )
            {
                return ( seconds * 1000 );
            }

            static public double ToMiliseconds ( double minutes, double seconds )
            {
                return ( ( minutes * 60  + seconds ) * 1000  );
            }

            static public double ToMiliseconds ( double hours, double minutes, double seconds )
            {
                return ( ( hours * 3600 + minutes * 60 + seconds ) * 1000 );
            }
        }

        static class GeneralConstants
        {
            public const double TimerDisabled = 0;
            public const int NuberOfOutputsIOCard = 16;
        }

        static class InfoString
        {
            public const string InfoPhidgetException  =  "Phidget Exception";
            public const string AppPrefix             =  "Home Automation Comander: ";
            public const string AppCmdLstPrefix       =  "Home Automation Comado List: ";
            public const string ConfigFileName        =  "conf.ini";
            public const string IniSection            =  "SECTION";
            public const string IniSectionPhidgets    =  "PHIDGETS";
            public const string OperationMode         =  "Selected Operation Mode: ";
        }

        static class InfoOperationMode
        {
            public const string SLEEPING_ROOM                      =  "SLEEPINGROOM";
            public const string CENTER_KITCHEN_AND_LIVING_ROOM     =  "CENTER_KITCHEN_LIVING_ROOM";
            public const string ANTEROOM                           =  "ANTEROOM";
            public const string LIVING_ROOM_EAST                   =  "LIVINGROOMEAST";
            public const string LIVING_ROOM_WEST                   =  "LIVINGROOMWEST";
            public const string TCP_COMUNICATION_SERVER            =  "TCP_SERVER";
            public const string TCP_COMUNICATION_CLIENT            =  "TCP_CLIENT";
            public const string TCP_COMUNICATION_SERVER_INTERNAL   =  "TCP_SERVER_INTERNAL";
            public const string TCP_COMUNICATION_CLIENT_INTERNAL   =  "TCP_CLIENT_INTERNAL";
            public const string TCP_COMUNICATION_CLIENT_STRESSTEST =  "TCP_CLIENT_STRESSTEST";
        }

        static class IPConfiguration
        {
            public static class Address
            {
                public const string IP_ADRESS_BROADCAST        = "192.168.0.255";
                public const string IP_ADRESS_LIVING_ROOM_EAST = "192.168.0.104";  
            }

            public static class Port
            {
                public const int PORT_LIGHT_CONTROL_LIVING_ROOM_EAST = 5000;
                public const int PORT_SERVER                         = 6000;
            }
        }

        // TODO - make configurable
        static class Phidget_ID
        {
             public const int ID_LED_CARD_1                             = 336230;
             public const int ID_IFKIT_SLEEPING_ROOM                    = 312651;
             public const int ID_IFKIT_ANTEROOM_1                       = 0;
             public const int ID_IFKIT_ANTEROOM_2                       = 0;
             public const int ID_IFKIT_LIVINGROOM_1                     = 0;
             public const int ID_IFKIT_LIVINGROOM_2                     = 0;
             public const int ID_IFKIT_LIVINGROOM_EAST_1                = 311883;
             public const int ID_IFKIT_LIVINGROOM_EAST_2                = 346077;
             public const int ID_IFKIT_LIVINGROOM_WEST                  = 0;
        }

        static class ComandoString
        {
            public  const string  NONE              = "NONE";
            public  const string  COMAND_INFOTEXT   = "ON/OFF/BLINK/SPOT1_ON/OFF/EFF_WALK/EXIT/SELF_ON/SELF_OFF";
            public  const string  ON                = "ON";
            public  const string  OFF               = "OFF";
            public  const string  EXIT              = "EXIT";
            public  const string  BLINK             = "BLINK";
            public  const string  EFFECT_WALK       = "EFF_WALK";
            public  const string  SELF_TEST         = "SELF_ON";
            public  const string  SELF_TEST_OFF     = "SELF_OFF";

            static Dictionary<uint, string> ComandoDictionary = new Dictionary<uint, string>
            {
            {0,                  COMAND_INFOTEXT                },
            {1,                  ON                             },
            {2,                  OFF                            },
            {4,                  BLINK                          },
            {36,                 EFFECT_WALK                    },
            {37,                 SELF_TEST                      },
            {38,                 SELF_TEST_OFF                  },
            {100,                EXIT                           }
            };

          
            public static string GetComando ( uint comandokey )
            {
                // Try to get the result in the static Dictionary
                string result;
                if( ComandoDictionary.TryGetValue( comandokey, out result ) )
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }

            public static class Button
            {
                public const string Button_    =  "Button";      
                public const string IsPressed  =  "IS_PRESSED";
                public const string IsReleased =  "IS_RELEASED";
                public const string Udefined   =  "UNDEFINED";
            }

            public static class Buttons
            {
                public const string MainDownRight = "MAIN_DOWN_RIGHT";
                public const string MainDownLeft  = "MAIN_DOWN_LEFT";
                public const string MainUpLeft    = "MAIN_UP_LEFT";
                public const string MainUpRight   = "MAIN_UP_RIGHT";
            }

            public static class Telegram
            {
                public const string Index = "IND";
                public const string State = "STA";
                public const char Seperator = '_';
                public const int IndexTransactionCounter = 0;
                public const int IndexDigitalInputs      = 1;
                public const int IndexValueDigitalInputs = 2;
            }
        }

        static class LedComandoString
        {
            public  const string  LED1_ON                = "LED1_ON";
            public  const string  LED1_OFF               = "LED1_OFF";
        }

        static class HardwareIOAssignment
        {
            public const int Input_ALL_ON  = 0;
            public const int Input_TipNext = 1;
            public const int Output_Spot1  = 0;
        }

        static class SleepingRoomIOAssignment
        {
            public const int  indMainButton       = 0;
            public const int  indNoiseSwitch      = 1;
            public const int  indWindowWest       = 2;
            public const int  indWindowNord_Left  = 3;
            public const int  indWindowNord_Right = 4;
            public const int  indFireAlert        = 5;
            public const int  indDoor             = 6;
            public const int  indOptionalWalk     = 7;
            public const int  indOptionalMakeStep = 8;
        }

        static class LivingRoomEastHardwareAssignment
        {
            public const int indInterfaceCard_1 = 0;
            public const int indInterfaceCard_2 = 1;
        }

        static class LivingRoomEastIOAssignment
        {
            public static class LivDigInputs
            {
            }
        }

        static class LivingRoomWestIOAssignment
        {
            public static class LivWestDigInputs
            {
                public const int indDigitalInputButtonMainDownRight = 0;
                public const int indDigitalInputButtonMainDownLeft  = 1;
                public const int indDigitalInputButtonMainUpLeft    = 2;
                public const int indDigitalInputButtonMainUpRight   = 3;
                public const int indDigitalInputPresenceDetector    = 5;
            }

            public static class LivWestDigOutputs
            {
                public const int indDigitalOutLightWindowDoorEntryLeft  = 0;
                public const int indDigitalOutLightKitchenDown_1        = 1;
                public const int indDigitalOutLightKitchenDown_2        = 2;
            }

            public const int indFirstLight = 0;
            public const int indLastLight  = LivWestDigOutputs.indDigitalOutLightKitchenDown_2;
        }

        static class CommonRoomIOAssignment
        {
            public const int  indMainButton       = 0;
            public const int  indDoor             = 1;
            public const int  indOptionalWalk     = 2;
            public const int  indOptionalMakeStep = 3;
            public const int  indOutputIsAlive    = 15;
        }

        static class KitchenIOAssignment
        {
            public const int indKitchenMainButton        = 0;
            public const int indKitchenPresenceDetector  = 7;
        }

        static class CenterButtonRelayIOAssignment
        {
            public const int indDigitalInputRelaySleepingRoom = 3;
            public const int indDigitalInputRelayWashRoom     = 4;
            public const int indDigitalInputRelayAnteRoom     = 5;
            public const int indDigitalInputRelayBathRoom     = 6;
        }

        static class KitchenIOLightIndices
        {
            public const int indFirstKitchen                = 0;
            public const int indFumeHood                    = 4;
            public const int indSlot                        = 5;
            public const int indDigitalOutputKitchenKabinet = 6;
            static readonly public int  indLastKitchen   = indDigitalOutputKitchenKabinet;
        }

        static class KitchenLivingRoomIOAssignment
        {
            public const int indFirstHeater = 13;
            public const int indLastHeater  = 14;
        }

        static class AnteRoomIOAssignment
        {
            public const int indAnteRoomMainButton         = 0;
            public const int indWashRoomMainButton         = 1;
            public const int indBathRoomMainButton         = 2;
            public const int indAnteRoomPresenceDetector   = 3;
        }

        static class BathRoomIODeviceIndices
        {
            public const int indDigitalOutputBathRoomFirstHeater = 12;
            public const int indDigitalOutputBathRoomLastHeater  = 12;
        }

        static class SleepingRoomIODeviceIndices
        {
            public const int indDigitalOutputHeater = 5;
        }

        static class AnteRoomIODeviceIndices
        {
            public const int indDigitalOutputAnteRoomHeater = 12;
        }

        static class WashRoomIODeviceIndices
        {
            public const int indDigitalOutputWashRoomLight = 5;
            public const int indDigitalOutputWashRoomFan   = 12;
        }


        static class AnteRoomIOLightIndices
        {
            public const int indFirstLight    = 0;
            public const int indLastLight     = 4;
            public const int indFirstWashroom = 5;
            public const int indLastWashroom  = 6;
        }

        static class BathRoomIOLightIndices
        {
            public const int indFirstBathRoom = 7;
            public const int indLastBathRoom  = 11;
        }

        static class BathRoomIOLightIndexNaming
        {
            public const int MiddleLight       = BathRoomIOLightIndices.indFirstBathRoom;
            public const int RBG_PanelOverBath = BathRoomIOLightIndices.indLastBathRoom;
        }

        static class AnteRoomIOLightIndexNaming
        {
            public const int AnteRoomMainLight                         = 0;
            public const int AnteRoomBackSide                          = 1;
            public const int AnteRoomRoofBackSideFloorSpotGroupMiddle1 = 2;
            public const int AnteRoomRoofBackSideFloorSpotGroupMiddle2 = 3;
            public const int AnteRoomNightLight                        = 4;
        }

        static class SleepingIOLightIndices
        {
            public const int indSleepingRoomFirstLight    = 0;
            public const int indSleepingRoomLastLight     = 4;
        }

        static class LightMode
        {
            public const int Walk      = 0;
            public const int MakeStep  = 1 ;
        }

        static class Parameters
        {
            public const Int32 AttachWaitTime         = 10000;      
            public const double BlinkIntervallTime    = 500;
            public const double SelfTestIntervallTime = 1000;
            public const double WalkIntervallTime     = 100;
            public const double WalkIntervallTimeFast = 50;
            public const double TimeActiveateFeature  = 3000;
            public const double TimedActivateSequence = 1500;
            public const double SequenceTime          = 250;
            public const double TimeIntervallAlive    = 500;
            public const bool Unused = false;
        }

        static class ParametersLightControl
        {
            public const double TimeDemandForAllOn            = 2500;
            public const double TimeDemandForSingleOff        = 700;
            public const double TimeDemandForBroadcastAllOff  = 3000;
            static readonly public double TimeDemandForAutomaticOff    = TimeConverter.ToMiliseconds( 15, 0 );
        }

  
        static class ParametersLightControlSleepingRoom
        {
            static readonly public double TimeDemandForAutomaticOff    = TimeConverter.ToMiliseconds( 3, 0, 0 );
            static readonly public double TimeDemandForAllOn           = TimeConverter.ToMiliseconds( 8 );
        }

        static class ParametersLightControlLivingRoomWest
        {
            public const double TimeDemandForAllOnWest                 = 1200;
            static readonly public double TimeDemandForAutomaticOffWest    = TimeConverter.ToMiliseconds( 3, 0, 0);
        }

        static class ParametersHeaterControl
        {
            static readonly public double TimeDemandForHeatersOnOff                  = TimeConverter.ToMiliseconds(1.4);
            static readonly public double TimeDemandForHeatersFinalOff               = TimeConverter.ToMiliseconds( 7 );
            static readonly public double TimeDemandForHeatersOnSleepingRoomBig      = TimeConverter.ToMiliseconds( 30, 0 );
            static readonly public double TimeDemandForHeatersOnSleepingRoomMiddle   = TimeConverter.ToMiliseconds( 15, 0 );
            static readonly public double TimeDemandForHeatersOnSleepingRoomSmall    = TimeConverter.ToMiliseconds( 10, 0 );
            static readonly public double TimeDemandForHeatersOffSleepingRoomBig     = TimeConverter.ToMiliseconds( 20, 0 );
            static readonly public double TimeDemandForHeatersOffSleepingRoomMiddle  = TimeConverter.ToMiliseconds( 10, 0 );
            static readonly public double TimeDemandForHeatersOffSleepingRoomSmall   = TimeConverter.ToMiliseconds( 5, 0 );
            static readonly public double TimeDemandForHeatersAutomaticOff           = TimeConverter.ToMiliseconds( 25, 0 );
            static readonly public double TimeDemandForHeatersAutomaticOffBig        = TimeConverter.ToMiliseconds( 3, 0, 0 );
            static readonly public double TimeDemandForHeatersAutomaticOffHalfDay    = TimeConverter.ToMiliseconds( 12, 0, 0 );
            static readonly public double TimeDemandForHeatersAutomaticOffMiddle     = TimeConverter.ToMiliseconds( 1, 30, 0 );
            static readonly public double TimeDemandForHeatersAutomaticOffSmall      = TimeConverter.ToMiliseconds( 30, 0 );
            static readonly public double TimeDemandShowHeaterActive                 = TimeConverter.ToMiliseconds( 0.3 );
            static readonly public double TimeDemandPauseShowHeaterActive            = TimeConverter.ToMiliseconds( 0.2 );
            static readonly public double TimeDemandForItensityTimer                 = 1200;
            static readonly public double TimeDemandForPermanentOnWindow             = 1500;
            static readonly public int MaxIntensitySteps                             = 3;

            static readonly public double ShowOff                                  = TimeConverter.ToMiliseconds( 0.2 );
            static readonly public double ShowOn                                   = TimeConverter.ToMiliseconds( 0.1 );

            static Dictionary<uint, double> HeaterOnDic = new Dictionary<uint, double>
            {
            {0,                  TimeDemandForHeatersOnSleepingRoomSmall                },
            {1,                  TimeDemandForHeatersOnSleepingRoomMiddle               },
            {2,                  TimeDemandForHeatersOnSleepingRoomBig                  },
            };

            static Dictionary<uint, double> HeaterOffDic = new Dictionary<uint, double>
            {
            {0,                  TimeDemandForHeatersOffSleepingRoomSmall                },
            {1,                  TimeDemandForHeatersOffSleepingRoomMiddle               },
            {2,                  TimeDemandForHeatersOffSleepingRoomBig                  },
            };

            static double GetHeaterTime( ref Dictionary<uint, double> Dic, uint key )
            {
                // Try to get the result in the static Dictionary
                double result;
                if( Dic.TryGetValue( key, out result ) )
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }

            public static double GetHeaterOnTime( uint index )
            {
                return GetHeaterTime( ref HeaterOnDic, index );
            }

            public static double GetHeaterOffTime( uint index )
            {
                return GetHeaterTime( ref HeaterOffDic, index );
            }
        }

        static class ParametersHeaterControlSleepingRoom
        {
            static readonly public double TimeDemandForHeatersAutomaticOff           = TimeConverter.ToMiliseconds( 10, 0, 0 );
        }

        static class ParametersHeaterControlLivingRoom
        {
            static readonly public double TimeDemandForHeatersOnBig      = TimeConverter.ToMiliseconds( 30, 0 );
            static readonly public double TimeDemandForHeatersOnMiddle   = TimeConverter.ToMiliseconds( 15, 0 );
            static readonly public double TimeDemandForHeatersOnSmall    = TimeConverter.ToMiliseconds( 10, 0 );
            static readonly public double TimeDemandForHeatersOffBig     = TimeConverter.ToMiliseconds( 15, 0 );
            static readonly public double TimeDemandForHeatersOffMiddle  = TimeConverter.ToMiliseconds( 10, 0 );
            static readonly public double TimeDemandForHeatersOffSmall   = TimeConverter.ToMiliseconds( 5, 0 );
            static readonly public double TimeDemandForHeatersOnDefrost  = TimeConverter.ToMiliseconds( 30 );
            static readonly public double TimeDemandForHeatersOffDefrost = TimeConverter.ToMiliseconds( 45 );
        }

        static class ParametersHeaterControlBathRoom
        {
            static readonly public double TimeDemandForHeaterAutomaticOff = new TimeSpan( 2, 0, 0, 0, 0 ).TotalMilliseconds;
        }

        static class ParametersWaterHeatingSystem
        {
            static readonly public double TimeDemandForWarmCirculationPumpAutomaticOff       = TimeConverter.ToMiliseconds( 5, 0 );
        }

        static class WaterHeatingSystemIODeviceIndices
        {
            public const int indDigitalOutputWarmWaterCirculationPump = 11;
        }

        static class ParametersHeatingSystem
        {
            static readonly public double TimeDemandForHeaterCirculationPumpAutomaticOff       = TimeConverter.ToMiliseconds( 6, 0, 0 );
        }

        static class ParametersWashRoomControl
        {
            static readonly public double TimeDemandForFanOn           = TimeConverter.ToMiliseconds( 2 );
            static readonly public double TimeDemandForFanAutomaticOff = TimeConverter.ToMiliseconds( 15, 0 );
        }

        static class ParametersLightControlKitchen
        {
            static readonly public double TimeDemandForAutomaticOffKitchen = TimeConverter.ToMiliseconds( 20, 0 );
            static readonly public double TimeDemandForAllOn            =     TimeConverter.ToMiliseconds( 9 );
        }

        static class ParametersLightControlEASTSide
        {
            static readonly public double TimeDemandForAutomaticOffEastSide = TimeConverter.ToMiliseconds( 1, 0, 0 );
            static readonly public double TimeDemandForAllOn            =     TimeConverter.ToMiliseconds( 2.5 );
        }

        static class EastSideIOAssignment
        {
            public const int indTestButton                           = 0;
            public const int indSpotFrontSide1_4                     = 0;
            public const int indSpotFrontSide5_8                     = 1;
            public const int indSpotBackSide1_3                      = 2;
            public const int indSpotBackSide4_8                      = 3;
            public const int indLightsTriangleGalleryBack            = 4;
            public const int indDoorEntry_Window_Right               = 5;
            public const int indWindowBesideDoorRight                = 6;
            public const int indWindowLimitSwitchWestUpside          = 2;
            public const int indSpotGalleryFloor_1_18                = 0;
            public const int indSpotGalleryFloor_2_4                 = 1;
            public const int indSpotGalleryFloor_5_6                 = 3;
            public const int indSpotGalleryFloor_7                   = 4;
            public const int indSpotGalleryFloor_8_10                = 5;
            public const int indSpotGalleryFloor_11_12               = 6;
            public const int indSpotGalleryFloor_13                  = 7;
            public const int indSpotGalleryFloor_14_15               = 8;
            public const int indSpotGalleryFloor_16                  = 9;
            public const int indSpotGalleryFloor_17_19_20_21         = 10;
            public const int indBarGallery1_4                        = 11;
            public const int indDigitalInput_PresenceDetector        = 5;
        }

        static class ParametersLightControlAnteRoom
        {
            static readonly public double TimeDemandForAutomaticOffAnteRoom = TimeConverter.ToMiliseconds( 10, 0);
            static readonly public double TimeDemandForAllOn            =     TimeConverter.ToMiliseconds( 3.0 );
        }

        static class ParametersLightControlWashRoom
        {
            static readonly public double TimeDemandForAutomaticOffWashRoom = TimeConverter.ToMiliseconds( 30, 0 );
        }

        static class ParametersLightControlBathRoom
        {
            static readonly public double TimeDemandForAutomaticOffBath = TimeConverter.ToMiliseconds( 1, 0, 0 );
        }

        static class MESSAGE_Constants
        {
            public const int LOCATION_INDEX_MESSAGE_TRANSACTION_COUNTER = 0;
            public const int LOCATION_INDEX_PURE_MESSAGE                = 13;
        }
    }
}
