using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Logic.ReadModels
{
    public class OrderSummaryReadModel
    {
        public int TotalOrders { get; set; }
        public IEnumerable<OrderSummaryByDayReadModel> SummaryByDate { get; set; }
    }

    public class OrderSummaryByDayReadModel
    {
        public int TotalOrders { get; set; }
        public decimal Sold { get; set; }
        public DateTime Date { get; set; }
    }
}
