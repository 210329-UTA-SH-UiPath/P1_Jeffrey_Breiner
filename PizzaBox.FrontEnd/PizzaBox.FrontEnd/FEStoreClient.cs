using IO.Swagger.Model;
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
        static public IEnumerable<AStore> GetStores()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Store/");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<AStore[]>();
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
