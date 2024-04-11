using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Persistence.Services;

public interface IProductService
{
    Task<ErrorOr<IEnumerable<Product>>> GetProducts();
    Task<ErrorOr<Product>> GetProduct(string id);
    Task<ErrorOr<Product>> CreateProduct(Product product);
    Task<ErrorOr<Product>> UpdateProduct(string id, Product product);
    Task<ErrorOr<Deleted>> DeleteProduct(string id);
}