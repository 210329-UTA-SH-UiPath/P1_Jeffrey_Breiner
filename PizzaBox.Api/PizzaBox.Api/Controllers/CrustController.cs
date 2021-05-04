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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<ACrust>> Get()
        {
            try
            {
                return Ok(repository.GetList());
            }
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ACrust> Get(int id)
        {
            try
            {
                return Ok(repository.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound($"The crust by id - {id} does not exist");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ACrust crust)
        {
            if (crust == null)
            {
                return BadRequest("The crust you are trying to add is empty");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    repository.Add(crust);
                    return CreatedAtAction(nameof(Get), new { id = crust.ID }, crust);
                }
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(int id, [FromBody] ACrust crust)
        {
            if (crust == null)
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
                    crust.ID = id;
                    repository.Update(crust);
                    return CreatedAtAction(nameof(Get), new { id = crust.ID }, crust);
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
