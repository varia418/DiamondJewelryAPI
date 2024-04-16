using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;

public interface IProductRepository : IRepository<Product>
{
    ErrorOr<IEnumerable<string>> GetAllTitles();
    ErrorOr<IEnumerable<Product>> GetProductsByTitle(string keyword);
    Task<ErrorOr<IEnumerable<string>>> GetProductFilterOptions(string filter);
}