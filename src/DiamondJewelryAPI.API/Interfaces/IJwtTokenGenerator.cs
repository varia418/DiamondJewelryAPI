
using DiamondJewelryAPI.API.Models;

namespace DiamondJewelryAPI.API.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}