using System;
using CoffeeMachine.Logic.Domain;
using Xunit;

namespace CoffeeMachine.Test.Domain
{
    public class OrderTest
    {
        [Fact]
        public void OrderDrink_NoMoney()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Order(new Coffee(), 0));
        }

        [Fact]
        public void OrderDrink_NoEnoughMoney()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Order(new Coffee(), 0.2m));
        }

        [Fact]
        public void OrderDrink_Ctor()
        {
            var c = new Coffee();
            var o1 = new Order(c, 1m, false);
            Assert.Equal(c, o1.Drink);
            Assert.Equal(1m, o1.Paid);
            Assert.Equal(0, o1.Rest);
            Assert.False(o1.IsWinner);
        }

        [Fact]
        public void OrderDrink_CheckRestCoffe_NoWin()
        {
            var o = new Order(new Coffee(), 2m, false);
            Assert.True(o.Rest == 1m);
        }

        [Fact]
        public void OrderDrink_CheckRestCoffe_Win()
        {
            var o = new Order(new Coffee(), 2m, true);
            Assert.True(o.Rest == 2m);
        }

        [Fact]
        public void OrderDrink_CheckRestTe_NoWin()
        {
            var o = new Order(new The(), 2m, false);
            Assert.True(o.Rest == 1.2m);
        }

        [Fact]
        public void OrderDrink_CheckRestTe_Win()
        {
            var o = new Order(new The(), 2m, true);
            Assert.True(o.Rest == 2m);
        }

        [Fact]
        public void OrderDrink_CheckCappuccino_NoWin()
        {
            var o = new Order(new Cappuccino(), 2m, false);
            Assert.True(o.Rest == 0.8m);
        }

        [Fact]
        public void OrderDrink_CheckCappuccino_Win()
        {
            var o = new Order(new Cappuccino(), 2m, true);
            Assert.True(o.Rest == 2m);
        }
    }
}
