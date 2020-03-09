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
        /// The delimiter
        /// </summary>
        private char delimiter = ',';

        /// <summary>
        /// The CSV header
        /// </summary>
        private string csvHeader = "State,Population,AreaInSqKm,DensityPerSqKm";

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
        /// Initializes a new instance of the <see cref="CSVStateCensus"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="delimiter">The delimiter.</param>
        public CSVStateCensus(string path, char delimiter)
        {
            this.path = path;
            this.delimiter = delimiter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCensus"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="csvHeader">The CSV header.</param>
        public CSVStateCensus(string path, string csvHeader)
        {
            this.path = path;
            this.csvHeader = csvHeader;
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

                string[] records = File.ReadAllLines(this.path);
                string header = records[0];
                if (!header.Contains(this.delimiter))
                {
                    throw new CustomException("Delimiter Incorrect!!!", CustomException.TypeOfException.INCORRECT_DELIMITER);
                }

                if (header != this.csvHeader)
                {
                    throw new CustomException("CSV Header Incorrect !!!", CustomException.TypeOfException.INCORRECT_CSV_HEADER);
                }

                IEnumerable<string> csvArray = records;
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