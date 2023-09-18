namespace BuberDinner.Domain.Common.Errors;
using ErrorOr;

public static  partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict( // error object from errorOr Library
            code: "User.DuplicateEmail", 
            description: "Email is already in use.");
    }
}

