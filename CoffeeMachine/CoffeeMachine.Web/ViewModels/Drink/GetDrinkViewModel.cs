using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine.Web.ViewModels.Drink
{
    public class GetDrinkViewModel
    {
        public string CodDrink { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Uri Image { get; set; }
    }
}
