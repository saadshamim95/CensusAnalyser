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
        /// The path
        /// </summary>
        private string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCensusAnalyzer"/> class.
        /// </summary>
        public StateCensusAnalyzer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCensusAnalyzer"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public StateCensusAnalyzer(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Numbers of records.
        /// </summary>
        /// <returns>It returns number of lines</returns>
        public string NumberOfRecords()
        {
            StreamReader streamReader = new StreamReader(this.path);
            int numberOfLines = 0;
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                numberOfLines++;
            }

            return numberOfLines.ToString();
        }
    }
}