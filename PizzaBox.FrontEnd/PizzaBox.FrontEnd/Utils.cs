using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PizzaBox.FrontEnd;
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

        public static Order GetCurrentOrder(ISession session)
        {
            var order = GetObjectFromJson<Order>(session, "order");
            if (order is null)
            {
                order = new Order();
            }
            return order;
        }

        public static void SaveOrder(ISession session, Order order)
        {
            order.CalculateOrderPrice();
            SetObjectAsJson(session, "order", order);
        }
    }
}