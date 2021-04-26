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
    public class SizeController : ControllerBase
    {
        private readonly IRepository<ASize> repository;

        public SizeController(IRepository<ASize> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ASize> Get()
        {
            return repository.GetList();
        }

        [HttpGet("{id}")]
        public ASize Get(int id)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] ASize size)
        {
            repository.Add(size);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ASize size)
        {
            size.ID = id;
            repository.Update(size);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
