using Cryptocurrency_analysis.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_analysis.ReadAPI
{
    internal class ReadAPI
    {
        public static HttpClient API_Client { get; set; }
        public static void InitializeClient()
        {
            API_Client = new HttpClient();
            API_Client.DefaultRequestHeaders.Accept.Clear();
            API_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<DataModel.DataModel> Read_Url(string url)
        {

            using (HttpResponseMessage response = await ReadAPI.API_Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    DataModel.API_Result_Model Data = await response.Content.ReadAsAsync<DataModel.API_Result_Model>();
                    return Data.data;
                }

                else

                    throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
