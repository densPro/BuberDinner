using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using OneOf;

namespace BuberDinner.Application.Services;
public class AuthenticationServices : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public AuthenticationServices(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public OneOf<AuthenticationResult, DuplicateEmailError>  Register(string firsName, string lastName, string email, string password)
  {
    // 1. Validate the user doesn't exist
    if (_userRepository.GetUserByEmail(email) is not null)
    {
      return new DuplicateEmailError();
    }

    // 2. Create user (generate unique ID) & Persist to DB
    var user = new User()
    {
      FirstName = firsName,
      LastName = lastName,
      Email = email,
      Password = password
    };

    _userRepository.Add(user);

    //Create JWT Token
    var token = _jwtTokenGenerator.GenerateToken(user);
    return new AuthenticationResult(
      user,
      token
    );
  }

  public AuthenticationResult Login(string email, string password)
  {
    // 1. Validate the user doesn't exist
    if (_userRepository.GetUserByEmail(email) is not User user)
    {
      throw new Exception("User with given email dosn't exists");
    }

    // 2. Validate the password is correct
    if (user.Password != password)
    {
      throw new Exception("Invalid password");
    }

    // 3.  Create JWT Token
    var token = _jwtTokenGenerator.GenerateToken(user);
    return new AuthenticationResult(
      user,
      token
    );
  }
}