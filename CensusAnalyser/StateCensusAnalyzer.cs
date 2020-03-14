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
                            data.Add("Unknown");
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
        public void SortingCSVFile()
        {
            string[] lines = File.ReadAllLines(this.path);
            var data = lines.Skip(1);
            IEnumerable<string> query =
                from line in data
                let x = line.Split(',')
                orderby x[0]
                select line;
            File.WriteAllLines(@"C:\Users\ye10398\source\repos\saadshamim95\Census Analyser\CensusAnalyser\Data\SortedStateCensusData.csv", lines.Take(1).Concat(query.ToArray()));
        }

        /// <summary>Checks for state.</summary>
        /// <param name="jsonPath">The json path.</param>
        /// <param name="position">The position.</param>
        /// <param name="key">The key.</param>
        /// <returns>It returns string.</returns>
        public string CheckForState(string jsonPath,string position, string key)
        {
            var json = File.ReadAllText(jsonPath);
            var jsonObject = JObject.Parse(json);
            JArray jsonArray = (JArray)jsonObject["SortedStateCensusData"];
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
    }
}