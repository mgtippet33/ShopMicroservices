using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services.Interfaces;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserNameAsync(string userName)
        {
            var response = await _httpClient.GetAsync($"/api/v1/Order/{userName}");

            return await response.ReadContentAs<List<OrderResponseModel>>();
        }
    }
}
