using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Logic.EF
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<DrinkEntity> Drinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var coffee = new DrinkEntity
            {
                CodDrink = "COFFEE",
                DrinkName = "Italian Coffee",
                Price = 1m
            };
            var the = new DrinkEntity
            {
                CodDrink = "THE",
                DrinkName = "Tè",
                Price = 0.8m
            };
            var cappuccino = new DrinkEntity
            {
                CodDrink = "CAPPUCCINO",
                DrinkName = "Cappuccino",
                Price = 1.2m
            };
            modelBuilder.Entity<DrinkEntity>().HasData(new [] { coffee, the, cappuccino });

            OrderEntity o1 = new OrderEntity() {OrderId = 1, CodDrink = "COFFEE", IsWinner = false, OrderDate = new DateTime(2019, 05, 01), Rest = 0 };
            OrderEntity o2 = new OrderEntity() {OrderId = 2, CodDrink = "THE", IsWinner = false, OrderDate = new DateTime(2019, 05, 01), Rest = 0.2m };
            OrderEntity o3 = new OrderEntity() {OrderId = 3, CodDrink = "CAPPUCCINO", IsWinner = false, OrderDate = new DateTime(2019, 05, 01), Rest = 0.4m };
                                                
            OrderEntity o4 = new OrderEntity() {OrderId = 4, CodDrink = "COFFEE", IsWinner = false, OrderDate = new DateTime(2019, 05, 02), Rest = 0.5m };
            OrderEntity o5 = new OrderEntity() {OrderId = 5, CodDrink = "THE", IsWinner = false, OrderDate = new DateTime(2019, 05, 02), Rest = 0.4m };
            OrderEntity o6 = new OrderEntity() {OrderId = 6, CodDrink = "CAPPUCCINO", IsWinner = false, OrderDate = new DateTime(2019, 05, 03), Rest = 0.4m };
                                                
            OrderEntity o7 = new OrderEntity() {OrderId = 7, CodDrink = "COFFEE", IsWinner = false, OrderDate = new DateTime(2019, 05, 03), Rest = 0.1m };
            OrderEntity o8 = new OrderEntity() {OrderId = 8, CodDrink = "THE", IsWinner = false, OrderDate = new DateTime(2019, 05, 03), Rest = 0.5m };
            OrderEntity o9 = new OrderEntity() { OrderId = 9, CodDrink = "CAPPUCCINO", IsWinner = false, OrderDate = new DateTime(2019, 05, 04), Rest = 0.2m };

            modelBuilder.Entity<OrderEntity>().HasData(new[] {o1,o2,o3,o4,o5,o6,o8,o9});
        }
    }
}
