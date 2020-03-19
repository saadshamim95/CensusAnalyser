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
        /// The delimiter
        /// </summary>
        private readonly char delimiter = ',';

        /// <summary>
        /// The wrong delimiter
        /// </summary>
        private readonly char wrongDelimiter = '.';

        /// <summary>
        /// The CSV state census header
        /// </summary>
        private readonly string csvStateCensusHeader = "State,Population,AreaInSqKm,DensityPerSqKm";

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
        private readonly string csvStateCodeHeader = "SrNo,StateName,TIN,StateCode";

        /// <summary>
        /// The CSV state code header
        /// </summary>
        private readonly string wrongCSVStateCodeHeader = "SrNo,State,Name,TIN,StateCod";

        /// <summary>
        /// The JSON state census path
        /// </summary>
        private readonly string jsonStateCensusPath = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\SortedStateCensusData.json";

        /// <summary>
        /// The JSON state code path
        /// </summary>
        private readonly string jsonStateCodePath = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\SortedStateCode.json";

        //private readonly string  = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCensusData.csv";

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
            Factory factory = new ObjectFactory();
            ICSVBuilder csvStateCensus = factory.GetObject("CSVStateCensus", this.stateCensusDataPath, this.delimiter, this.csvStateCensusHeader);
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
            Factory factory = new ObjectFactory();
            ICSVBuilder csvStateCensus = factory.GetObject("CSVStateCensus", this.wrongStateCensusFileName, this.delimiter, this.csvStateCensusHeader);
            GetCSVData getCSVData = new GetCSVData(csvStateCensus.NumberOfRecords);
            string actual = getCSVData.Invoke();
            Assert.AreEqual("File Not Found!!!", actual);
        }

        /// <summary>
        /// Given the state census CSV file correct type incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 1.3
        [Test]
        public void GivenStateCensusCSVFileCorrectTypeIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            Factory factory = new ObjectFactory();
            ICSVBuilder csvStateCensus = factory.GetObject("CSVStateCensus", this.wrongStateCensusFileType, this.delimiter, this.csvStateCensusHeader);
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
            Factory factory = new ObjectFactory();
            ICSVBuilder csvStateCensus = factory.GetObject("CSVStateCensus", this.stateCensusDataPath, this.wrongDelimiter, this.csvStateCensusHeader);
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
            Factory factory = new ObjectFactory();
            ICSVBuilder csvStateCensus = factory.GetObject("CSVStateCensus", this.stateCensusDataPath, this.delimiter, this.wrongCSVStateCensusHeader);
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
            Factory factory = new ObjectFactory();
            ICSVBuilder csvStates = factory.GetObject("CSVStateCensus", this.stateCodePath, this.delimiter, this.csvStateCodeHeader);
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
            Factory factory = new ObjectFactory();
            ICSVBuilder csvStates = factory.GetObject("CSVStateCensus", this.wrongStateCodeFileName, this.delimiter, this.csvStateCodeHeader);
            GetCSVData getCSVData = new GetCSVData(csvStates.NumberOfRecords);
            string actual = getCSVData.Invoke();
            Assert.AreEqual("File Not Found!!!", actual);
        }

        /// <summary>
        /// Given the state code CSV file correct type incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 2.3
        [Test]
        public void GivenStateCodeCSVFileCorrectTypeIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            Factory factory = new ObjectFactory();
            ICSVBuilder csvStates = factory.GetObject("CSVStateCensus", this.wrongStateCodeFileType, this.delimiter, this.csvStateCodeHeader);
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
            Factory factory = new ObjectFactory();
            ICSVBuilder csvStates = factory.GetObject("CSVStateCensus", this.stateCodePath, this.wrongDelimiter, this.csvStateCodeHeader);
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
            Factory factory = new ObjectFactory();
            ICSVBuilder csvStates = factory.GetObject("CSVStateCensus", this.stateCodePath, this.delimiter, this.wrongCSVStateCodeHeader);
            Console.WriteLine("CSVStates: " + csvStates.NumberOfRecords());
            GetCSVData getCSVData = new GetCSVData(csvStates.NumberOfRecords);
            string actual = getCSVData.Invoke();
            Assert.AreEqual("CSV Header Incorrect !!!", csvStates.NumberOfRecords());
        }

        /// <summary>
        /// Given the CSV state census analyzer check start state when analyze should match.
        /// </summary>
        //// Test Case 3.1
        [Test]
        public void GivenCSVStateCensusAnalyzerCheckStartState_WhenAnalyze_ShouldMatch()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            string actual = stateCensusAnalyzer.CheckForState(this.jsonStateCensusPath, "First", "State", "StateCensusData");
            Assert.AreEqual("Andhra Pradesh", actual);
        }

        /// <summary>
        /// Given the CSV state census analyzer check end state when analyze should match.
        /// </summary>
        //// Test Case 3.2
        [Test]
        public void GivenCSVStateCensusAnalyzerCheckEndState_WhenAnalyze_ShouldMatch()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            string actual = stateCensusAnalyzer.CheckForState(this.jsonStateCensusPath, "Last", "State", "StateCensusData");
            Assert.AreEqual("West Bengal", actual);
        }

        /// <summary>
        /// Given the CSV state code check start state when analyze should match.
        /// </summary>
        //// Test Case 4.1
        [Test]
        public void GivenCSVStateCodeCheckStartState_WhenAnalyze_ShouldMatch()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            string actual = stateCensusAnalyzer.CheckForState(this.jsonStateCodePath, "First", "StateName", "StateCode");
            Assert.AreEqual("Andhra Pradesh New", actual);
        }

        /// <summary>
        /// Given the CSV state code check end state when analyze should match.
        /// </summary>
        //// Test Case 4.2
        [Test]
        public void GivenCSVStateCodeCheckEndState_WhenAnalyze_ShouldMatch()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            string actual = stateCensusAnalyzer.CheckForState(this.jsonStateCodePath, "Last", "StateName", "StateCode");
            Assert.AreEqual("West Bengal", actual);
        }

        /// <summary>
        /// Givens the state census data in json from most populous to least when analyse return number of states sorted.
        /// </summary>
        [Test]
        public void GivenStateCensusDataInJsonFromMostPopulousToLeast_WhenAnalyse_ReturnNumberOfStatesSorted()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            int actual = stateCensusAnalyzer.SortingByInt(stateCensusDataPath, 1);
            Assert.AreEqual(406, actual);
        }

        /// <summary>
        /// Givens the state census data in json from most density to least when analyse return number of states sorted.
        /// </summary>
        [Test]
        public void GivenStateCensusDataInJsonFromMostDensityToLeast_WhenAnalyse_ReturnNumberOfStatesSorted()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            int actual = stateCensusAnalyzer.SortingByInt(stateCensusDataPath, 3);
            Assert.AreEqual(294, actual);
        }

        /// <summary>
        /// Givens the state census data in json from largest state to smallest when analyse return number of states sorted.
        /// </summary>
        [Test]
        public void GivenStateCensusDataInJsonFromLargestStateToSmallest_WhenAnalyse_ReturnNumberOfStatesSorted()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            int actual = stateCensusAnalyzer.SortingByInt(stateCensusDataPath, 2);
            Assert.AreEqual(336, actual);
        }
    }
}