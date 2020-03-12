//-----------------------------------------------------------------------
// <copyright file="CSVStateCensus.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    /// <summary>
    /// Class CSVStateCensus
    /// </summary>
    public class CSVStateCensus : ICSVBuilder
    {
        /// <summary>
        /// The path
        /// </summary>
        private string path;

        /// <summary>
        /// The delimiter
        /// </summary>
        private char delimiter;

        /// <summary>
        /// The CSV header
        /// </summary>
        private string csvHeader;

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
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="header">The header.</param>
        public CSVStateCensus(string path, char delimiter, string header)
        {
            this.path = path;
            this.delimiter = delimiter;
            this.csvHeader = header;
        }

        /// <summary>
        /// GetCSVData delegate
        /// </summary>
        /// <returns>It returns string</returns>
        public delegate string GetCSVData();

        /// <summary>
        /// Numbers the of records.
        /// </summary>
        /// <returns>It returns number of lines.</returns>
        public string NumberOfRecords()
        {
            try
            {
                CSVBuilder csvBuilder = new CSVBuilder(this.path, this.delimiter, this.csvHeader);
                this.path = csvBuilder.FilePath;
                this.delimiter = csvBuilder.Delimiter;
                this.csvHeader = csvBuilder.Header;

                string[] records = csvBuilder.Records;
                return records.Length.ToString();
            }
            catch (CustomException exception)
            {
                return exception.Message;
            }
        }
    }
}