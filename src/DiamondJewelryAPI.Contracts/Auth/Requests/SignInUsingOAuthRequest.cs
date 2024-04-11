using DiamondJewelryAPI.Contracts.Common;

namespace DiamondJewelryAPI.Contracts.Auth.Requests;

public record SignInUsingOAuthRequest(
    User User
);