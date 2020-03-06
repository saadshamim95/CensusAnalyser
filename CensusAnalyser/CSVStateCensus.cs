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
        /// The path
        /// </summary>
        private string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCensus"/> class.
        /// </summary>
        public CSVStateCensus()
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCensus"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public CSVStateCensus(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Numbers the of records.
        /// </summary>
        /// <returns>It returns number of lines</returns>
        public string NumberOfRecords()
        {
            try
            {
                if (Path.GetExtension(this.path) != ".csv")
                {
                    throw new CustomException("Incorrect File Format!!!", CustomException.TypeOfException.INCORRECT_FILE_FORMAT);
                }

                IEnumerable<string> csvArray = File.ReadAllLines(this.path);
                int numberOfLines = 0;
                foreach (var item in csvArray)
                {
                    numberOfLines++;
                }

                Console.WriteLine("Number of Lines: " + numberOfLines);
                return numberOfLines.ToString();
            }
            catch (FileNotFoundException)
            {
                throw new CustomException("File Not Found!!!", CustomException.TypeOfException.FILE_NOT_FOUND);
            }
            catch (CustomException exception)
            {
                return exception.Message;
            }
        }
    }
}