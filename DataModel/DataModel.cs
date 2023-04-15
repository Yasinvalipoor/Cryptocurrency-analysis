using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_analysis.DataModel
{
    internal class DataModel
    {
        public string symbol { get; set; }
        public float buy { get; set; }
        public float makerCoefficient { get; set; }
    }
}
