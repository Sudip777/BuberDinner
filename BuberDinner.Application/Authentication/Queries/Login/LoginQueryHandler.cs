using MediatR;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginCommandHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository
         )
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task <AuthenticationResult> Handle(LoginQuery query, CancellationToken Token )
    {
        //1. Validate if the user exists or not
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            throw new Exception("User with given email doesnot exist:");
        }



        //2. Validate the password is correct
        if (user.Password != query.Password)
        {
            throw new Exception("Invalid Password");

        }

        //3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    
       
}