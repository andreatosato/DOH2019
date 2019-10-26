using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Logic.Domain
{
    public abstract class Drink
    {
        public Drink(decimal price, string codDrink, string drinkName)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater or equal to 0");
            if (string.IsNullOrEmpty(codDrink))
                throw new ArgumentNullException("Cod Drink must be not empty");
            Price = price;
            CodDrink = codDrink;
            DrinkName = drinkName;
        }

        public decimal Price { get; private set; }
        public string CodDrink { get; }
        public string DrinkName { get; }

        public void SetPrice(decimal price)
        {
            Price = price;
        }
    }

    public class Coffee : Drink
    {
        public Coffee() 
            : base(1m,"COFFEE", "Italian Coffee")
        {
        }
    }

    public class The : Drink
    {
        public The()
            : base(0.8m, "THE", "Tè")
        {
        }
    }

    public class Cappuccino : Drink
    {
        public Cappuccino()
            : base(1.2m, "CAPPUCCINO", "Cappuccino")
        {
        }
    }
}
