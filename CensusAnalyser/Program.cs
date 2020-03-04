//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    using System;

    /// <summary>
    /// Class Program
    /// </summary>
    public class Program
    {
        private static readonly string path = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCensusData.csv";

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("************************************************************");
            Console.WriteLine("*                 WELCOME TO CENSUS ANALYSER               *");
            Console.WriteLine("************************************************************");

            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            stateCensusAnalyzer.NumberOfRecords(path);

            CSVStateCensus csvStateCensus = new CSVStateCensus();
            csvStateCensus.NumberOfRecords(path);
        }
    }
}