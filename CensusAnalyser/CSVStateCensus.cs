//-----------------------------------------------------------------------
// <copyright file="CSVStateCensus.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Class CSVStateCensus
    /// </summary>
    public class CSVStateCensus
    {
        /// <summary>
        /// Gets the CSV data.
        /// </summary>
        /// <returns>returns CSV Data</returns>
        public IEnumerable<string> GetCSVData(string path)
        {
            string[] csvData = File.ReadAllLines(path);
            return csvData;
        }

        /// <summary>
        /// Numbers the of records.
        /// </summary>
        /// <returns>It returns number of lines</returns>
        public string NumberOfRecords(string path)
        {
            IEnumerable<string> csvArray = this.GetCSVData(path);
            int numberOfLines = 0;
            foreach (var item in csvArray)
            {
                numberOfLines++;
            }

            //Console.WriteLine("Number of Lines: " + numberOfLines);
            return numberOfLines.ToString();
        }
    }
}