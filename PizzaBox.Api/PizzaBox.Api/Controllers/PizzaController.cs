using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IRepository<APizza> repository;

        public PizzaController(IRepository<APizza> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<APizza> Get()
        {
            return repository.GetList();
        }

        [HttpGet("{id}")]
        public APizza Get(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] APizza pizza)
        {
            repository.Add(pizza);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] APizza pizza)
        {
            pizza.ID = id;
            repository.Update(pizza);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
