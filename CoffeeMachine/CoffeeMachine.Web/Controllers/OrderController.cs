using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeMachine.Logic.Domain;
using CoffeeMachine.Logic.Services;
using CoffeeMachine.Web.ViewModels.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
                

        [HttpPost]
        public async Task<IActionResult> PostOrder(PostOrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO Logic
                Drink drinkSelected = null;
                switch (orderViewModel.DrinkSelected)
                {
                    case "COFFEE":
                        drinkSelected = new Coffee();
                        break;
                    case "THE":
                        drinkSelected = new The();
                        break;
                    case "CAPPUCCINO":
                        drinkSelected = new Cappuccino();
                        break;
                }
                var order = new Logic.Domain.Order(drinkSelected, orderViewModel.CoinInserted);
                await _orderService.CreateOrderAsync(order);
                return Ok(new PostOrderResultViewModel { Rest = order.Rest, IsWinner = order.IsWinner });
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetHistory()
        {
            return Ok(await _orderService.GetOrdersHistoriesAsync());
        }
    }
}