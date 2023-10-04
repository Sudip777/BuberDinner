using BuberDinner.Contracts.Authentication;
using BuberDinner.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BuberDinner.Domain.Entities;
using BuberDinner.Application.Common.Errors;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            Result<AuthenticationResult> authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            if (registerResult.IsSuccess)
            {
                return Ok(MapAuthResult(registerResult.Value));
            }

            var firstError = registerResult.Errors[0];

            if(firstError is DuplicateEmailError)
            {
                return Problem(statusCode: StatusCodes.Status409Conflict, detail: "Email already Exists");
            }
            return Problem();

      
          
        }


        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                    authResult.User.Id,
                    authResult.User.FirstName,
                      authResult.User.LastName,
                    authResult.User.Email,
                    authResult.Token);
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(
                request.Email,
                request.Password);

            /*var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);*/

            var authenticationResult = authResult.Match<AuthenticationResponse>(authResult => MapAuthResult(authResult),
                ErrorEventArgs => throw new Exception());

            return Ok(authenticationResult);
        }
    }
}
