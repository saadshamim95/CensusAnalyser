using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public interface IAdapter
    {
        public int SortingByInt(string path, int key);
    }
}
