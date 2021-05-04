using IO.Swagger.Model;
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
        static public IEnumerable<APizza> GetPizzas()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Pizza/");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<APizza[]>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                return null;
            }
        }

        static public IEnumerable<APizza> GetPizzaTypes()
        {
            return GetPizzas().GroupBy(pizza => pizza.Pizza).Select(first => first.First());
        }

        static public APizza GetPizzaInfo(APizza pizza)
        {
            using var client = new HttpClient();

            if (pizza.Pizza == PIZZAS.CUSTOM)
            {
                List<TOPPINGS> TOPPING = new List<TOPPINGS>();

                foreach (ATopping topping in pizza.Toppings)
                {
                    TOPPING.Add(topping.Topping);
                }

                client.BaseAddress = new Uri($"{url}{pizza.Pizza}/{pizza.Size.Size}/{pizza.Size.Size}?{TOPPING}");
            }
            else
            {
                client.BaseAddress = new Uri($"{url}{pizza.Pizza}/{pizza.Size.Size}");
            }

            var response = client.GetAsync("Values/");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<APizza>();
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
