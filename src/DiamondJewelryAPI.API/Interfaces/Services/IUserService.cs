using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Services;

public interface IUserService
{
    Task<ErrorOr<IEnumerable<User>>> GetUsers();

}