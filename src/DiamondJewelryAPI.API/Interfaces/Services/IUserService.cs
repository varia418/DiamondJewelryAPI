using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface IUserService
{
    Task<ErrorOr<IEnumerable<User>>> GetUsers();
    Task<ErrorOr<User>> GetUser(string id);
    Task<ErrorOr<IEnumerable<string>>> GetUserLikedProducts(string id);
    Task<ErrorOr<bool>> CheckIfProductIsLiked(string userId, string productId);
    Task<ErrorOr<Success>> DeleteUser(string id);
    Task<ErrorOr<User>> GetUserById(string id);
    Task<ErrorOr<User>> CreateUser(User user);
    Task<ErrorOr<User>> UpdateUser(string id, User user);
    Task<ErrorOr<Success>> RemoveLikedProduct(User user, string productId);
    Task<ErrorOr<Success>> RemoveAllLikedProducts(User user);
    Task<ErrorOr<Success>> AddLikedProduct(User user, string productId);
}