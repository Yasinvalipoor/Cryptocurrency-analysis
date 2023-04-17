namespace Cryptocurrency_analysis.CreatFile
{
    internal class CreatFile
    {
        public void Creat_File_All_Price(List<double> Info)
        {
            //آدرس پوشه + اسم پوشه
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MyFolder_SavePrices");

            // ایجاد پوشه در دسکتاپ سیستم عامل
            Directory.CreateDirectory(folderPath);

            //  مسیر فایل
            string filePath = Path.Combine(folderPath, "BeCool.json");

            // ایجاد فایل  در پوشه "MyFolder_SavePrices"
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                int count = 0;
                foreach (var item in Info)
                {
                    count++;
                    writer.WriteLine("{0}) price : {1} ", Convert.ToString(count), item);
                }
            }
        }
    }
}

