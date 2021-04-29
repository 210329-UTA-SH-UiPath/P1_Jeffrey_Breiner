﻿using Newtonsoft.Json;
using PizzaBox.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd
{
    public class FECrustClient
    {
        static string url = "https://localhost:44368/api/";
        static public IEnumerable<FECrust> GetCrusts()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetAsync("Crust/");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<FECrust[]>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                return null;
            }
        }

        static public IEnumerable<FECrust> GetCrustById(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url + id);
            var response = client.GetAsync("Crust/");
            response.Wait();

            var result = response.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<FECrust[]>();
                readTask.Wait();

                return readTask.Result;
            }
            else
            {
                return null;
            }

        }

        static public IEnumerable<FECrust> GetCrustTypes()
        {
            return GetCrusts().GroupBy(crust => crust.CRUST).Select(first => first.First());
        }

        static public async void AddCrust(FECrust crust)
        {
            var json = JsonConvert.SerializeObject(crust);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync(url + "Crust/", data);
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }
    }
}
