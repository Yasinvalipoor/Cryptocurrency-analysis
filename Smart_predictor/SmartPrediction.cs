using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_analysis.Smart_predictor
{
    internal class SmartPrediction
    {
        //متد پیش بینی 4
        //پیش بینی با استفاده از رگرسیون خطی
        private List<DataModel.DataModel> data = new List<DataModel.DataModel>();
        public void Add_New_Data(List<DataModel.DataModel> NewData)
        {
            data.AddRange(NewData);

        }
        public float LinearRegressionPrediction()
        {
            float sumX = 0, sumY = 0, sumXX = 0, sumXY = 0;
            int n = data.Count;
            foreach (DataModel.DataModel d in data)
            {
                sumX += DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
                sumY += d.buy;
                sumXX += (float)Math.Pow(DateTime.Now.Ticks / TimeSpan.TicksPerSecond, 2);
                sumXY += (float)DateTime.Now.Ticks / TimeSpan.TicksPerSecond * d.buy;
            }
            var time = DateTime.Now.Ticks;
            float slope = (n * sumXY - sumX * sumY) / (n * sumXX - sumX * sumX);
            float intercept = (sumY - slope * sumX) / n;
            var OutPut = slope * (data[data.Count - 1].makerCoefficient * time / TimeSpan.TicksPerSecond + 1) + intercept;
            return OutPut;
        }

        //متد پیش بینی5  
        public double SmartAvarage(double avarage1, double regresion, double random2)
        {
            List<double> FinalOutput = new List<double>();
            FinalOutput.Add(avarage1);
            FinalOutput.Add(regresion);
            FinalOutput.Add(Convert.ToDouble(random2));
            return FinalOutput.Average();

        }
    }
}
