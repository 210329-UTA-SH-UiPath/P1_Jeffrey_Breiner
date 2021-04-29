using PizzaBox.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd
{
    public class FEPizzaClient
    {
        static string url = "https://localhost:44368/api/";
        static public IEnumerable<FEPizza> GetPizzas()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Pizza/");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<FEPizza[]>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                return null;
            }
        }

        static public IEnumerable<FEPizza> GetPizzaTypes()
        {
            return GetPizzas().GroupBy(pizza => pizza.PIZZA).Select(first => first.First());
        }
    }
}
