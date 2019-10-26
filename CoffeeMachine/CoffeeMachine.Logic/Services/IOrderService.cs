using CoffeeMachine.Logic.Domain;
using CoffeeMachine.Logic.ReadModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Logic.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
        Task<IEnumerable<Drink>> GetDrinkAvailableAsync();
        Task<OrderSummaryReadModel> GetOrdersHistories();
    }
}
