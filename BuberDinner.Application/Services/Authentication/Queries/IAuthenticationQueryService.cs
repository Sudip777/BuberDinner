namespace BuberDinner.Application.Services.Authentication.Queries;
using BuberDinner.Application.Services.Authentication.Common;


public interface IAuthenticationQueryService
{
    AuthenticationResult Login(string email, string password);
}