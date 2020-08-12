using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Request;
using WebAPI.DTO.Shop.Request;
using WebAPI.Models;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
  [Route(ApiRoutes.Base)]
  [ApiController]
  public class ShopController : ControllerBase
  {

    private readonly IAuthService _authService;

    public ShopController(IAuthService authService)
    {
      _authService = authService;
    }


    // <---------- GameServer ---------->


    [HttpPost]
    [Route(ApiRoutes.Shop.AddGameServer)]
    public async Task<IActionResult> AddGameServer([FromBody] GameServerRequest gameServerRequest)
    {
      return Ok();
    }

    [HttpPut]
    [Route(ApiRoutes.Shop.EditGameServer)]
    public async Task<IActionResult> EditGameServer([FromBody] GameServerRequest gameServerRequest)
    {
      return Ok();
    }

    [HttpDelete]
    [Route(ApiRoutes.Shop.RemoveGameServer)]
    public async Task<IActionResult> RemoveGameServer([FromBody] GameServerRequest gameServerRequest)
    {
      return Ok();
    }


    // <---------- Category ---------->


    [HttpPost]
    [Route(ApiRoutes.Shop.AddCategory)]
    public async Task<IActionResult> AddCategory([FromBody] CategoryRequest categoryRequest)
    {
      return Ok();
    }

    [HttpPut]
    [Route(ApiRoutes.Shop.EditCategory)]
    public async Task<IActionResult> EditCategory([FromBody] CategoryRequest categoryRequest)
    {
      return Ok();
    }

    [HttpDelete]
    [Route(ApiRoutes.Shop.RemoveCategory)]
    public async Task<IActionResult> RemoveCategory([FromBody] CategoryRequest categoryRequest)
    {
      return Ok();
    }


    // <---------- Item ---------->


    [HttpPost]
    [Route(ApiRoutes.Shop.AddItem)]
    public async Task<IActionResult> AddItem([FromBody] ItemRequest itemRequest)
    {
      return Ok();
    }

    [HttpPut]
    [Route(ApiRoutes.Shop.EditItem)]
    public async Task<IActionResult> EditItem([FromBody] ItemRequest itemRequest)
    {
      return Ok();
    }

    [HttpDelete]
    [Route(ApiRoutes.Shop.RemoveItem)]
    public async Task<IActionResult> RemoveItem([FromBody] ItemRequest itemRequest)
    {
      return Ok();
    }
  }
}
