using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.DTO.Pagination.Response;
using WebAPI.DTO.Request;
using WebAPI.DTO.Shop.Request;
using WebAPI.DTO.Shop.Response;
using WebAPI.Extensions;
using WebAPI.Helpers;
using WebAPI.Models;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{

  [Route(ApiRoutes.Base)]
  [ApiController]
  public class ShopController : ControllerBase
  {

    private readonly IShopService _shopService;

    public ShopController(IShopService shopService)
    {
      _shopService = shopService;
    }


    // <---------- GameServer ---------->


    [HttpPost]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.AddGameServer)]
    [ProducesResponseType(typeof(GameServerResponse), 200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> AddGameServer([FromBody] GameServerRequest gameServerRequest)
    {
      var created = await _shopService.CreateGameServerAsync(gameServerRequest, HttpContext.GetUserId());
      if (created != null)
      {
        return Ok(created);
      }

      return BadRequest(new FailedResponse { Errors = new List<string> { "Game server already exists" } });
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.EditGameServer)]
    public async Task<IActionResult> EditGameServer([FromBody] GameServerRequest gameServerRequest)
    {
      return Ok();
    }

    [HttpDelete]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.RemoveGameServer)]
    public async Task<IActionResult> RemoveGameServer([FromBody] GameServerRequest gameServerRequest)
    {
      return Ok();
    }


    // <---------- Category ---------->


    [HttpPost]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.AddCategory)]
    public async Task<IActionResult> AddCategory([FromBody] CategoryRequest categoryRequest)
    {
      return Ok();
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.EditCategory)]
    public async Task<IActionResult> EditCategory([FromBody] CategoryRequest categoryRequest)
    {
      return Ok();
    }

    [HttpDelete]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.RemoveCategory)]
    public async Task<IActionResult> RemoveCategory([FromBody] CategoryRequest categoryRequest)
    {
      return Ok();
    }

    // <---------- Item ---------->


    [HttpPost]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.AddItem)]
    public async Task<IActionResult> AddItem([FromBody] TransformItemRequest itemRequest)
    {
      return Ok();
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.EditItem)]
    public async Task<IActionResult> EditItem([FromBody] TransformItemRequest itemRequest)
    {
      return Ok();
    }

    [HttpDelete]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.RemoveItem)]
    public async Task<IActionResult> RemoveItem([FromBody] TransformItemRequest itemRequest)
    {
      return Ok();
    }

    [HttpPost]
    [Route(ApiRoutes.Shop.GetItems)]
    [ProducesResponseType(typeof(PagedResponse<ItemResponse>), 200)]
    public async Task<IActionResult> GetItems([FromBody] GetItemsRequest getItemsRequest)
    {
      var items = await _shopService.GetItemsAsync(getItemsRequest, getItemsRequest.PaginationQuery);

      return Ok(PaginationHelper.CreatePaginatedResponse(getItemsRequest.PaginationQuery, items));
    }

  }
}
