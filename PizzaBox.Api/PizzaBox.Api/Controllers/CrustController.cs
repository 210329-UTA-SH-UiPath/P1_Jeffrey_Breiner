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
    public class CrustController : ControllerBase
    {
        private readonly IRepository<ACrust> repository;

        public CrustController(IRepository<ACrust> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ACrust> Get()
        {
            return repository.GetList();
        }

        [HttpGet("{id}")]
        public ACrust Get(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] ACrust crust)
        {
            repository.Add(crust);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ACrust crust)
        {
            crust.ID = id;
            repository.Update(crust);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
