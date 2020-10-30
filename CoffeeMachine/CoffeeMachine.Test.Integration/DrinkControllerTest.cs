using CoffeeMachine.Web;
using CoffeeMachine.Web.ViewModels.Drink;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeMachine.Test.Integration
{
    public class DrinkControllerTest: IClassFixture<WebApplicationFactory<Startup>>
    {
        //Uri baseAddress;
        WebApplicationFactory<Startup> _factory;
        HttpClient _client;
        public DrinkControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAsync()
        {
            var response = await _client.GetAsync("/api/Drink");
            Assert.True(response.IsSuccessStatusCode);

            var dataJson = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<GetDrinkViewModel>>(dataJson);

            Assert.Collection(data,
                (e) =>
                {
                    Assert.Equal("COFFEE", e.CodDrink);
                    Assert.Equal(1, e.Price);
                },
                (e) =>
                {
                    Assert.Equal("THE", e.CodDrink);
                    Assert.Equal(0.8m, e.Price);
                },
                (e) =>
                {
                    Assert.Equal("CAPPUCCINO", e.CodDrink);
                    Assert.Equal(1.2m, e.Price);
                });

        }
    }
}
