//-----------------------------------------------------------------------
// <copyright file="Testing.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace Testing
{
    using System;
    using CensusAnalyser;
    using NUnit.Framework;
    using static CensusAnalyser.CSVStateCensus;

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
        /// The wrong state census file name
        /// </summary>
        private readonly string wrongStateCensusFileName = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCensusDat.csv";

        /// <summary>
        /// The wrong state census file type
        /// </summary>
        private readonly string wrongStateCensusFileType = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCensusData.csvx";

        /// <summary>
        /// The wrong delimiter
        /// </summary>
        private readonly char wrongDelimiter = '.';

        /// <summary>
        /// The CSV state census header
        /// </summary>
        private readonly string wrongCSVStateCensusHeader = "State,Population,AreaInSqKm,DensityPerSqK";

        /// <summary>
        /// The state code path
        /// </summary>
        private readonly string stateCodePath = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCode.csv";

        /// <summary>
        /// The wrong state code file name
        /// </summary>
        private readonly string wrongStateCodeFileName = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCod.csv";

        /// <summary>
        /// The wrong state code file type
        /// </summary>
        private readonly string wrongStateCodeFileType = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCode.csvx";

        /// <summary>
        /// The CSV state code header
        /// </summary>
        private readonly string wrongCSVStateCodeHeader = "SrNo,State,Name,TIN,StateCod";

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
            CSVStateCensus csvStateCensus = new CSVStateCensus(this.stateCensusDataPath);
            GetCSVData getCSVData = new GetCSVData(csvStateCensus.NumberOfRecords);
            string expected = getCSVData.Invoke();
            string actual = stateCensusAnalyzer.NumberOfRecords();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Given the state census CSV file incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 1.2
        [Test]
        public void GivenStateCensusCSVFileIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            CSVStateCensus csvStateCensus = new CSVStateCensus(this.wrongStateCensusFileName);
            GetCSVData getCSVData = new GetCSVData(csvStateCensus.NumberOfRecords);
            CustomException exception = Assert.Throws<CustomException>(() => getCSVData.Invoke());
            Console.WriteLine("Exception: " + exception.Message);
            Assert.AreEqual("File Not Found!!!", exception.Message);
        }

        /// <summary>
        /// Given the state census CSV file correct type incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 1.3
        [Test]
        public void GivenStateCensusCSVFileCorrectTypeIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            CSVStateCensus csvStateCensus = new CSVStateCensus(this.wrongStateCensusFileType);
            Console.WriteLine("CSVStateCensus: " + csvStateCensus.NumberOfRecords());
            GetCSVData getCSVData = new GetCSVData(csvStateCensus.NumberOfRecords);
            string actual = getCSVData.Invoke();
            Assert.AreEqual("Incorrect File Format!!!", actual);
        }

        /// <summary>
        /// Given the state census CSV file correct delimiter incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 1.4
        [Test]
        public void GivenStateCensusCSVFileCorrectDelimiterIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            CSVStateCensus csvStateCensus = new CSVStateCensus(this.stateCensusDataPath, this.wrongDelimiter);
            Console.WriteLine("CSVStateCensus: " + csvStateCensus.NumberOfRecords());
            GetCSVData getCSVData = new GetCSVData(csvStateCensus.NumberOfRecords);
            string actual = getCSVData.Invoke();
            Assert.AreEqual("Delimiter Incorrect!!!", actual);
        }

        /// <summary>
        /// Given the state census CSV file correct CSV header incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 1.5
        [Test]
        public void GivenStateCensusCSVFileCorrectCSVHeaderIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            CSVStateCensus csvStateCensus = new CSVStateCensus(this.stateCensusDataPath, this.wrongCSVStateCensusHeader);
            Console.WriteLine("CSVStateCensus: " + csvStateCensus.NumberOfRecords());
            GetCSVData getCSVData = new GetCSVData(csvStateCensus.NumberOfRecords);
            string actual = getCSVData.Invoke();
            Assert.AreEqual("CSV Header Incorrect !!!", csvStateCensus.NumberOfRecords());
        }

        /// <summary>
        /// Given the state code CSV file when analyze number of record matches.
        /// </summary>
        //// Test Case 2.1
        [Test]
        public void GivenStateCodeCSVFile_WhenAnalyze_NumberOfRecordMatches()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(this.stateCodePath);
            CSVStates csvStates = new CSVStates(this.stateCodePath);
            GetCSVData getCSVData = new GetCSVData(csvStates.NumberOfRecords);
            string expected = getCSVData.Invoke();
            string actual = stateCensusAnalyzer.NumberOfRecords();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Given the state code CSV file incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 2.2
        [Test]
        public void GivenStateCodeCSVFileIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            CSVStates csvStates = new CSVStates(this.wrongStateCodeFileName);
            GetCSVData getCSVData = new GetCSVData(csvStates.NumberOfRecords);
            CustomException exception = Assert.Throws<CustomException>(() => getCSVData.Invoke());
            Console.WriteLine("Exception: " + exception.Message);
            Assert.AreEqual("File Not Found!!!", exception.Message);
        }

        /// <summary>
        /// Given the state code CSV file correct type incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 2.3
        [Test]
        public void GivenStateCodeCSVFileCorrectTypeIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            CSVStates csvStates = new CSVStates(this.wrongStateCodeFileType);
            Console.WriteLine("CSVStates: " + csvStates.NumberOfRecords());
            GetCSVData getCSVData = new GetCSVData(csvStates.NumberOfRecords);
            string actual = getCSVData.Invoke();
            Assert.AreEqual("Incorrect File Format!!!", actual);
        }

        /// <summary>
        /// Given the state code CSV file correct delimiter incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 2.4
        [Test]
        public void GivenStateCodeCSVFileCorrectDelimiterIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            CSVStates csvStates = new CSVStates(this.stateCodePath, this.wrongDelimiter);
            Console.WriteLine("CSVStates: " + csvStates.NumberOfRecords());
            GetCSVData getCSVData = new GetCSVData(csvStates.NumberOfRecords);
            string actual = getCSVData.Invoke();
            Assert.AreEqual("Delimiter Incorrect!!!", actual);
        }

        /// <summary>
        /// Given the state code CSV file correct CSV header incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 2.5
        [Test]
        public void GivenStateCodeCSVFileCorrectCSVHeaderIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            CSVStates csvStates = new CSVStates(this.stateCodePath, this.wrongCSVStateCodeHeader);
            Console.WriteLine("CSVStates: " + csvStates.NumberOfRecords());
            GetCSVData getCSVData = new GetCSVData(csvStates.NumberOfRecords);
            string actual = getCSVData.Invoke();
            Assert.AreEqual("CSV Header Incorrect !!!", csvStates.NumberOfRecords());
        }
    }
}