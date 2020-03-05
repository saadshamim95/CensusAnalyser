//-----------------------------------------------------------------------
// <copyright file="Testing.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace Testing
{
    using CensusAnalyser;
    using NUnit.Framework;

    /// <summary>
    /// Class for Testing
    /// </summary>
    [TestFixture]
    public class Testing
    {
        /// <summary>
        /// The state census data path
        /// </summary>
        private readonly string stateCensusDataPath = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCensusData.csv";

        /// <summary>
        /// The wrong file path
        /// </summary>
        private readonly string wrongFileName = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCensusDat.csv";

        /// <summary>
        /// The wrong file type
        /// </summary>
        private readonly string wrongFileType = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCensusData.csvx";

        /// <summary>
        /// The CSV header
        /// </summary>
        private string csvHeader = "State,Population,AreaInSqKm,DensityPerSqK";

        /// <summary>
        /// The Setup
        /// </summary>
        [SetUp]
        public void Setup()
        {           
        }

        /// <summary>
        /// Given the state census CSV file when analyze number of record matches.
        /// </summary>
        //// Test Case 1.1
        [Test]
        public void GivenStateCensusCSVFile_WhenAnalyze_NumberOfRecordMatches()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(this.stateCensusDataPath);
            Assert.AreEqual(stateCensusAnalyzer.NumberOfRecords(), "30");
        }

        /// <summary>
        /// Given the state census CSV file incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 1.2
        [Test]
        public void GivenStateCensusCSVFileIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(this.wrongFileName);
            CustomException ex = Assert.Throws<CustomException>(() => stateCensusAnalyzer.NumberOfRecords());
            Assert.That(ex.Message, Is.EqualTo("File Not Found!!!"));
        }

        /// <summary>
        /// Given the state census CSV file correct type incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 1.3
        [Test]
        public void GivenStateCensusCSVFileCorrectTypeIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(this.wrongFileType);
            string actual = stateCensusAnalyzer.NumberOfRecords();
            Assert.AreEqual("Incorrect File Format!!!", actual);
        }

        /// <summary>
        /// Given the state census CSV file correct delimiter incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 1.4
        [Test]
        public void GivenStateCensusCSVFileCorrectDelimiterIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(this.stateCensusDataPath, '.');
            string actual = stateCensusAnalyzer.NumberOfRecords();
            Assert.AreEqual("Delimiter Incorrect!!!", actual);
        }

        /// <summary>
        /// Given the state census CSV file correct CSV header incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 1.5
        [Test]
        public void GivenStateCensusCSVFileCorrectCSVHeaderIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(this.stateCensusDataPath, this.csvHeader);
            string actual = stateCensusAnalyzer.NumberOfRecords();
            Assert.AreEqual("CSV Header Incorrect !!!", actual);
        }
    }
}