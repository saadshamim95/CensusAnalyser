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
        /// <param name="path">The path.</param>
        /// <returns>It returns number of Records</returns>
        /// <exception cref="CensusAnalyser.CustomException">File Not Found!!!</exception>
        public string NumberOfRecords(string path)
        {
            try
            {
                /*if (!CheckType(path))
                {
                    throw new CustomException("File Extension Incorrect!!!");
                }*/

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
                throw new CustomException("File Not Found!!!", CustomException.TypeOfException.FILE_NOT_FOUND);
            }

            /*catch (CustomException exception)
            {
                return exception.Message;
            }*/
        }

        /*public bool CheckType(string path)
        {
            char[] array = path.ToCharArray();
            int i = 0;
            bool flag=false;
            while (i < array.Length && flag != true)
            {
                if (array[i] == '.')
                {
                    flag = true;
                }
                i++;
            }
            string type = path.Substring(i, array.Length - i);
            //Console.WriteLine(type);
            if (type == "csv")
                return true;

            return false;
        }*/
    }
}