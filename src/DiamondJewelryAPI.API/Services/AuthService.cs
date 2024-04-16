using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;


namespace DiamondJewelryAPI.API.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<ErrorOr<AuthResult>> OAuthSignIn()
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<AuthResult>> SignIn()
    {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<Success>> SignUp(User user)
    {
        var registeredUser = await _userRepository.Create(user);
        return Result.Success;
    }
}