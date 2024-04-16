using BuberDinner.Api.Controllers;

using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.Contracts.Auth.Requests;
using DiamondJewelryAPI.Contracts.Common;

using ErrorOr;

using MapsterMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiamondJewelryAPI.API.Controllers;

[AllowAnonymous]
public class AuthController : ApiController
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public AuthController(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(UserData request)
    {
        User user = _mapper.Map<User>(request);
        ErrorOr<Success> signUpResult = await _authService.SignUp(user);

        return signUpResult.Match(
            product => Ok(),
            errors => Problem(errors));
    }

    [HttpPost("signin/user")]
    public IActionResult SignIn(SignInRequest request)
    {
        return Ok(request);
    }

    [HttpPost("signin/admin")]
    public IActionResult AdminSignIn(SignInRequest request)
    {
        return Ok(request);
    }

    [HttpPost("signin/oauth2")]
    public IActionResult OAuthSignIn(UserData request)
    {
        return Ok(request);
    }
}