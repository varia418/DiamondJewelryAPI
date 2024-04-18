using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Common;
using DiamondJewelryAPI.Contracts.Products.Requests;

using ErrorOr;

using MapsterMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

public class ProductsController : ApiController
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest filters)
    {
        ErrorOr<IEnumerable<Product>> getProductsResult = await _productService.GetProducts(filters);

        return getProductsResult.Match(
            products => Ok(products),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetProductDetails(string id)
    {
        ErrorOr<Product> getProductDetailsResult = await _productService.GetProduct(id);

        return getProductDetailsResult.Match(
            product => Ok(product),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("titles")]
    [AllowAnonymous]
    public IActionResult GetProductTitles()
    {
        ErrorOr<IEnumerable<string>> getProductsResult = _productService.GetProductTitles();

        return getProductsResult.Match(
            titles => Ok(titles),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("searchTitle")]
    [AllowAnonymous]
    public IActionResult GetProductsByTitle([FromQuery] SearchProductByTitleRequest request)
    {
        ErrorOr<IEnumerable<Product>> getProductsByTitleResult = _productService.GetProductsByTitle(request.Keyword);

        return getProductsByTitleResult.Match(
            products => Ok(products),
            errors => Problem(errors)
        );
    }

    [HttpGet("filter/{filter}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetProductFilterOptions(string filter)
    {
        ErrorOr<IEnumerable<string>> getProductsByTitleResult = await _productService.GetProductFilterOptions(filter);

        return getProductsByTitleResult.Match(
            products => Ok(products),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductData request)
    {
        Product product = _mapper.Map<Product>(request);
        ErrorOr<Product> createProductResult = await _productService.CreateProduct(product);

        return createProductResult.Match(
            product => Ok(_mapper.Map<ProductData>(product)),
            errors => Problem(errors));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(ProductData request)
    {
        Product product = _mapper.Map<Product>(request);

        if (product.Id is null) return BadRequest();

        ErrorOr<Product> updateProductResult = await _productService.UpdateProduct(product.Id, product);

        return updateProductResult.Match(
            product => Ok(_mapper.Map<ProductData>(product)),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        ErrorOr<Deleted> deleteProductsResult = await _productService.DeleteProduct(id);

        return deleteProductsResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }
}