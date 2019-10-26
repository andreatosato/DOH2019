using CoffeeMachine.Logic.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoffeeMachine.Test.Domain
{
    public class DrinkTest
    {
        [Fact]
        public void Coffee_Ctor()
        {
            var c = new Coffee();
            Assert.NotNull(c);
            Assert.Equal(1m, c.Price);
            Assert.Equal("COFFEE", c.CodDrink);
            Assert.Equal("Italian Coffee", c.DrinkName);
        }

        [Fact]
        public void The_Ctor()
        {
            var t = new The();
            Assert.NotNull(t);
            Assert.Equal(0.8m, t.Price);
            Assert.Equal("THE", t.CodDrink);
            Assert.Equal("Tè", t.DrinkName);
        }

        [Fact]
        public void Cappuccino_Ctor()
        {
            var ca = new Cappuccino();
            Assert.NotNull(ca);
            Assert.Equal(1.2m, ca.Price);
            Assert.Equal("CAPPUCCINO", ca.CodDrink);
            Assert.Equal("Cappuccino", ca.DrinkName);
        }
    }
}
