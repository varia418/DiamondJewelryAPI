using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface IAuthService
{
    Task<ErrorOr<Success>> SignUp(User user);
    ErrorOr<AuthResult> SignIn(string email, string password);
    Task<ErrorOr<AuthResult>> OAuthSignIn();
}