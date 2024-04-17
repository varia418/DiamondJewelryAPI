using DiamondJewelryAPI.API.Common.Errors;
using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;

using ErrorOr;

namespace DiamondJewelryAPI.API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public UserService(IUserRepository userRepository, IProductRepository productRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Success>> AddLikedProduct(User user, string productId)
    {
        if (user.FavoriteProducts.Contains(productId))
        {
            return Errors.User.DuplicatedLikedProductId;
        }

        var getProductResult = await _productRepository.GetById(productId);

        if (getProductResult.IsError)
        {
            return getProductResult.Errors;
        }

        user.FavoriteProducts.Add(productId);
        var result = await _userRepository.Update(user.Id!, user);

        if (result.IsError)
        {
            return result.Errors;
        }

        return Result.Success;
    }

    public async Task<ErrorOr<bool>> CheckIfProductIsLiked(string userId, string productId)
    {
        var getUserResult = await _userRepository.GetById(userId);

        if (getUserResult.IsError) return getUserResult.Errors;

        return getUserResult.Value.FavoriteProducts.Contains(productId);
    }

    public async Task<ErrorOr<User>> CreateUser(User user)
    {
        return await _userRepository.Create(user);
    }

    public async Task<ErrorOr<Success>> DeleteUser(string id)
    {
        return await _userRepository.Delete(id);
    }

    public async Task<ErrorOr<User>> GetUser(string id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<ErrorOr<User>> GetUserById(string id)
    {
        var user = await _userRepository.GetById(id);
        return user;
    }

    public async Task<ErrorOr<IEnumerable<string>>> GetUserLikedProducts(string id)
    {
        var getUserResult = await _userRepository.GetById(id);

        if (getUserResult.IsError) return getUserResult.Errors;

        return getUserResult.Value.FavoriteProducts.ToArray();
    }

    public async Task<ErrorOr<IEnumerable<User>>> GetUsers()
    {
        ErrorOr<IEnumerable<User>> result = await _userRepository.GetAll();
        return result;
    }

    public async Task<ErrorOr<Success>> RemoveAllLikedProducts(User user)
    {
        user.FavoriteProducts.Clear();
        var result = await _userRepository.Update(user.Id!, user);

        if (result.IsError)
        {
            return result.Errors;
        }

        return Result.Success;
    }

    public async Task<ErrorOr<Success>> RemoveLikedProduct(User user, string productId)
    {
        user.FavoriteProducts.Remove(productId);
        var result = await _userRepository.Update(user.Id!, user);

        if (result.IsError)
        {
            return result.Errors;
        }

        return Result.Success;
    }

    public async Task<ErrorOr<User>> UpdateUser(string id, User user)
    {
        return await _userRepository.Update(id, user);

    }
}