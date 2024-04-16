using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;

public interface IUserRepository : IRepository<User>
{
    ErrorOr<User> GetByEmail(string email);
}
