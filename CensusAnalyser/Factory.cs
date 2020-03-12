using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public abstract class Factory
    {
        public abstract ICSVBuilder GetObject(string className, string path, char delimiter, string header);
    }
}