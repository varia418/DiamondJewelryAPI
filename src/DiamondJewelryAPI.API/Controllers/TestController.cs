using BuberDinner.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

[AllowAnonymous]
public class AuthenticationsController : ApiController
{
    [HttpGet("/test")]
    public IActionResult Test()
    {
        return Problem();
    }
}