using BuberDinner.Contracts.Authentication;
using BuberDinner.Application.Services.Authentication.Queries;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Commands;



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
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;


        public AuthenticationController(IAuthenticationCommandService authenticationService, IAuthenticationQueryService authenticationQueryService)
        {
            _authenticationCommandService = authenticationService;
            _authenticationQueryService = authenticationQueryService;

        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            AuthenticationResult authResult = _authenticationCommandService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            return Ok(MapAuthResult(authResult));


      
          
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
            var authResult = _authenticationQueryService.Login(
                request.Email,
                request.Password);

            /*var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);*/

            var authenticationResult = MapAuthResult(authResult);

            return Ok(authenticationResult);
        }
    }
}
