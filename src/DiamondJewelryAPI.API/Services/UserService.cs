using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<User>> CreateUser(User user)
    {
        return await _userRepository.Create(user);
    }

    public async Task<ErrorOr<IEnumerable<User>>> GetUsers()
    {
        ErrorOr<IEnumerable<User>> result = await _userRepository.GetAll();
        return result;
    }

    public async Task<ErrorOr<User>> UpdateUser(string id, User user)
    {
        return await _userRepository.Update(id, user);

    }
}