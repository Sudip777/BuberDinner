namespace BuberDinner.Application.Services.Authentication;
using FluentResults;
using BuberDinner.Application.Common.Errors;


public interface IAuthenticationService
{
    Result<AuthenticationResult>  Register(
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
 