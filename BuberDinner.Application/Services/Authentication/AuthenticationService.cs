
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;   
    }
     

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        
        //1. validate the user doesnot exist

        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailException();
        }


        // 2.Create user (generate unique ID) and Persist to DB

        var user = new User
        {
            FirstName = firstName, // name
            LastName = lastName,
            Email = email,
            Password = password

        };
        _userRepository.Add(user);



        //3. Create JWT token

        var token = _jwtTokenGenerator.GenerateToken(user);
        
       return new AuthenticationResult(
          user, 
           token);
    }

    public AuthenticationResult Login(
             string email,
             string password)
    {
        //1. Validate if the user exists or not
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return new Exception("User with given email doesnot exist:");
        }

          

        //2. Validate the password is correct
        if (user.Password != password)
        {
            return new  Exception("Invalid Password");

        }

        //3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
   
