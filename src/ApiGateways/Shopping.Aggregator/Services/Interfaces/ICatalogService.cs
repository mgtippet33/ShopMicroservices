using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services.Interfaces
{
    public interface ICatalogService
    {
        public Task<IEnumerable<CatalogModel>> GetCatalogsAsync();

        public Task<IEnumerable<CatalogModel>> GetCatalogsByCategory(string category);

        public Task<CatalogModel> GetCatalogAsync(string id);
    }
}
