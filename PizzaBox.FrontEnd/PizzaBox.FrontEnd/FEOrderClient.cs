using Newtonsoft.Json;
using PizzaBox.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd
{
    public class FEOrderClient
    {
        static string url = "https://localhost:44368/api/";
        static public IEnumerable<FEOrder> GetOrders()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Order/");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<FEOrder[]>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                return null;
            }
        }

        static public IEnumerable<FEOrder> GetOrderById(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Order/" + id);
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<FEOrder[]>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                return null;
            }

        }
        static public bool AddOrder(FEOrder order)
        {
            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = client.PostAsync(url + "Order/", data);
            response.Wait();

            var result = response.Result;

            return result.IsSuccessStatusCode;
        }
    }
}
