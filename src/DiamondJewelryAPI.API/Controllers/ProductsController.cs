using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Services;
using DiamondJewelryAPI.Contracts.Products;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

[AllowAnonymous]
public class ProductsController : ApiController
{
    private readonly MongoDBService _mongoDBService;

    public ProductsController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet("[controller]")]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request)
    {
        var products = await _mongoDBService.GetProducts();
        return Ok(products);
    }
}