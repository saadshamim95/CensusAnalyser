//-----------------------------------------------------------------------
// <copyright file="StateCensusAnalyzer.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using ChoETL;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Class StateCensusAnalyzer
    /// </summary>
    public class StateCensusAnalyzer : IAdapter
    {
        /// <summary>
        /// The path
        /// </summary>
        private string path;

        /// <summary>
        /// The header
        /// </summary>
        private string header = "SrNo,StateName,TIN,StateCode,Population,AreaInSqKm,DensityPerSqKm";

        /// <summary>
        /// The path1
        /// </summary>
        private string path1 = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCensusData.csv";

        /// <summary>
        /// The path2
        /// </summary>
        private string path2 = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\StateCode.csv";

        /// <summary>
        /// The merge file
        /// </summary>
        private string merge_file = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\IndianCensusData.csv";

        /// <summary>
        /// The count
        /// </summary>
        private int count = 0;

        /// <summary>
        /// The line
        /// </summary>
        List<string> line = new List<string>();

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

        /// <summary>
        /// Creates the JSON.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void CreateJSON(string fileName)
        {
            string jsonPath = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\Sorted" + fileName + ".json";
            string print = "{\n" +
                "'" + fileName + "':[\n" +
                "]\n" +
                "}";
            var record = JObject.Parse(print);
            string jsonResult = JsonConvert.SerializeObject(record, Formatting.Indented);
            File.WriteAllText(jsonPath, jsonResult);
        }

        /// <summary>
        /// Converting the CSV to JSON.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="fileName">Name of the file.</param>
        public void ConvertingCSVToJSON(string path, string fileName)
        {
            string jsonPath = @"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\Sorted" + fileName + ".json";
            if (File.Exists(jsonPath))
            {
                return;
            }

            this.CreateJSON(fileName);
            string[] csvData = File.ReadAllLines(path);

            string header = csvData[0];
            string[] heading = header.Split(',');
            int count = 0;

            var json = File.ReadAllText(jsonPath);
            var jsonObject = JObject.Parse(json);
            JArray jsonArray = (JArray)jsonObject[fileName];
            foreach (var item in csvData)    
            {
                if (count != 0)
                {
                    var data = new List<string>();
                    data = item.Split(',').ToList<string>();
                    if (data.Count < heading.Length)
                    {
                        while (data.Count != heading.Length)
                        {
                            data.Add("0");
                        }
                    }

                    StringBuilder record = new StringBuilder("{'");
                    for (int i = 0; i < heading.Length; i++)
                    {
                        record = record.Append(heading[i] + "': '" + data[i] + "','");
                    }

                    record = record.Remove(record.Length - 3, 3).Append("'}");
                    var recordJson = JObject.Parse(record.ToString());
                    jsonArray.Add(recordJson);
                }

                count++;
            }

            jsonObject[fileName] = jsonArray;
            string newJsonResult = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            File.WriteAllText(jsonPath, newJsonResult);
        }

        /// <summary>
        /// Sorts the CSV file.
        /// </summary>
        public void SortingCSVFile(string destination,string name, int key)
        {
            string[] lines = File.ReadAllLines(this.path);
            var data = lines.Skip(1);
            IEnumerable<string> query = null;
            if (name == "ascending")
            {
                query = from line in data
                        let x = line.Split(',')
                        orderby x[key]
                        select line;
            }

            if (name == "descending") {
                query = from line in data
                        let x = line.Split(',')
                        orderby x[key].ToInt32() descending 
                        select line;
            }

            File.WriteAllLines(destination, lines.Take(1).Concat(query.ToArray()));
        }

        /// <summary>Checks for state.</summary>
        /// <param name="jsonPath">The json path.</param>
        /// <param name="position">The position.</param>
        /// <param name="key">The key.</param>
        /// <returns>It returns string.</returns>
        public string CheckForState(string jsonPath,string position, string key, string array)
        {
            var json = File.ReadAllText(jsonPath);
            var jsonObject = JObject.Parse(json);
            JArray jsonArray = (JArray)jsonObject[array];
            if (position == "First")
            {
                return jsonArray[0][key].ToString();
            }

            if (position == "Last")
            {
                return jsonArray[jsonArray.Count - 1][key].ToString();
            }

            return null;
        }

        /// <summary>
        /// Sortings the by int.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public int SortingByInt(string path, int key)
        {
            string[] temp;
            string[] lines = File.ReadAllLines(path);
            int[] record = new int[lines.Length];
            int k = 0;
            int value = 0;
            foreach (var i in lines)
            {
                temp = i.Split(',');
                record[k] = (int)temp[key].ToInt32();
                k++;
            }
            for (var i = 1; i < lines.Length; i++)
            {
                for (var j = i + 1; j < lines.Length; j++)
                {
                    if (record[i] > (record[j]))
                    {
                        int t = record[i];
                        record[i] = record[j];
                        record[j] = t;
                        value++;
                    }
                }
            }
            return value;
        }

        /// <summary>
        /// Combines the CSV file.
        /// </summary>
        public void CombineCsvFile()
        {
            //  string[] lines = File.ReadAllLines(path);
            line.Add(header);
            string[] csvFile2 = File.ReadAllLines(path2);
            string[] csvFile1 = File.ReadAllLines(path1);
            for (int i = 1; i < csvFile2.Length; i++)
            {
                count = 0;
                string[] readCsvFile2 = csvFile2[i].Split(',');

                for (int j = 1; j < csvFile1.Length; j++)
                {
                    string[] readCsvFile1 = csvFile1[j].Split(',');

                    merge(csvFile2[i], csvFile1[j], readCsvFile1, readCsvFile2);
                }

                if (count == 0)
                {
                    // It adds new State that is not common
                    // in both csv file;
                    string add = String.Concat(csvFile2[i]);
                    line.Add(add);
                    //File.WriteAllLines(merge_file, line);
                }

                File.WriteAllLines(merge_file, line);
            }
            Console.WriteLine(" ");
        }

        /// <summary>
        /// It will merge the two csv file
        /// with state name
        /// Merges the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="census">The census.</param>
        /// <param name="lines_code">The lines code.</param>
        /// <param name="lines_census">The lines census.</param>
        public void merge(string _code, string _census, string[] readStateCode, string[] readStateCensus)
        {
            if (readStateCode[0] == readStateCensus[1])
            {
                int indexCount = _census.IndexOf(",");
                string StartIndex = _census.Substring(indexCount);
                string concat = String.Concat(_code, StartIndex);
                line.Add(concat);
                count = 1;
            }
            //File.WriteAllLines(merge_file, line);
        }
    }
}