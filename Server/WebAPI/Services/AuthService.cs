using Entities.Models;
using Entities.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.DTO.Auth.Request;
using WebAPI.Options;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
  public class AuthService : IAuthService
  {

    private readonly IUserRepository _userRepository;
    private readonly JwtSettings _jwtSettings;
    public AuthService(IUserRepository userRepository, JwtSettings jwtSettings)
    {
      _userRepository = userRepository;
      _jwtSettings = jwtSettings;
    }

    public async Task<AuthenticationResult> SignUpAsync(AuthSignUpRequest authSignUpRequest)
    {
      var existingUser = await _userRepository.FindByEmailAsync(authSignUpRequest.Email);

      if (existingUser != null)
      {
        return new AuthenticationResult
        {
          Errors = new[] { "User with this email address already exists" }
        };
      }

      var newUser = new User
      {
        UserName = authSignUpRequest.UserName,
        Email = authSignUpRequest.Email,
        RegistrationDate = DateTime.UtcNow,
        LastActivity = DateTime.UtcNow,
        DonateRole = DonateRole.User
      };

      var createdUser = _userRepository.CreateUserAsync(newUser, authSignUpRequest.Password);

      if (!createdUser.Result.Succeeded)
      {
        return new AuthenticationResult
        {
          Errors = createdUser.Result.Errors.Select(e => e.Description)
        };
      }

      return GenerateAuthenticationResultForUser(newUser);
    }

    public async Task<AuthenticationResult> SignInAsync(AuthSignInRequest authSignInRequest)
    {

      var user = await FindByUserNameOrEmailAsync(authSignInRequest.UserNameOrEmail);

      if (user == null)
      {
        return new AuthenticationResult
        {
          Errors = new[] { "User does not exist" }
        };
      }

      var userHasValidPassword = await _userRepository.CheckPasswordAsync(user, authSignInRequest.Password);

      if (!userHasValidPassword)
      {
        return new AuthenticationResult
        {
          Errors = new[] { "Password is not valid" }
        };
      }

      return GenerateAuthenticationResultForUser(user);
    }

    private AuthenticationResult GenerateAuthenticationResultForUser(User user)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

      var claims = new List<Claim>
        {
          new Claim("id", user.Id),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
          new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
          new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddHours(2),
        SigningCredentials =
          new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return new AuthenticationResult
      {
        Success = true,
        Token = tokenHandler.WriteToken(token)
      };
    }

    public async Task<User> FindByUserNameAsync(string userName)
    {
      return await _userRepository.FindByUserNameAsync(userName);
    }

    private async Task<User> FindByEmailAsync(string email)
    {
      return await _userRepository.FindByEmailAsync(email);
    }

    private async Task<User> FindByUserNameOrEmailAsync(string userNameOrEmail)
    {
      var user = await FindByUserNameAsync(userNameOrEmail);

      if (user == null)
      {
        user = await FindByEmailAsync(userNameOrEmail);
      }

      return user;
    }

  }
}
