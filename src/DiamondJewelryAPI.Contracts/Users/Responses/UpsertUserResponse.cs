using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Users.Responses;
public record UpsertUserResponse(
    UserData User
);