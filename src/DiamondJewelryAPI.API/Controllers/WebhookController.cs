using BuberDinner.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

public class WebhookController : ApiController
{
    [HttpPost()]
    public IActionResult Test()
    {
        return Ok();
    }
}