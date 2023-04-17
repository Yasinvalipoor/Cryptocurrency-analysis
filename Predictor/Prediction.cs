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
        public double Random_Range(double RandomPrediction1, double AveragePrediction2)
        {
            Random random = new Random();
            List<int> avarage = new List<int>();
            int pre1 = (int)RandomPrediction1;
            int pre2 = (int)AveragePrediction2;
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
        public void ValidatePredictions(double Information_Price, double RandomPrediction1, double RandomPrediction2, double AveragePrediction3, double smart_reg)
        {

            double Price = Information_Price;
            double pre1 = RandomPrediction1;
            double pre2 = RandomPrediction2;
            double pre3 = AveragePrediction3;
            double pre4 = smart_reg;

            List<double> Pos_Price = new List<double>();//نرخ های مثبت
            List<double> Neg_Price = new List<double>();//نرح های منفی
            var table = new ConsoleTable("                 << Details Of Accuracy Differences And Percentage Difference >>                 ");

            /////////

            if (Price - pre1 > 0)
            {
                var Price1 = Price - pre1;
                var Percentage_Difference = (Price1 * 100) / Price;
                table.AddRow($"1) Price - Random1 :  {Price1}  ___  Percentage Difference  : - {Percentage_Difference} % decrease");
                Pos_Price.Add(Price1);
            }
            else
            {
                var Price1 = Price - pre1;
                var Percentage_Difference = ((pre1 - Price) * 100) / Price;
                table.AddRow($"1) Price - Random1 :  {Price1}  ___  Percentage Difference  :  {Percentage_Difference} % increase");
                Neg_Price.Add(Price1);

            }

            /////////

            if (Price - pre2 > 0)
            {

                var Price2 = Price - pre2;
                var Percentage_Difference = (Price2 * 100) / Price;
                table.AddRow($"2) Price - Random2 :  {Price2}  ___  Percentage Difference  : - {Percentage_Difference} % decrease");
                Pos_Price.Add(Price2);

            }
            else
            {
                var Price2 = Price - pre2;
                var Percentage_Difference = ((pre2 - Price) * 100) / Price;
                table.AddRow($"2) Price - Random2 :  {Price2}  ___  Percentage Difference  :  {Percentage_Difference} % increase");
                Neg_Price.Add(Price2);

            }

            /////////

            if (Price - pre3 >= 0)
            {
                var Price3 = Price - pre3;
                var Percentage_Difference = (Price3 * 100) / Price;
                table.AddRow($"3) Price - Average :  {Price3}  ___  Percentage Difference  : - {Percentage_Difference} % decrease");
                Pos_Price.Add(Price3);
            }
            else
            {
                var Price3 = Price - pre3;
                var Percentage_Difference = ((pre3 - Price) * 100) / Price;
                table.AddRow($"3) Price - Average :  {Price3}  ___  Percentage Difference  :  {Percentage_Difference} % increase");
                Neg_Price.Add(Price3);

            }

            /////////

            if (Price - pre4 >= 0)
            {
                var Price4 = Price - pre4;
                var Percentage_Difference = (Price4 * 100) / Price;
                table.AddRow($"4) Price - Regression :  {Price4}  ___  Percentage Difference  : - {Percentage_Difference} % decrease");
                Pos_Price.Add(Price4);
            }
            else
            {
                var Price4 = Price - pre4;
                var Percentage_Difference = ((pre4 - Price) * 100) / Price4;
                table.AddRow($"4) Price - Regression :  {Price4}  ___  Percentage Difference  :  {Percentage_Difference} % increase");
                Neg_Price.Add(Price4);

            }


            ////////////

            Console.WriteLine(table.ToStringAlternative());


            if (Pos_Price.Count > 0)
            {
                double Pmin = Pos_Price.Min();
                double Pmax = Pos_Price.Max();

                ////////

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n<<< This section tells which forecast has less difference and is more accurate >>>\n\n [Attention : Small difference = more accurate ]\n");
                Console.ResetColor();

                ///////


                if (Pmin + pre1 == Price)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" The Smallest in Positive difference Is : {Pmin} And It's For \"First Prediction\" ");
                    Console.ResetColor();
                }
                if (Pmin + pre2 == Price)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" The Smallest in Positive difference Is : {Pmin} And It's For \"Second Prediction\" ");
                    Console.ResetColor();
                }
                if (Pmin + pre3 == Price)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" The Smallest in Positive difference Is : {Pmin} And It's For \"Rng_Prediction\" ");
                    Console.ResetColor();
                }
                if (Pmin + pre4 == Price)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" The Smallest in Positive difference Is : {Pmin} And It's For \"Liner_Regression\" ");
                    Console.ResetColor();
                }



                if (Neg_Price.Count > 0)
                {
                    double Nmin = Neg_Price.Max();

                    if (Nmin + pre1 == Price)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($" The Smallest in Negative difference Is : {Nmin} And It's For \"First Prediction\" ");
                        Console.ResetColor();
                    }
                    if (Nmin + pre2 == Price)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($" The Smallest in Negative difference Is : {Nmin} And It's For \"Second Prediction\" ");
                        Console.ResetColor();
                    }
                    if (Nmin + pre3 == Price)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($" The Smalles in Negativet difference Is : {Nmin} And It's For \"Rng_Prediction\" ");
                        Console.ResetColor();
                    }
                    if (Nmin + pre4 == Price)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($" The Smallest in Negative difference Is : {Nmin} And It's For \"Liner_Regression\" ");
                        Console.ResetColor();
                    }

                    ////////

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" The Biggest difference Is : {Pmax}\n");
                    Console.ResetColor();

                }
            }
        }
    }
}

