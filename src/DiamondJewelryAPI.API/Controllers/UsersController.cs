using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Common;

using ErrorOr;

using MapsterMapper;

using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        ErrorOr<User> getUserResult = await _userService.GetUser(id);

        return getUserResult.Match(
            user => Ok(_mapper.Map<UserData>(user)),
            errors => Problem(errors)
        );
    }

    [HttpGet("likedProducts/{userId}")]
    public async Task<IActionResult> GetLikedProducts(string userId)
    {
        ErrorOr<IEnumerable<Product>> getUserLikedProductsResult = await _userService.GetUserLikedProducts(userId);

        return getUserLikedProductsResult.Match(
            likedProducts => Ok(likedProducts),
            errors => Problem(errors)
        );
    }

    [HttpGet("existsLikedProduct/{userId}")]
    public async Task<IActionResult> CheckIfProductIsLiked(string userId, [FromQuery] string productId)
    {
        ErrorOr<bool> checkResult = await _userService.CheckIfProductIsLiked(userId, productId);

        return checkResult.Match(
            result => Ok(result),
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
        ErrorOr<User> findUserResult = await _userService.GetUserById(userId);
        if (findUserResult.IsError) return Problem(findUserResult.Errors);

        ErrorOr<Success> removeLikedProductResult = await _userService.RemoveLikedProduct(findUserResult.Value, productId);

        return removeLikedProductResult.Match(
            success => NoContent(),
            errors => Problem(errors));
    }

    [HttpPut("removeAllLikedProduct/{userId}")]
    public async Task<IActionResult> RemoveAllLikedProducts([FromRoute] string userId)
    {
        ErrorOr<User> findUserResult = await _userService.GetUserById(userId);
        if (findUserResult.IsError) return Problem(findUserResult.Errors);

        ErrorOr<Success> removeAllLikedProductsResult = await _userService.RemoveAllLikedProducts(findUserResult.Value);

        return removeAllLikedProductsResult.Match(
            success => NoContent(),
            errors => Problem(errors));
    }

    [HttpPut("addLikedProduct/{userId}")]
    public async Task<IActionResult> AddLikedProduct([FromRoute] string userId, [FromBody] string productId)
    {
        ErrorOr<User> findUserResult = await _userService.GetUserById(userId);
        if (findUserResult.IsError) return Problem(findUserResult.Errors);

        ErrorOr<Success> addLikedProductResult = await _userService.AddLikedProduct(findUserResult.Value, productId);

        return addLikedProductResult.Match(
            success => NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        ErrorOr<Success> getUserResult = await _userService.DeleteUser(id);

        return getUserResult.Match(
            user => NoContent(),
            errors => Problem(errors)
        );
    }
}