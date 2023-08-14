namespace BuberDinner.Application.Services.Authentication;
using OneOf;
using BuberDinner.Application.Common.Errors;


public interface IAuthenticationService
{
    OneOf<AuthenticationResult,IError>  Register(
        string firstName,
        string lastName, 
        string email,  
        string password
        );
    AuthenticationResult Login(
        string email, 
        string password
        );        
}
 