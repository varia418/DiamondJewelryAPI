using DiamondJewelryAPI.API.Common.Errors;
using DiamondJewelryAPI.API.Interfaces;
using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<ErrorOr<AuthResult>> OAuthSignIn()
    {
        throw new NotImplementedException();
    }

    public ErrorOr<AuthResult> SignIn(string email, string password)
    {
        var result = _userRepository.GetByEmail(email);

        if (result.IsError)
        {
            return result.Errors;
        }

        var user = result.Value;

        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            return Errors.User.IncorrectPassword;
        }

        var tokenString = _jwtTokenGenerator.GenerateToken(user);
        return new AuthResult(user.Id, tokenString);
    }

    public async Task<ErrorOr<Success>> SignUp(User user)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.Password = passwordHash;

        var registeredUser = await _userRepository.Create(user);
        return Result.Success;
    }
}