using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services.Interfaces
{
    public interface IBasketService
    {
        public Task<BasketModel> GetBasketAsync(string userName);
    }
}
