using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.Contracts.Products;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

[AllowAnonymous]
public class ProductsController : ApiController
{
    [HttpGet("[controller]")]
    public IActionResult GetProducts([FromQuery] GetProductsRequest request)
    {
        return Ok(request);
    }
}