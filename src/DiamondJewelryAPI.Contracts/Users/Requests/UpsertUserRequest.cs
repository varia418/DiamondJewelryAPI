
using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Users.Requests;
public record UpsertUserRequest(
    UserData User
);