using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.DTO.Auth.Request;
using WebAPI.DTO.Auth.Response;
using WebAPI.Models;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
  [Route(ApiRoutes.Base)]
  [ApiController]
  public class AuthController : ControllerBase
  {

    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
      _authService = authService;
    }

    [HttpPost]
    [Route(ApiRoutes.Auth.SignUp)]
    [ProducesResponseType(typeof(AuthSuccessResponse), 200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> SignUp([FromBody] AuthSignUpRequest authSignUpRequest)
    {

      if (!ModelState.IsValid)
      {
        return BadRequest(new FailedResponse
        {
          Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
        });
      }

      var authResponse = await _authService.SignUpAsync(authSignUpRequest);

      if(!authResponse.Success)
      {
        return BadRequest(new FailedResponse
        {
          Errors = authResponse.Errors
        });
      }

      return Ok(new AuthSuccessResponse
      {
        Token = authResponse.Token
      });
    }

    [HttpPost]
    [Route(ApiRoutes.Auth.SignIn)]
    [ProducesResponseType(typeof(AuthSuccessResponse), 200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> SignIn([FromBody] AuthSignInRequest authSignInRequest)
    {
      var authResponse = await _authService.SignInAsync(authSignInRequest);

      if (!authResponse.Success)
      {
        return BadRequest(new FailedResponse
        {
          Errors = authResponse.Errors
        });
      }

      return Ok(new AuthSuccessResponse
      {
        Token = authResponse.Token
      });
    }

    [HttpPost]
    [Route(ApiRoutes.Auth.CheckByUserName)]
    [ProducesResponseType(200)]
    [ProducesResponseType(422)]
    public async Task<IActionResult> CheckByUserName([FromBody] CheckUserNameRequest userForCheck)
    {
      var user = await _authService.FindByUserNameAsync(userForCheck.UserName);

      if(user != null)
      {
        return UnprocessableEntity();
      }

      return Ok();
    }

  }
}
