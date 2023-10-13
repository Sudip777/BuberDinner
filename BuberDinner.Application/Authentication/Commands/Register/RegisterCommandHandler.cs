using MediatR;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Domain.Entities;
using BuberDinner.Application.Common.Errors;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler: IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler (
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository
         )
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public  async Task <AuthenticationResult> Handle (RegisterCommand command, CancellationToken Token)
    {
        //1. validate the user doesnot exist

        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            throw new DuplicateEmailException();
        }


        // 2.Create user (generate unique ID) and Persist to DB

        var user = new User
        {
            FirstName = command.FirstName, // name
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password

        };
        _userRepository.Add(user);



        //3. Create JWT token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
           user,
            token);
    }
}