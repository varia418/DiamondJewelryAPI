namespace DiamondJewelryAPI.Contracts.Auth.Requests;

public record SignInRequest(
    string Email,
    string Password
);