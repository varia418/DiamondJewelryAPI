using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Common;

using ErrorOr;

using MapsterMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

[AllowAnonymous]
public class UsersController : ApiController
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        ErrorOr<IEnumerable<User>> getUsersResult = await _userService.GetUsers();

        return getUsersResult.Match(
            users => Ok(_mapper.Map<IEnumerable<UserData>>(users)),
            errors => Problem(errors)
        );
    }
}