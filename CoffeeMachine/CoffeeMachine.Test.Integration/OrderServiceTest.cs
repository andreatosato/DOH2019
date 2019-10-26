using CoffeeMachine.Logic.EF;
using CoffeeMachine.Logic.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeMachine.Test.Integration
{
    public class OrderServiceTest
    {
        private DemoContext context;
        public OrderServiceTest()
        {
            var options = new DbContextOptionsBuilder<DemoContext>()
              .UseInMemoryDatabase(databaseName: "TryDB")
              .Options;

            context = new DemoContext(options);
        }
        [Fact]
        public async Task GetDrinkAvailableAsync()
        {
            OrderService service = new OrderService(context);
            var result = await service.GetDrinkAvailableAsync();
            Assert.Collection(result,
                (e) =>
                {
                    Assert.Equal("COFFEE", e.CodDrink);
                    Assert.Equal("Italian Coffee", e.DrinkName);
                    Assert.Equal(1, e.Price);
                },
                (e) =>
                {
                    Assert.Equal("THE", e.CodDrink);
                    Assert.Equal("Tè", e.DrinkName);
                    Assert.Equal(0.8m, e.Price);
                },
                (e) =>
                {
                    Assert.Equal("CAPPUCCINO", e.CodDrink);
                    Assert.Equal("Cappuccino", e.DrinkName);
                    Assert.Equal(1.2m, e.Price);
                });
        }
    }
}
