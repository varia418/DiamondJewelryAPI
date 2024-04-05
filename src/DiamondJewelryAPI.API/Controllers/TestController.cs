using BuberDinner.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

[AllowAnonymous]
public class TestController : ApiController
{
    [HttpGet("[controller]")]
    public IActionResult Test()
    {
        return Problem();
    }
}