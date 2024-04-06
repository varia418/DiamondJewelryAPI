using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Persistence.Services;
using DiamondJewelryAPI.Contracts.Products;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

[AllowAnonymous]
public class ProductsController : ApiController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("[controller]")]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request)
    {
        var products = await _productService.GetProducts();
        return Ok(products);
    }
}