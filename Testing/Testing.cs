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
    using System.IO;

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

        private readonly string wrongFile = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCensusDat.csv";

        StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();

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
            Assert.AreEqual(stateCensusAnalyzer.NumberOfRecords(this.stateCensusDataPath), "30");
        }

        /// <summary>
        /// Given the state census CSV file incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 1.2
        [Test]
        public void GivenStateCensusCSVFileIncorrect_WhenAnalyze_ReturnsCustomException()
        {
            CustomException ex=Assert.Throws<CustomException>(()=>stateCensusAnalyzer.NumberOfRecords(this.wrongFile));
            Assert.That(ex.Message, Is.EqualTo("File Not Found!!!"));
        }
    }
}