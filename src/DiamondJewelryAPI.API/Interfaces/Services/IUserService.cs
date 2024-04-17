using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface IUserService
{
    Task<ErrorOr<IEnumerable<User>>> GetUsers();
    Task<ErrorOr<User>> CreateUser(User user);
    Task<ErrorOr<User>> UpdateUser(string id, User user);
}