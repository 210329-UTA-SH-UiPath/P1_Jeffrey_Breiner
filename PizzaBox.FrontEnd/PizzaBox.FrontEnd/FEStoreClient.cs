using PizzaBox.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd
{
    public class FEStoreClient
    {
        static string url = "https://localhost:44368/api/";
        static public IEnumerable<FEStore> GetStores()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Store/");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<FEStore[]>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                return null;
            }
        }
    }
}
