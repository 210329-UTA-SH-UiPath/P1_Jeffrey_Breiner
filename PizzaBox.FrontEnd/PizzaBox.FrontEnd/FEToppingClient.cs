using PizzaBox.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd
{
    public class FEToppingClient
    {
        static string url = "https://localhost:44368/api/";
        static public IEnumerable<FETopping> GetToppings()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Topping/");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<FETopping[]>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                return null;
            }
        }

        static public IEnumerable<FETopping> GetToppingTypes()
        {
            return GetToppings().GroupBy(topping => topping.TOPPING).Select(first => first.First());
        }
    }
}
