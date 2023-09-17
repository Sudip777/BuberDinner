namespace BuberDinner.Application.Services.Authentication;
using ErrorOr;
using BuberDinner.Application.Common.Errors;


public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult>  Register(
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
 