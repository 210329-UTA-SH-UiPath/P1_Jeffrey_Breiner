using PizzaBox.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd
{
    public class FESizeClient
    {
        static string url = "https://localhost:44368/api/";
        static public IEnumerable<FESize> GetSizes()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Size/");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<FESize[]>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                return null;
            }
        }

        static public IEnumerable<FESize> GetSizeTypes()
        {
            return GetSizes().GroupBy(size => size.SIZE).Select(first => first.First());
        }
    }
}
