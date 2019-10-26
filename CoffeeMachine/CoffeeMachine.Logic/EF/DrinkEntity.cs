using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoffeeMachine.Logic.EF
{
    public class DrinkEntity
    {
        [Key]
        public string CodDrink { get; set; }
        public string DrinkName { get; set; }
        public decimal Price { get; set; }
    }
}
