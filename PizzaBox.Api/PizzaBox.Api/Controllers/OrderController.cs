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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Order> Get()
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
        public ActionResult<Order> Get(int id)
        {
            try
            {
                return Ok(repository.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound($"The order by id - {id} does not exist");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("The order you are trying to add is empty");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    repository.Add(order);
                    return CreatedAtAction(nameof(Get), new { id = order.ID }, order);
                }
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            if (order == null)
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
                    order.ID = id;
                    repository.Update(order);
                    return CreatedAtAction(nameof(Get), new { id = order.ID }, order);
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
