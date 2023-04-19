using System.Security.Cryptography;

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
                sumX += DateTime.Now.Second;
                sumY += d.buy;
                sumXX += (float)Math.Pow(sumX, 2);
                sumXY += (float)DateTime.Now.Second * d.buy;
            }

            float alpha = 0.1f; // پارامتر رگولاریزیشن
            float slope = (n * sumXY - sumX * sumY + alpha * Math.Sign(sumX)) / (n * sumXX - sumX * sumX);
            float intercept = (sumY - slope * sumX) / n;
            var each_time = DateTime.Now.Second;
            var OutPut = slope * (data[data.Count - 1].makerCoefficient * each_time / each_time + 1) + intercept;
            return OutPut;
            
        }

        //متد پیش بینی3 جدید    
        public double AvaragePrediction3(List<double> information, double minValue, double maxValue)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] buffer = new byte[sizeof(double)];
                rng.GetBytes(buffer);
                double randomValue = (BitConverter.ToDouble(buffer, 0) - 0.5) * (maxValue - minValue) + (information[information.Count - 3] + information.Average()) / 2;
                return Math.Max(minValue, Math.Min(maxValue, randomValue));
            }
        }
    }
}
