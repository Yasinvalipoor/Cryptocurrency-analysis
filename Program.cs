using Cryptocurrency_analysis.CreatFile;
using Cryptocurrency_analysis.DataCollector;
using Cryptocurrency_analysis.Predictor;
using Cryptocurrency_analysis.ReadAPI;
using Cryptocurrency_analysis.Smart_predictor;

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
Console.WriteLine("\n \"Warning: due to the volatility of the Bitcoin exchange rate, this program cannot make a completely accurate prediction\"");
Console.WriteLine("\n \"Please make the page full screen\"\n\n  [Attention : Please wait a little bit (about one minute) because this program needs to get 100 data first and then predict ]\n");
Console.WriteLine("  ==> [ Important Attention : All the prices that are taken from the API are saved in a \"json file\" in the \"MyFolder_SavePrices folder\" on the (( \"desktop\" )) (: ] <== \n\n");
Console.ResetColor();


do
{
    try
    {
        ReadAPI.InitializeClient();
        var Info = await ReadAPI.Read_Url("https://api.kucoin.com/api/v1/market/stats?symbol=BTC-USDT");

        Information_Price.Add(Info.buy);// ادد کردن هر بار نرخ ارز در هر آپدیت , به لیست 

        Collector.AddData(Info);//ادد کردن به ماژول دریافت کننده و ذخیره کننده اطلاعات در لیستی از دیتا مدل

        smartPrediction.Add_New_Data(Collector.GetData());//متد فرستادن اطلاعات به ماژول پیش بینی پیشرفته




        if (Information_Price.Count > 50)
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
            var AvaragePrediction3 = smartPrediction.AvaragePrediction3(Information_Price, Information_Price[Information_Price.Count - 2], Information_Price[Information_Price.Count - 1]);

            var RandomPrediction2 = prediction.Random_Range(RandomPrediction1, AvaragePrediction3);
            Console.WriteLine($"(2) Prediction1 :{RandomPrediction1} _ Rng_Avarage :{AvaragePrediction3} _  Second Prediction (Random Range) => {RandomPrediction2}"); // پیش بینی2 قیمت بعدی
            Console.ResetColor();
            /////


            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("____________________________________________\n");
            Console.ResetColor();



            /////
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("(3) This is Prediction RnG : {0}", AvaragePrediction3); // پیش بینی 3 قیمت بعدی
            Console.ResetColor();
            /////


            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("____________________________________________\n");
            Console.ResetColor();



            /////
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var regPrediction4 = smartPrediction.LinearRegressionPrediction(Information_Price);
            Console.WriteLine("(4) This is Liner_Regression (Regression) : {0}", regPrediction4);// پیش بینی4 قیمت بعدی
            Console.ResetColor();
            /////



            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("____________________________________________\n");
            Console.ResetColor();


            //////
            prediction.ValidatePredictions(Info.buy,/**/ RandomPrediction1,/**/RandomPrediction2/**/, AvaragePrediction3/**/, regPrediction4/**/);// متد اعنبار صنجی پیش بینی ها + درصد اختلاف رشد یا سقوط ارز
                                                                                                                                                  //////  



            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
            Console.ResetColor();

            Thread.Sleep(1000);
        }

        creat.Creat_File_All_Price(Information_Price);// متد اضافه کردن نرخ ارز در فایل json + ذخیره پوشه در دستکتاپ

    }
    catch (Exception ex)
    { 


        Console.WriteLine(ex.Message);
        Thread.Sleep(5000); // تاخیر 5 ثانیه برای دوباره امتحان کردن اتصال به اینترنت
    }

} while (true) ;




