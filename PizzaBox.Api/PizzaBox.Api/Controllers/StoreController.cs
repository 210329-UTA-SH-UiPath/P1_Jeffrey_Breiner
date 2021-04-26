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
    public class StoreController : ControllerBase
    {
        private readonly IRepository<AStore> repository;

        public StoreController(IRepository<AStore> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<AStore> Get()
        {
            return repository.GetList();
        }

        [HttpGet("{id}")]
        public AStore Get(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] AStore store)
        {
            repository.Add(store);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AStore store)
        {
            store.ID = id;
            repository.Update(store);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
