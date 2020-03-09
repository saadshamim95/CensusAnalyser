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
    using System;

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
            CSVStateCensus csvStateCensus = new CSVStateCensus(this.stateCensusDataPath);
            Assert.AreEqual(csvStateCensus.NumberOfRecords(), stateCensusAnalyzer.NumberOfRecords());
        }

        /// <summary>
        /// Given the state census CSV file incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 1.2
        //[Test]
        //public void GivenStateCensusCSVFileIncorrect_WhenAnalyze_ReturnsCustomException()
        //{
        //    StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(this.wrongFileName);
        //    CustomException ex1 = Assert.Throws<CustomException>(() => stateCensusAnalyzer.NumberOfRecords());
        //    CSVStateCensus csvStateCensus = new CSVStateCensus(this.wrongFileName);
        //    CustomException ex2 = Assert.Throws<CustomException>(() => csvStateCensus.NumberOfRecords());
        //    Console.WriteLine("Ex1: " + ex1.Message);
        //    Console.WriteLine("Ex2: " + ex2.Message);
        //    Assert.AreEqual(ex1.Message, ex2.Message);
        //}

        ///// <summary>
        ///// Given the state census CSV file correct type incorrect when analyze returns custom exception.
        ///// </summary>
        ////// Test Case 1.3
        //[Test]
        //public void GivenStateCensusCSVFileCorrectTypeIncorrect_WhenAnalyze_ReturnsCustomException()
        //{
        //    StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(this.wrongFileType);
        //    CSVStateCensus csvStateCensus = new CSVStateCensus(this.wrongFileType);
        //    Console.WriteLine("StateCensusAnalyzer: " + stateCensusAnalyzer.NumberOfRecords());
        //    Console.WriteLine("CSVStateCensus: " + csvStateCensus.NumberOfRecords());
        //    Assert.AreEqual(stateCensusAnalyzer.NumberOfRecords(), csvStateCensus.NumberOfRecords());
        //}

        ///// <summary>
        ///// Given the state census CSV file correct delimiter incorrect when analyze returns custom exception.
        ///// </summary>
        ////// Test Case 1.4
        //[Test]
        //public void GivenStateCensusCSVFileCorrectDelimiterIncorrect_WhenAnalyze_ReturnsCustomException()
        //{
        //    StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(this.stateCensusDataPath, '.');
        //    CSVStateCensus csvStateCensus = new CSVStateCensus(this.stateCensusDataPath, '.');
        //    Console.WriteLine("StateCensusAnalyzer: " + stateCensusAnalyzer.NumberOfRecords());
        //    Console.WriteLine("CSVStateCensus: " + csvStateCensus.NumberOfRecords());
        //    Assert.AreEqual(stateCensusAnalyzer.NumberOfRecords(), csvStateCensus.NumberOfRecords());
        //}

        ///// <summary>
        ///// Given the state census CSV file correct CSV header incorrect when analyze returns custom exception.
        ///// </summary>
        ////// Test Case 1.5
        //[Test]
        //public void GivenStateCensusCSVFileCorrectCSVHeaderIncorrect_WhenAnalyze_ReturnsCustomException()
        //{
        //    StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(this.stateCensusDataPath, this.csvHeader);
        //    CSVStateCensus csvStateCensus = new CSVStateCensus(this.stateCensusDataPath, this.csvHeader);
        //    Console.WriteLine("StateCensusAnalyzer: " + stateCensusAnalyzer.NumberOfRecords());
        //    Console.WriteLine("CSVStateCensus: " + csvStateCensus.NumberOfRecords());
        //    Assert.AreEqual(stateCensusAnalyzer.NumberOfRecords(), csvStateCensus.NumberOfRecords());
        //}
    }
}