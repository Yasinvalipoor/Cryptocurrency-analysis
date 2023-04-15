using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_analysis.DataCollector
{
    internal class DataCollector
    {
        private List<DataModel.DataModel> data = new List<DataModel.DataModel>();

        public void AddData(DataModel.DataModel newData)
        {
            data.Add(newData);
        }

        public List<DataModel.DataModel> GetData()
        {
            return data;

        }
    }
}
