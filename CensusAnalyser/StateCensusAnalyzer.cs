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
        /// The delimiter
        /// </summary>
        private char delimiter = ',';

        /// <summary>
        /// The CSV header
        /// </summary>
        private string csvHeader = "State,Population,AreaInSqKm,DensityPerSqKm";

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
        /// Initializes a new instance of the <see cref="StateCensusAnalyzer"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="delimiter">The delimiter.</param>
        public StateCensusAnalyzer(string path, char delimiter)
        {
            this.path = path;
            this.delimiter = delimiter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCensusAnalyzer"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="csvHeader">The CSV header.</param>
        public StateCensusAnalyzer(string path, string csvHeader)
        {
            this.path = path;
            this.csvHeader = csvHeader;
        }

        /// <summary>
        /// Numbers the of records.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CensusAnalyser.CustomException">
        /// Incorrect File Format!!!
        /// or
        /// Delimiter Incorrect!!!
        /// or
        /// File Not Found!!!
        /// </exception>
        public string NumberOfRecords()
        {
            try
            {
                if (Path.GetExtension(this.path) != ".csv")
                {
                    throw new CustomException("Incorrect File Format!!!", CustomException.TypeOfException.INCORRECT_FILE_FORMAT);
                }

                StreamReader streamReader = new StreamReader(this.path);
                int numberOfLines = 0;
                string header;
                if (!(header = streamReader.ReadLine()).Contains(this.delimiter))
                {
                    throw new CustomException("Delimiter Incorrect!!!", CustomException.TypeOfException.INCORRECT_DELIMITER);
                }

                if (header != this.csvHeader)
                {
                    throw new CustomException("CSV Header Incorrect !!!", CustomException.TypeOfException.INCORRECT_CSV_HEADER);
                }
                string line;
                numberOfLines++;
                while ((line = streamReader.ReadLine()) != null)
                {
                    numberOfLines++;
                }

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

        /// <summary>
        /// Checks the type.
        /// </summary>
        /// <returns>It return true if file format is incorrect</returns>
        /*public bool CheckFileFormat()
        {
            *//*char[] array = this.path.ToCharArray();
            int i = 0;
            bool flag = false;
            while (i < array.Length && flag != true)
            {
                if (array[i] == '.')
                {
                    flag = true;
                }

                i++;
            }

            string type = this.path.Substring(i, array.Length - i);
            Console.WriteLine(type);
            if (type == "csv")
            {
                return true;
            }

            return false;*//*
            
            string[] array = new string[2];
            array = this.path.Split('.');
            Console.WriteLine(array[1]);
            if (array[1] == "csv")
            {
                return true;
            }
                
            return false;
        }*/
    }
}