using BuberDinner.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

public class TestController : ApiController
{
    [HttpGet()]
    public IActionResult Test()
    {
        return Ok();
    }
}