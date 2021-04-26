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
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> repository;

        public CustomerController(IRepository<Customer> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return repository.GetList();
        }

        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            repository.Add(customer);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            customer.ID = id;
            repository.Update(customer);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
