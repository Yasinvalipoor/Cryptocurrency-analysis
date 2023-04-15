using Cryptocurrency_analysis.CreatFile;
using Cryptocurrency_analysis.DataCollector;
using Cryptocurrency_analysis.Predictor;
using Cryptocurrency_analysis.Smart_predictor;
using ConsoleTables;
using Cryptocurrency_analysis.ReadAPI;

List<double> Information_Price = new List<double>();
Prediction prediction = new Prediction();
SmartPrediction smartPrediction = new SmartPrediction();
DataCollector Collector = new DataCollector();
CreatFile creat = new CreatFile();


int count = 0;

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\n\n                                                       *       Hello to all those who want to use this program       *" +
"\n    ----- The details of the program are as follows: it reads the Bitcoin currency every few seconds,and finally, five methods predict the next rate, and you can see the rate in the next time slice. -----\n");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("\n \"Warning: due to the volatility of the Bitcoin exchange rate, this program cannot make a completely accurate prediction\"\n");
Console.WriteLine("\n \"Please make the page full screen\"\n\n  [Attention : Please wait a little bit (about one minute) because this program needs to get 100 data first and then predict ]\n");
Console.WriteLine("  ==> [ Important Attention : All the prices that are taken from the API are saved in a \"json file\" in the \"MyFolder_SavePrices folder\" on the (( \"desktop\" )) (: ] <== \n\n");
Console.ResetColor();


do
{

        ReadAPI.InitializeClient();
        var Info = await ReadAPI.Read_Url("https://api.kucoin.com/api/v1/market/stats?symbol=BTC-USDT");

        Information_Price.Add(Info.buy);// ادد کردن هر بار نرخ ارز در هر آپدیت , به لیست 

        Collector.AddData(Info);//ادد کردن به ماژول دریافت کننده و ذخیره کننده اطلاعات در لیستی از دیتا مدل

        smartPrediction.Add_New_Data(Collector.GetData());//متد فرستادن اطلاعات به ماژول پیش بینی پیشرفته






        if (Information_Price.Count > 100)
        {

            count++;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-\n\n");
            Console.ResetColor();


            /////
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"     This is slice {count} at {DateTime.Now.ToString("h:mm:ss")}");
            Console.ResetColor();
            /////


            /////
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n********** name is : {0} and price is {1} **********\n", Info.symbol, Info.buy);
            Console.ResetColor();
            /////

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("____________________________________________\n");
            Console.ResetColor();


            /////
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var RandomPrediction1 = prediction.RandomPrediction1(Information_Price);
            Console.WriteLine("(1) This is First Prediction (Random) : {0}", RandomPrediction1); // پیش بینی1 قیمت بعدی
            Console.ResetColor();
            /////

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("____________________________________________\n");
            Console.ResetColor();


            /////
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var AveragePrediction2 = prediction.AveragePrediction2(Information_Price);
            Console.WriteLine("(2) This is Second Prediction (Average) : {0}", AveragePrediction2); // پیش بینی2 قیمت بعدی
            Console.ResetColor();
            /////

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("____________________________________________\n");
            Console.ResetColor();


            /////
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var RandomPrediction3 = prediction.RandomPrediction3(RandomPrediction1, AveragePrediction2);
            Console.WriteLine($"(3) Prediction1 :{RandomPrediction1} _ Prediction2 :{AveragePrediction2} _ Third Prediction => {RandomPrediction3}"); // پیش بینی3 قیمت بعدی
            Console.ResetColor();
            ///// 

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("____________________________________________\n");
            Console.ResetColor();


            /////
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("(4) This is Liner_Regression (Regression) : {0}", smartPrediction.LinearRegressionPrediction());// پیش بینی4 قیمت بعدی
            Console.ResetColor();
            /////

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("____________________________________________\n");
            Console.ResetColor();

            //////
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("(5) This is Smart Avarage : {0} ", smartPrediction.SmartAvarage(AveragePrediction2, smartPrediction.LinearRegressionPrediction(), RandomPrediction3));// پیش بینی5 قیمت بعدی
            Console.ResetColor();
            //////


            //////
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("____________________________________________\n");
            Console.ResetColor();
            //////   


            //////
            var smart_avarage = smartPrediction.SmartAvarage(AveragePrediction2, smartPrediction.LinearRegressionPrediction(), RandomPrediction3);
            prediction.ValidatePrediction(Info.buy,/**/ RandomPrediction1,/**/ AveragePrediction2,/**/prediction.RandomPrediction3(RandomPrediction1, AveragePrediction2)/**/, smartPrediction.LinearRegressionPrediction()/**/, smart_avarage);// متد اعنبار صنجی پیش بینی ها + درصد اختلاف رشد یا سقوط ارز
                                                                                                                                                                                                                                                //////  



            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
            Console.ResetColor();

            Thread.Sleep(1000);
        }

        creat.Creat_File_All_Price(Information_Price);// متد اضافه کردن نرخ ارز در فایل json + ذخیره پوشه در دستکتاپ


} while (true);


