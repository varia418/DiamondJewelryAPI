using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Products.Requests;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface IProductService
{
    Task<ErrorOr<IEnumerable<Product>>> GetProducts(GetProductsRequest filters);
    Task<ErrorOr<Product>> GetProduct(string id);
    ErrorOr<IEnumerable<string>> GetProductTitles();
    ErrorOr<IEnumerable<Product>> GetProductsByTitle(string keyword);
    Task<ErrorOr<IEnumerable<string>>> GetProductFilterOptions(string filter);
    Task<ErrorOr<Product>> CreateProduct(Product product);
    Task<ErrorOr<Product>> UpdateProduct(string id, Product product);
    Task<ErrorOr<Deleted>> DeleteProduct(string id);
}