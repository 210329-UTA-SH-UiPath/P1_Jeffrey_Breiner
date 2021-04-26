using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Storing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingController : ControllerBase
    {
        private readonly IRepository<ATopping> repository;

        public ToppingController(IRepository<ATopping> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ATopping> Get()
        {
            return repository.GetList();
        }

        [HttpGet("{id}")]
        public ATopping Get(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] ATopping topping)
        {
            repository.Add(topping);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ATopping topping)
        {
            topping.ID = id;
            repository.Update(topping);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
