using PizzaBox.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd
{
    public class FECustomerClient
    {
        static string url = "https://localhost:44368/api/";
        static public IEnumerable<FECustomer> GetCustomers()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Customer/");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<FECustomer[]>();
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
