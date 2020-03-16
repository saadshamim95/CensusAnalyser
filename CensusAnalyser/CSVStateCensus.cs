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

                Dictionary<int, Dictionary<string, string>> keyValuePairs = new Dictionary<int, Dictionary<string, string>>();
                string[] headerKey = records[0].Split(',');
                Dictionary<string, string> map = null;
                int length = 1;
                for (int i = 1; i < records.Length; i++)
                {
                    string[] value = records[i].Split(',');
                    map = new Dictionary<string, string>();
                    for (int j = 0; j < value.Length; j++)
                    {
                        map.Add(headerKey[j], value[j]);
                    }

                    keyValuePairs.Add(length, map);
                    length++;
                }

                foreach (var i in keyValuePairs)
                {
                    Console.WriteLine(i.Key);
                    foreach (var j in i.Value)
                    {
                        Console.WriteLine(j.Key + " , " + j.Value);
                    }
                }

                return length.ToString();
            }
            catch (CustomException exception)
            {
                return exception.Message;
            }
        }
    }
}