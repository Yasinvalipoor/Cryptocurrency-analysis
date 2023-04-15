namespace Cryptocurrency_analysis.CreatFile
{
    internal class CreatFile
    {
        public void Creat_File_All_Price(List<double> Info)
        {
            List<double> Linfo = new List<double>
            {
                0,
            };

            //آدرس پوشه + اسم پوشه
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MyFolder_SavePrices");

            // ایجاد پوشه در دسکتاپ سیستم عامل
            Directory.CreateDirectory(folderPath);

            //  مسیر فایل
            string filePath = Path.Combine(folderPath, "BeCool.json");

            // ایجاد فایل  در پوشه "MyFolder"
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                Linfo.AddRange(Info);
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

