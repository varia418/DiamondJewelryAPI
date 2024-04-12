using BuberDinner.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

[AllowAnonymous]
public class AuthController : ApiController
{
    [HttpGet("[controller]")]
    public IActionResult SignUp()
    {
        return Problem();
    }
}