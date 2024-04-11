namespace DiamondJewelryAPI.Contracts.Auth.Responses;

public record SignInResponse(
    string UserId,
    string Token
);