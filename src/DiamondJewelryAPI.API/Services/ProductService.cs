using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Services;
using DiamondJewelryAPI.API.Models;

namespace DiamondJewelryAPI.API.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _productRepository.GetAll();
    }

    public async Task<Product> GetProduct(string id)
    {
        return await _productRepository.GetById(id);
    }

    public async Task<Product> CreateProduct(Product product)
    {
        return await _productRepository.Create(product);
    }

    public async Task<Product> UpdateProduct(string id, Product product)
    {
        return await _productRepository.Update(id, product);
    }

    public async Task DeleteProduct(string id)
    {
        await _productRepository.Delete(id);
    }
}