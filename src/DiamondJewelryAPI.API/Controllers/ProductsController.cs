using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Persistence.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Common;
using DiamondJewelryAPI.Contracts.Products.Requests;

using ErrorOr;

using MapsterMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

[AllowAnonymous]
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
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request)
    {
        ErrorOr<IEnumerable<Product>> getProductsResult = await _productService.GetProducts();

        return getProductsResult.Match(
            products => Ok(products),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductData request)
    {
        await Task.CompletedTask;
        Product product = _mapper.Map<Product>(request);
        ErrorOr<Product> createProductsResult = await _productService.CreateProduct(product);

        return createProductsResult.Match(
            menu => Ok(_mapper.Map<ProductData>(menu)),
            errors => Problem(errors));
    }
}