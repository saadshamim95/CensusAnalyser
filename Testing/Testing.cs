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
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            CSVStateCensus csvStateCensus = new CSVStateCensus();
            Assert.AreEqual(stateCensusAnalyzer.NumberOfRecords(this.stateCensusDataPath), csvStateCensus.NumberOfRecords(this.stateCensusDataPath));
        }
    }
}