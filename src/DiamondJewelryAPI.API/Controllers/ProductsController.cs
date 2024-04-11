using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Persistence.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Products.Requests;

using ErrorOr;

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

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request)
    {
        ErrorOr<IEnumerable<Product>> getProductsResult = await _productService.GetProducts();

        return getProductsResult.Match(
            products => Ok(products),
            errors => Problem(errors)
        );
    }
}