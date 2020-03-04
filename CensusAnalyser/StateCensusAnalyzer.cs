//-----------------------------------------------------------------------
// <copyright file="StateCensusAnalyzer.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    using System;
    using System.IO;

    /// <summary>
    /// Class StateCensusAnalyzer
    /// </summary>
    public class StateCensusAnalyzer
    {
        /// <summary>
        /// Numbers the of records.
        /// </summary>
        /// <returns>It returns number of lines</returns>
        public int NumberOfRecords(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            string line;
            int numberOfLines = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                numberOfLines++;
            }

            Console.WriteLine("Number of lines: " + numberOfLines);
            return numberOfLines;
        }
    }
}