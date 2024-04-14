using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<IEnumerable<Product>>> GetProducts()
    {
        return await _productRepository.GetAll();
    }
    public ErrorOr<IEnumerable<string>> GetProductTitles()
    {
        return _productRepository.GetAllTitles();
    }

    public async Task<ErrorOr<Product>> GetProduct(string id)
    {
        return await _productRepository.GetById(id);
    }

    public async Task<ErrorOr<Product>> CreateProduct(Product product)
    {
        return await _productRepository.Create(product);
    }

    public async Task<ErrorOr<Product>> UpdateProduct(string id, Product product)
    {
        return await _productRepository.Update(id, product);
    }

    public async Task<ErrorOr<Deleted>> DeleteProduct(string id)
    {
        await _productRepository.Delete(id);
        return Result.Deleted;
    }
}