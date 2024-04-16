using DiamondJewelryAPI.API.Common.Errors;
using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IMongoContext context) : base(context)
    {
    }

    public ErrorOr<User> GetByEmail(string email)
    {
        var user = QueryableCollection
            .FirstOrDefault(u => u.Email == email);

        if (user is null)
        {
            return Errors.User.IncorrectEmail;
        }

        return user;
    }
}