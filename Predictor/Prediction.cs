using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;


namespace Cryptocurrency_analysis.Predictor
{
    internal class Prediction
    {

        //متد پیش بینی1   
        public double RandomPrediction1(List<double> Information)
        {
            Random random = new Random();
            return Information[Information.Count - 1] + (double)random.NextDouble() * 10 - 5;
        }


        //متد پیش بینی2   
        public double AveragePrediction2(List<double> Information)
        {
            return Information.Average();
        }



        //متد پیش بینی3   
        public double RandomPrediction3(double RandomPrediction1, double AveragePrediction2)
        {
            Random random = new Random();

            int pre1 = Convert.ToInt32(RandomPrediction1);
            int pre2 = Convert.ToInt32(AveragePrediction2);
            if (pre1 > pre2)
            {
                int new_rnd = random.Next(pre2, pre1);
                return new_rnd;

            }
            else
            {
                int new_rnd = random.Next(pre1, pre2);
                return new_rnd;

            }




        }


        //متد صحت سنجی پیش بینی ها
        public void ValidatePrediction(double Information_Price, double RandomPrediction1, double AveragePrediction2, double RandomPrediction3, double smart_pre, double SmartAvarage)
        {

            double Price = Information_Price;
            double pre1 = RandomPrediction1;
            double pre2 = AveragePrediction2;
            double pre3 = RandomPrediction3;
            double pre4 = smart_pre;
            double pre5 = SmartAvarage;

            List<double> LPrice = new List<double>();
            var table = new ConsoleTable("                 << Details Of Accuracy Differences And Percentage Difference >>                 ");

            /////////

            if (Price - pre1 > 0)
            {
                var Price1 = Price - pre1;
                var Percentage_Difference = (Price1 * 100) / Price;
                table.AddRow($"1) Price - Random1 :  {Price1}  ___  Percentage Difference  : - {Percentage_Difference} % decrease");
                LPrice.Add(Price1);
            }
            else
            {
                var Price1 = Price - pre1;
                var Percentage_Difference = ((pre1 - Price) * 100) / Price;
                table.AddRow($"1) Price - Random1 :  {Price1}  ___  Percentage Difference  :  {Percentage_Difference} % increase");

            }

            /////////

            if (Price - pre2 > 0)
            {
                var Price2 = Price - pre2;
                var Percentage_Difference = (Price2 * 100) / Price;
                table.AddRow($"2) Price - Average :  {Price2}  ___  Percentage Difference  : - {Percentage_Difference} % decrease");
                LPrice.Add(Price2);
            }
            else
            {
                var Price2 = Price - pre2;
                var Percentage_Difference = ((pre2 - Price) * 100) / Price;
                table.AddRow($"2) Price - Average :  {Price2}  ___  Percentage Difference  :  {Percentage_Difference} % increase");

            }

            /////////

            if (Price - pre3 > 0)
            {
                var Price3 = Price - pre3;
                var Percentage_Difference = (Price3 * 100) / Price;
                table.AddRow($"3) Price - Random2 :  {Price3}  ___  Percentage Difference  : - {Percentage_Difference} % decrease");
                LPrice.Add(Price3);
            }
            else
            {
                var Price3 = Price - pre3;
                var Percentage_Difference = ((pre3 - Price) * 100) / Price;
                table.AddRow($"3) Price - Random2 :  {Price3}  ___  Percentage Difference  :  {Percentage_Difference} % increase");

            }

            /////////

            if (Price - pre4 > 0)
            {
                var Price4 = Price - pre4;
                var Percentage_Difference = (Price4 * 100) / Price;
                table.AddRow($"4) Price - Regression :  {Price4}  ___  Percentage Difference  : - {Percentage_Difference} % decrease");
                LPrice.Add(Price4);
            }
            else
            {
                var Price4 = Price - pre4;
                var Percentage_Difference = ((pre4 - Price) * 100) / Price;
                table.AddRow($"4) Price - Regression :  {Price4}  ___  Percentage Difference  :  {Percentage_Difference} % increase");

            }

            ////////////

            if (Price - pre5 > 0)
            {
                var Price5 = Price - pre5;
                var Percentage_Difference = (Price5 * 100) / Price;
                table.AddRow($"5) Price - SmartAvarage :  {Price5}  ___  Percentage Difference  : - {Percentage_Difference} % decrease");
                LPrice.Add(Price5);
            }
            else
            {
                var Price5 = Price - pre5;
                var Percentage_Difference = ((pre5 - Price) * 100) / Price;
                table.AddRow($"5) Price - SmartAvarage :  {Price5}  ___  Percentage Difference  :  {Percentage_Difference} % increase");

            }

            ////////////

            Console.WriteLine(table.ToStringAlternative());


            if (LPrice.Count > 0)
            {
                double min = LPrice.Min();
                double max = LPrice.Max();

                ////////

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n<<< This section tells which forecast has less difference and is more accurate >>>\n\n [Attention : Small difference = more accurate ]\n");
                Console.ResetColor();

                ///////


                if (min + pre1 == Price)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" The Smallest difference Is : {min} And It's For \"First Prediction\" ");
                    Console.ResetColor();
                }
                if (min + pre2 == Price)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" The Smallest difference Is : {min} And It's For \"Second Prediction\" ");
                    Console.ResetColor();
                }
                if (min + pre3 == Price)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" The Smallest difference Is : {min} And It's For \"Third Prediction\" ");
                    Console.ResetColor();
                }
                if (min + pre4 == Price)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" The Smallest difference Is : {min} And It's For \"Liner_Regression\" ");
                    Console.ResetColor();
                }
                if (min + pre5 == Price)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" The Smallest difference Is : {min} And It's For \"Smart_Avarage\" ");
                    Console.ResetColor();
                }

                ////////

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" The Biggest difference Is : {max}\n");
                Console.ResetColor();

            }
        }
    }
}

