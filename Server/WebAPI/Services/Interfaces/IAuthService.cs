using Entities.Models;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.DTO.Auth.Request;

namespace WebAPI.Services.Interfaces
{
  public interface IAuthService
  {

    Task<AuthenticationResult> SignUpAsync(AuthSignUpRequest authSignUpRequest);
    Task<AuthenticationResult> SignInAsync(AuthSignInRequest authSignInRequest);
    Task<User> FindByUserNameAsync(string userName);
  }
}
