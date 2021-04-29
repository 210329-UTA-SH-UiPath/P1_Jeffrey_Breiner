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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APizza> Get()
        {
            try
            {
                return Ok(repository.GetList());
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APizza> Get(int id)
        {
            try
            {
                return Ok(repository.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound($"The pizza by id - {id} does not exist");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] APizza pizza)
        {
            if (pizza == null)
            {
                return BadRequest("The pizza you are trying to add is empty");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    repository.Add(pizza);
                    return CreatedAtAction(nameof(Get), new { id = pizza.ID }, pizza);
                }
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(int id, [FromBody] APizza pizza)
        {
            if (pizza == null)
            {
                return NoContent();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return NoContent();
                }
                else
                {
                    pizza.ID = id;
                    repository.Update(pizza);
                    return CreatedAtAction(nameof(Get), new { id = pizza.ID }, pizza);
                }
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            repository.Remove(id);
            return Ok();
        }
    }
}
