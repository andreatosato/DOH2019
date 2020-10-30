using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;
using Xunit;

namespace CoffeeMachine.Test.Performance
{
    public class PerformanceRunner
    {
        [Fact]
        public void OrderBenchmark_Ctor_Runner()
        {
            BenchmarkRunner.Run<OrderBenchmark>();
        }

        [Fact]
        public void OrderServiceBenchmark_Runner()
        {
            BenchmarkRunner.Run<OrderServiceBenchmark>();
        }
    }
}
