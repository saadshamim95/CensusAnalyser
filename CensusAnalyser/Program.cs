﻿//-----------------------------------------------------------------------
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
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("************************************************************");
            Console.WriteLine("*                 WELCOME TO CENSUS ANALYSER               *");
            Console.WriteLine("************************************************************");

            string csvUSDataPath = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\USCensusData.csv";
            string destination = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\SortedUSCensusData.csv";
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(csvUSDataPath);
            stateCensusAnalyzer.SortingCSVFile(destination,"descending",2);
            stateCensusAnalyzer.ConvertingCSVToJSON(destination, "USCensusData");
            //stateCensusAnalyzer.ConvertingCSVToJSON(@"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\SortedStateCensusData.csv", "StateCensusData");
            /*StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(@"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCensusData.csv");
            stateCensusAnalyzer.SortingCSVFile(destination, "descending", 1);
            stateCensusAnalyzer.ConvertingCSVToJSON(destination, "StateCensusData");*/
            //int count=stateCensusAnalyzer.SortingByInt(2);
            //Console.WriteLine(count);
            
        }
    }
}