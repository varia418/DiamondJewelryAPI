using ErrorOr;

namespace DiamondJewelryAPI.API.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error IncorrectEmail => Error.Validation(
            code: "User.IncorrectEmail",
            description: "Incorrect email address.");
        public static Error IncorrectPassword => Error.Validation(
            code: "User.IncorrectPassword",
            description: "Incorrect password.");
    }
}