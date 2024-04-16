using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface IAuthService
{
    Task<ErrorOr<Success>> SignUp(User user);
    Task<ErrorOr<AuthResult>> SignIn();
    Task<ErrorOr<AuthResult>> OAuthSignIn();
}