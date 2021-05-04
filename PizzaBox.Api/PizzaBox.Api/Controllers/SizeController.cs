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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<ASize>> Get()
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
        public ActionResult<ASize> Get(int id)
        {
            try
            {
                return Ok(repository.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound($"The size by id - {id} does not exist");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ASize size)
        {
            if (size == null)
            {
                return BadRequest("The size you are trying to add is empty");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    repository.Add(size);
                    return CreatedAtAction(nameof(Get), new { id = size.ID }, size);
                }
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(int id, [FromBody] ASize size)
        {
            if (size == null)
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
                    size.ID = id;
                    repository.Update(size);
                    return CreatedAtAction(nameof(Get), new { id = size.ID }, size);
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
