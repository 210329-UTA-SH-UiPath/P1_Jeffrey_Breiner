using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PizzaBox.FrontEnd.Models;

namespace PizzaBox.Client.Controllers
{
    public class Utils
    {
        private static void SetObjectAsJson(ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        private static T GetObjectFromJson<T>(ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static FEOrder GetCurrentOrder(ISession session)
        {
            var order = GetObjectFromJson<FEOrder>(session, "order");
            if (order is null)
            {
                order = new FEOrder();
            }
            return order;
        }

        public static void SaveOrder(ISession session, FEOrder order)
        {
            SetObjectAsJson(session, "order", order);
        }
    }
}