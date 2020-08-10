using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.DTO.Request;

namespace WebAPI.Services.Interfaces
{
  public interface IAuthService
  {

    Task<AuthenticationResult> SignUpAsync(AuthSignUpRequest authSignUpRequest);
    Task<AuthenticationResult> SignInAsync(AuthSignInRequest authSignInRequest);

  }
}
