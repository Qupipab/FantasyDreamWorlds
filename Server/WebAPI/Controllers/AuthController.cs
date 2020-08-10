using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Request;
using WebAPI.DTO.Response;
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
    public async Task<IActionResult> SignUp([FromBody] AuthSignUpRequest authSignUpRequest)
    {

      if (!ModelState.IsValid)
      {
        return BadRequest(new AuthFailedResponse
        {
          Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
        });
      }

      var authResponse = await _authService.SignUpAsync(authSignUpRequest);

      if(!authResponse.Success)
      {
        return BadRequest(new AuthFailedResponse
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
    public async Task<IActionResult> SignIn([FromBody] AuthSignInRequest authSignInRequest)
    {
      var authResponse = await _authService.SignInAsync(authSignInRequest);

      if (!authResponse.Success)
      {
        return BadRequest(new AuthFailedResponse
        {
          Errors = authResponse.Errors
        });
      }

      return Ok(new AuthSuccessResponse
      {
        Token = authResponse.Token
      });
    }

  }
}
