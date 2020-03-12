//-----------------------------------------------------------------------
// <copyright file="CSVBuilder.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    using System.IO;

    /// <summary>
    /// Class CSVBuilder
    /// </summary>
    public class CSVBuilder
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
        /// The records
        /// </summary>
        private string[] records;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVBuilder"/> class.
        /// </summary>
        public CSVBuilder()
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVBuilder"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="header">The header.</param>
        public CSVBuilder(string path, char delimiter, string header)
        {
            this.path = path;
            this.delimiter = delimiter;
            this.csvHeader = header;
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        /// <exception cref="CustomException">
        /// Incorrect File Format!!!
        /// or
        /// File Not Found!!!
        /// </exception>
        public string FilePath
        {
            get
            {
                try
                {
                    if (Path.GetExtension(this.path) != ".csv")
                    {
                        throw new CustomException("Incorrect File Format!!!", CustomException.TypeOfException.INCORRECT_FILE_FORMAT);
                    }

                    this.records = File.ReadAllLines(this.path);
                    return this.path;
                }
                catch (FileNotFoundException)
                {
                    throw new CustomException("File Not Found!!!", CustomException.TypeOfException.FILE_NOT_FOUND);
                }
                catch (CustomException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the delimiter.
        /// </summary>
        /// <value>
        /// The delimiter.
        /// </value>
        /// <exception cref="CustomException">Delimiter Incorrect!!!</exception>
        public char Delimiter
        {
            get 
            {
                try
                {
                    if (!this.records[0].Contains(this.delimiter))
                    {
                        throw new CustomException("Delimiter Incorrect!!!", CustomException.TypeOfException.INCORRECT_DELIMITER);
                    }

                    return this.delimiter;
                }
                catch (CustomException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        /// <exception cref="CustomException">CSV Header Incorrect !!!</exception>
        public string Header
        {
            get
            {
                try
                {
                    if (this.csvHeader != this.records[0])
                    {
                        throw new CustomException("CSV Header Incorrect !!!", CustomException.TypeOfException.INCORRECT_CSV_HEADER);
                    }

                    return this.csvHeader;
                }
                catch (CustomException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the records.
        /// </summary>
        /// <value>
        /// The records.
        /// </value>
        public string[] Records
        {
            get
            {
                return this.records;
            }
        }
    }
}