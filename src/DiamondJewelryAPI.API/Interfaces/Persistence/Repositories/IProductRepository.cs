using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Products.Requests;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<ErrorOr<IEnumerable<Product>>> GetProductsByFilter(GetProductsRequest filter);
    ErrorOr<IEnumerable<string>> GetAllTitles();
    ErrorOr<IEnumerable<Product>> GetProductsByTitle(string keyword);
    Task<ErrorOr<IEnumerable<string>>> GetProductFilterOptions(string filter);
    ErrorOr<IEnumerable<Product>> GetProductsByIds(IEnumerable<string> ids);
}