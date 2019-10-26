using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeeMachine.Logic.EF
{
    [Table("Order")]
    public class OrderEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderId { get; set; }       
        public DateTime OrderDate { get; set; }
        public decimal Rest { get; set; }
        public bool IsWinner { get; set; }

        public DrinkEntity Drink { get; set; }
        [ForeignKey("Drink")]
        public string CodDrink { get; set; }
    }
}
