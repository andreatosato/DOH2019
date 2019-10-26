using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeMachine.Logic.Services;
using CoffeeMachine.Web.ViewModels.Drink;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private readonly IOrderService orderService;

        public DrinkController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public async Task<IActionResult> Get()
        {
            List<GetDrinkViewModel> result = new List<GetDrinkViewModel>();
            var drinks = await orderService.GetDrinkAvailableAsync();
            foreach (var d in drinks)
            {
                result.Add(new GetDrinkViewModel
                {
                    Price = d.Price,
                    Name = d.DrinkName,
                    CodDrink = d.CodDrink
                });
            }
            return Ok(result);
        }
    }
}