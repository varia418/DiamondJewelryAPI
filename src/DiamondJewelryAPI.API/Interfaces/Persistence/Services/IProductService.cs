using DiamondJewelryAPI.API.Models;

namespace DiamondJewelryAPI.API.Interfaces.Persistence.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProduct(string id);
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(string id, Product product);
    Task DeleteProduct(string id);
}