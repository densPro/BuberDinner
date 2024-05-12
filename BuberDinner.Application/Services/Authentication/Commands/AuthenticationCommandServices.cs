using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Commands;
public class AuthenticationCommandServices : IAuthenticationCommandService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public AuthenticationCommandServices(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public ErrorOr<AuthenticationResult> Register(string firsName, string lastName, string email, string password)
  {
    // 1. Validate the user doesn't exist
    if (_userRepository.GetUserByEmail(email) is not null)
    {
      return Errors.User.DuplicateEmail;
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
}