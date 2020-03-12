using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class ObjectFactory : Factory
    {
        public override ICSVBuilder GetObject(string className, string path, char delimiter, string header)
        {
            switch (className)
            {
                case "CSVStateCensus":
                    return new CSVStateCensus(path, delimiter, header);
                case "CSVStates":
                    return new CSVStates(path, delimiter, header);
                default:
                    throw new ApplicationException(string.Format("Object of class {0} cannot be created", className));
            }
        }
    }
}