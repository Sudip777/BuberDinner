namespace BuberDinner.Domain.Common.Errors;
using ErrorOr; //from ErrorOr Package

public static partial class Errors
{
    public static  class Authentication
    {
        public static Error InvalidCredentials => Error.Conflict( // error object from errorOr Library
            code: "Auth.InvalidCred", 
            description: "Invalid Credentials");
    }
}

