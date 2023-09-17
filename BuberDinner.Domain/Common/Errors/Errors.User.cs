namespace BuberDinner.Domain.Common.Errors;
using ErrorOr; //from ErrorOr Package

public static class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict( //from errorOr Library
            code: "User.DuplicateEmail", 
            description: "Email is already in use.");
    }
}

