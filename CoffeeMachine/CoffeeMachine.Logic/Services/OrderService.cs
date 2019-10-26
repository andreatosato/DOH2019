using CoffeeMachine.Logic.Domain;
using CoffeeMachine.Logic.EF;
using CoffeeMachine.Logic.ReadModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine.Logic.Services
{
    public class OrderService : IOrderService
    {
        private readonly DemoContext db;

        public OrderService(DemoContext db)
        {
            this.db = db;
        }

        public async Task CreateOrderAsync(Order order)
        {
            var drink = await db.Drinks.FindAsync(order.Drink.CodDrink);
            OrderEntity orderEntity = new OrderEntity
            {
                Drink = drink,
                IsWinner = order.IsWinner,
                OrderDate = DateTime.UtcNow,
                Rest = order.Rest
            };
            db.Add(orderEntity);
            await db.SaveChangesAsync();
        }

        public async Task<OrderSummaryReadModel> GetOrdersHistories()
        {
            var orderNumbers = await db.Orders.CountAsync();
            var ordersByDate = await db.Orders
                .GroupBy(x => x.OrderDate.Date)
                .Select(x => new { Date = x.Key, Count = x.Count(), Sold = x.Sum(t => t.Drink.Price) })
                .ToListAsync();
            return new OrderSummaryReadModel
            {
                TotalOrders = orderNumbers,
                SummaryByDate = ordersByDate.Select(x => new OrderSummaryByDayReadModel
                {
                    Date = x.Date,
                    TotalOrders = x.Count,
                    Sold = x.Sold
                })
            };
        }

        public async Task<IEnumerable<Drink>> GetDrinkAvailableAsync()
        {
            List<Drink> drinksResult = new List<Drink>();
            var drinks = await db.Drinks.ToListAsync();
            foreach (var d in drinks)
            {
                switch (d.CodDrink)
                {
                    case "COFFEE":
                        var c = new Coffee();
                        c.SetPrice(d.Price);
                        drinksResult.Add(c);
                        break;
                    case "THE":
                        var t = new The();
                        t.SetPrice(d.Price);
                        drinksResult.Add(t);
                        break;
                    case "CAPPUCCINO":
                        var ca = new Cappuccino();
                        ca.SetPrice(d.Price);
                        drinksResult.Add(ca);
                        break;
                }
            }
            return drinksResult;
        }
    }
}
