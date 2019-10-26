using BenchmarkDotNet.Attributes;
using CoffeeMachine.Logic.EF;
using CoffeeMachine.Logic.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Test.Performance
{
    [MemoryDiagnoser]
    [DryJob]
    [AllStatisticsColumn]
    public class OrderServiceBenchmark
    {
        private DemoContext context;
        [GlobalSetup]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DemoContext>()
               .UseInMemoryDatabase(databaseName: "TryDB")
               .Options;

            context = new DemoContext(options);
        }

        [Benchmark]
        public async Task CreateOrderAsync()
        {
            OrderService service = new OrderService(context);
            var result = await service.GetDrinkAvailableAsync();
        }
    }

}
