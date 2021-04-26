using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> repository;

        public OrderController(IRepository<Order> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return repository.GetList();
        }

        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Order order)
        {
            repository.Add(order);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order order)
        {
            order.ID = id;
            repository.Update(order);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
