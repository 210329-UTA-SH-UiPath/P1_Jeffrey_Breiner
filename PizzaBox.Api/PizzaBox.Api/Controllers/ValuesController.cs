using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Crusts;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Sizes;
using PizzaBox.Domain.Models.Toppings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet("{PIZZA}/{SIZE}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APizza> GetPizzaInfo(PIZZAS PIZZA, SIZES SIZE)
        {
            APizza pizza;
            ASize size;

            switch (SIZE)
            {
                case SIZES.SMALL:
                    size = new SmallSize();
                    break;
                case SIZES.MEDIUM:
                    size = new MediumSize();
                    break;
                case SIZES.LARGE:
                    size = new LargeSize();
                    break;
                default:
                    return StatusCode(400, "Size not recognized");
            }

            switch (PIZZA)
            {
                case PIZZAS.MEAT:
                    pizza = new MeatPizza(size);
                    break;
                case PIZZAS.HAWAIIAN:
                    pizza = new HawaiianPizza(size);
                    break;
                case PIZZAS.VEGAN:
                    pizza = new VeganPizza(size);
                    break;
                case PIZZAS.CUSTOM:
                    return StatusCode(400, "You entered a custom pizza without providing the crust or toppings");
                default:
                    return StatusCode(400, "Size not recognized");
            }

            pizza.CalculatePrice();
            return Ok(pizza);
        }

        [HttpGet("{PIZZA}/{SIZE}/{CRUST}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APizza> GetPizzaInfo(PIZZAS PIZZA, SIZES SIZE, CRUSTS CRUST, [FromQuery] List<TOPPINGS> TOPPING)
        {
            APizza pizza;
            ASize size;
            ACrust crust;
            List<ATopping> toppings = new List<ATopping>();

            switch (SIZE)
            {
                case SIZES.SMALL:
                    size = new SmallSize();
                    break;
                case SIZES.MEDIUM:
                    size = new MediumSize();
                    break;
                case SIZES.LARGE:
                    size = new LargeSize();
                    break;
                default:
                    return StatusCode(400, "Size not recognized");
            }

            switch (CRUST)
            {
                case CRUSTS.DEEPDISH:
                    crust = new DeepDishCrust();
                    break;
                case CRUSTS.STANDARD:
                    crust = new StandardCrust();
                    break;
                case CRUSTS.STUFFED:
                    crust = new StuffedCrust();
                    break;
                case CRUSTS.THIN:
                    crust = new ThinCrust();
                    break;
                default:
                    return StatusCode(400, "Crust not recognized");
            }

            foreach (TOPPINGS toppingEnum in TOPPING)
            {
                switch (toppingEnum)
                {
                    case TOPPINGS.BACON:
                        toppings.Add(new Bacon());
                        break;
                    case TOPPINGS.CHICKEN:
                        toppings.Add(new Chicken());
                        break;
                    case TOPPINGS.EXTRACHEESE:
                        toppings.Add(new ExtraCheese());
                        break;
                    case TOPPINGS.GREENPEPPER:
                        toppings.Add(new GreenPepper());
                        break;
                    case TOPPINGS.HAM:
                        toppings.Add(new Ham());
                        break;
                    case TOPPINGS.NOCHEESE:
                        toppings.Add(new NoCheese());
                        break;
                    case TOPPINGS.PINEAPPLE:
                        toppings.Add(new Pineapple());
                        break;
                    case TOPPINGS.REDPEPPER:
                        toppings.Add(new RedPepper());
                        break;
                    case TOPPINGS.SAUSAGE:
                        toppings.Add(new Sausage());
                        break;
                    default:
                        return StatusCode(400, "Topping not recognized");
                }
            }
            pizza = new APizza
            {
                PIZZA = PIZZA,
                Name = Enum.GetName<PIZZAS>(PIZZA),
                Crust = crust,
                Toppings = toppings
            };
            switch (PIZZA)
            {
                case PIZZAS.MEAT:
                    pizza = new MeatPizza(size);
                    pizza.Crust = crust;
                    pizza.Toppings = toppings;
                    break;
                case PIZZAS.HAWAIIAN:
                    pizza = new HawaiianPizza(size);
                    pizza.Crust = crust;
                    pizza.Toppings = toppings;
                    break;
                case PIZZAS.VEGAN:
                    pizza = new VeganPizza(size);
                    pizza.Crust = crust;
                    pizza.Toppings = toppings;
                    break;
                case PIZZAS.CUSTOM:
                    pizza = new CustomPizza(crust, size, toppings);
                    break;
                default:
                    return StatusCode(400, "Size not recognized");
            }

            pizza.CalculatePrice();
            return Ok(pizza);
        }
    }
}
