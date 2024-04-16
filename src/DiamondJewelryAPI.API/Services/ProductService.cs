using System.Globalization;
using System.Reflection;

using DiamondJewelryAPI.API.Common.Errors;
using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;

using PowerUtils.Text;

namespace DiamondJewelryAPI.API.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IEnumerable<string> _productFilters;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;

        PropertyInfo[] properties = typeof(ProductDetails).GetProperties();
        _productFilters = properties.Select(p => p.Name.ToSnakeCase()).ToList();
    }

    public async Task<ErrorOr<IEnumerable<Product>>> GetProducts()
    {
        return await _productRepository.GetAll();
    }
    public ErrorOr<IEnumerable<string>> GetProductTitles()
    {
        return _productRepository.GetAllTitles();
    }

    public ErrorOr<IEnumerable<Product>> GetProductsByTitle(string keyword)
    {
        return _productRepository.GetProductsByTitle(keyword);

    }

    public async Task<ErrorOr<IEnumerable<string>>> GetProductFilterOptions(string filter)
    {
        if (!_productFilters.Contains(filter))
            return Errors.Product.FilterNotFound;

        // TextInfo info = CultureInfo.CurrentCulture.TextInfo;
        // var filterInPascalCase = info.ToTitleCase(filter).Replace(" ", string.Empty);

        return await _productRepository.GetProductFilterOptions(filter);
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