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

    [HttpPost]
    public async Task<IActionResult> CreateProduct(UserData request)
    {
        User user = _mapper.Map<User>(request);
        ErrorOr<User> createUserResult = await _userService.CreateUser(user);

        return createUserResult.Match(
            user => Ok(_mapper.Map<UserData>(user)),
            errors => Problem(errors));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UserData request)
    {
        User user = _mapper.Map<User>(request);

        if (user.Id is null) return BadRequest();

        ErrorOr<User> createProductsResult = await _userService.UpdateUser(user.Id, user);

        return createProductsResult.Match(
            user => Ok(_mapper.Map<UserData>(user)),
            errors => Problem(errors));
    }

    [HttpPut("removeLikedProduct/{userId}")]
    public async Task<IActionResult> RemoveLikedProduct([FromRoute] string userId, [FromBody] string productId)
    {
        // TODO: Check for user existence
        ErrorOr<User> findUserResult = await _userService.GetUserById(userId);
        if (findUserResult.IsError) return Problem(findUserResult.Errors);

        ErrorOr<Success> removeLikedProductResult = await _userService.RemoveLikedProduct(findUserResult.Value, productId);

        return removeLikedProductResult.Match(
            success => NoContent(),
            errors => Problem(errors));
    }
}