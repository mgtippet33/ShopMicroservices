using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderResponseModel>> GetOrdersByUserNameAsync(string userName);
    }
}
