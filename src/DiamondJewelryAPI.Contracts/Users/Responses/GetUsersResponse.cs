using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Users.Responses;

public record GetUsersResponse(
    UserData[] Users
);