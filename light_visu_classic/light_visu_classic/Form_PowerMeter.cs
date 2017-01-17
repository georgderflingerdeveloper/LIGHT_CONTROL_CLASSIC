using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;
using Equipment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace light_visu_classic
{

    public partial class Form_PowerMeter : Form
    {
        #region DECLARATION
        List<EnergyDataSet>   EnergyData          = new List<EnergyDataSet>();
        List<string>          SelectedFileList_   = new List<string>();
        EnergyDataSet EnergyDataSetChart_         = new EnergyDataSet( );
        EnergyDataSet _EnergyActualDataSet        = new EnergyDataSet( ); 
        string PreparedSelectedStartDate;
        string PreparedSelectedEndTime;
        string _Directory;
        const string DateTimeSeperator            = ".";
        const char DateTimeSeperator_             = '.';
        const string DesiredDateTimeSeperator     = "_";
        const char DesiredDateTimeSeperator_      = '_';
        const char WhiteSpace                     = ' ';
        #endregion

        #region CONSTRUCTOR
        public Form_PowerMeter( )
        {
            InitializeComponent( );
            ChartConfig( );
            ControlsPreset( );
            GetDate( );
            EnergyData = ReadEnergyDataFile( EnergyConstants.DefaultDirectory );
            ChartUpdate( );
            _Directory = EnergyConstants.DefaultDirectory;
        }
        #endregion

        #region PUBLIC_METHODS
        #endregion

        #region PROPERTIES
        EnergyDataSet EnergyDataSet
        {
            set
            {
                _EnergyActualDataSet = value;
            }
        }

        string Directory
        {
            set
            {
                _Directory = value;
            }
        }
        #endregion

        #region PRIVATE_METHODS
        List<EnergyDataSet> ReadEnergyDataFile( string directory ) 
        {
            List<EnergyDataSet> Data_;
            try
            {
                XmlSerializer ser        = new XmlSerializer( typeof( List<EnergyDataSet> ) );
                StreamReader   sr        = new StreamReader( directory + EnergyConstants.DefaultFileName + "_" + PreparedSelectedStartDate + EnergyConstants.FileTyp );
                Data_ = (List<EnergyDataSet>)ser.Deserialize( sr );
                sr.Close( );
                return ( Data_ );
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex.Message, Equipment.Message.DataReadingFailed );
            }
            return( null );
        }

        void ReadEnergyDataFile( string directory, string filename )
        {
            List<EnergyDataSet> Data_;
            try
            {
                XmlSerializer ser        = new XmlSerializer( typeof( List<EnergyDataSet> ) );
                StreamReader   sr        = new StreamReader( directory + filename );
                Data_ = (List<EnergyDataSet>) ser.Deserialize( sr );
                sr.Close( );
                foreach( var energyDataset in Data_ )
                {
                    EnergyData.Add( energyDataset );
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex .Message, Equipment .Message .DataReadingFailed );
            }
        }

        void ChartUpdate()
        {
            chartPowerMeter.Series.Clear( );
            Series serie         = new Series();
            serie.XValueType     = ChartValueType.Time;
            serie.XValueMember   = nameof( EnergyDataSetChart_.TimeStamp );
            serie.YValueType     = ChartValueType.Double;
            serie.YValueMembers  = nameof( EnergyDataSetChart_.DisplayActualEnergy );
            chartPowerMeter.Series.Add( serie );
            chartPowerMeter.DataSource = EnergyData;
        }

        void ChartConfig()
        {
            chartPowerMeter.Titles.Add( Information.TitleEnergy );
        }

        void ControlsPreset( )
        {
            textBoxTotalEnergyCount.Enabled = false;
            textBoxEnergyCountDay.Enabled = false;
        }

        void GetDate()
        {
            string ActualDate = DateTime.Now.ToShortDateString();
            PreparedSelectedStartDate = ActualDate.Replace( DateTimeSeperator, DesiredDateTimeSeperator );
        }

        string GetPreparedDateFormat( string date )
        {
            string[] selectedDateTime_ = date.Split( WhiteSpace );
            return ( selectedDateTime_[0].Replace( DateTimeSeperator, DesiredDateTimeSeperator ) );
        }

        // file example: energy_10_09_2015.xml
        List<string> GetListOfFiles()
        {
            DirectoryInfo DirectoryInfo = new DirectoryInfo( _Directory );
            string Pattern = EnergyConstants.DefaultFileName + DesiredDateTimeSeperator + "*" + EnergyConstants.FileTyp;
            List<string>   Files = new List<string>();
            foreach ( var file in DirectoryInfo.GetFiles( Pattern ) )
            {
                Files.Add( file.Name );
            }
            return ( Files );
        }

        // get a list of date an time for easier sorting created file names
        // example: energy_10_09_2015.xml => 10.09.2015 
        //           0      1  2  3   4 ( index )
        // 10_09_2015
        // 10 ... DatePart
        // 09 ... DatePart
        // 2015 ... DatePart              
        const int StartIndex                  = 1;
        List<DateTime> ConvertListOfFilesIntoAListOfDateTime( List<string> FileNameList )
        {
            List<DateTime> DateTimeList = new List<DateTime>();

            foreach( var filename in FileNameList )
            {
                int PartIndex = StartIndex;
                string[] FileNameParts  = filename.Split( DesiredDateTimeSeperator_, DateTimeSeperator_ );
                int Day   = Convert.ToInt16( FileNameParts[StartIndex] );
                int Month = Convert.ToInt16( FileNameParts[StartIndex + PartIndex++] );
                int Year  = Convert.ToInt16( FileNameParts[StartIndex + PartIndex] );
                DateTime DateOfFileName = new DateTime( Year, Month, Day );
                DateTimeList.Add( DateOfFileName );
            }
            DateTimeList.Sort( );
            return ( DateTimeList );
        }

        List<string> GetFileListBetween( DateTime StartDate, DateTime EndDate )
        {
            List<string>   FilesList        = GetListOfFiles();
            List<string>   SelectedFileList = new List<string>();
            List<DateTime> DateTimeList     = ConvertListOfFilesIntoAListOfDateTime( FilesList );
            DateTime PresetedStartDate      = StartDate.Date; // cut time information, because it is not needed
            DateTime PresetedEndDate        = EndDate.Date;
            DateTime NextDayBetweenStartEndDate;
            double DaysBetween = 0;
            for( ;; )
            {
                NextDayBetweenStartEndDate = PresetedStartDate.AddDays( DaysBetween );
                if( DateTimeList.Contains( NextDayBetweenStartEndDate ) )
                {
                    string[] DateParts = NextDayBetweenStartEndDate.ToString( ).Split( DateTimeSeperator_, WhiteSpace );
                    string Day   = DateParts[0];
                    string Month = DateParts[1];
                    string Year  = DateParts[2];
                    SelectedFileList.Add( EnergyConstants.DefaultFileName +
                                          DesiredDateTimeSeperator        +
                                          Day                             +
                                          DesiredDateTimeSeperator        +
                                          Month                           +
                                          DesiredDateTimeSeperator        +
                                          Year                            +
                                          EnergyConstants.FileTyp );
                }

                if( NextDayBetweenStartEndDate > PresetedEndDate )
                {
                    break;
                }
                DaysBetween++;
            }

            return ( SelectedFileList );
        }

        #endregion 

        #region EVENTHANDLERS

        private void bActualiseData_Click( object sender, EventArgs e )
        {
            if( EnergyData?.Count > 0 )
            {
                EnergyData.Clear( );
            }

            SelectedFileList_ = GetFileListBetween( dateTimePickerPowerDataStart.Value, dateTimePickerPowerDataEnd.Value );

            EnergyData = ReadEnergyDataFile( EnergyConstants.DefaultDirectory );

            ChartUpdate( );
        }

        private void EDateTimePickerValueChanged( object sender, EventArgs e )
        {
            PreparedSelectedStartDate = GetPreparedDateFormat( dateTimePickerPowerDataStart.Value.ToString( ) );
        }

        private void EDateTimePickerEndValueChanged( object sender, EventArgs e )
        {
            PreparedSelectedEndTime = GetPreparedDateFormat( dateTimePickerPowerDataEnd.Value.ToString( ) );
        }

        private void buttonCounterPreset_Click( object sender, EventArgs e )
        {
            textBoxTotalEnergyCount.Enabled = true;
        }

        private void ETotalEnergyKeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Enter )
            {
                textBoxTotalEnergyCount.Enabled = false;
            }
        }
        #endregion

    }

    static class Information
    {
        public const string TitleEnergy = "Aktueller Leistungsverbrauch in KWh";
    }

    // used within a new List
    class EnergyDataLists
    {
        public List<EnergyDataSet> EnergyData { get; set; }
    }

    [TestClass]
    public class TestPowerMeter
    {
        [TestMethod]
        public void Test()
        {
        }
    }
}
