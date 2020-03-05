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
        public string NumberOfRecords(string path)
        {
            try
            {
                StreamReader streamReader = new StreamReader(path);
                string line;
                int numberOfLines = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    numberOfLines++;
                }

                return numberOfLines.ToString();
            }
            catch (FileNotFoundException)
            {
                throw new CustomException("File Not Found!!!");
            }
        }
    }
}