using System.Collections.Generic;
using System.Runtime.InteropServices;
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
      var createdGameServer = await _shopService.CreateGameServerAsync(gameServerRequest, HttpContext.GetUserId());

      if (createdGameServer == null)
      {
        return BadRequest(new FailedResponse { Errors = new List<string> { "Game server already exists" } });
      }

      return Ok(createdGameServer); 
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.EditGameServer)]
    [ProducesResponseType(typeof(GameServerResponse), 200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> EditGameServer([FromBody] EditGameServerRequest gameServerRequest)
    {
      var editedGameServer = await _shopService.EditGameServerAsync(gameServerRequest);

      if (editedGameServer == null)
      {
        return BadRequest(new FailedResponse { Errors = new List<string> { "Game server not found" } });
      }

      return Ok(editedGameServer);
    }

    [HttpDelete]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.RemoveGameServer)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> RemoveGameServer([FromBody] GameServerRequest gameServerRequest)
    {
      var removedServer = await _shopService.RemoveGameServerAsync(gameServerRequest);

      if (!removedServer)
        return BadRequest(new FailedResponse { Errors = new List<string> { "Game server not found" } });
      else
        return Ok();
    }


    // <---------- Category ---------->


    [HttpPost]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.AddCategory)]
    public async Task<IActionResult> AddCategory([FromBody] CategoryRequest categoryRequest)
    {
      var isGameServerExists = await _shopService.IsGameServerExistsAsync(categoryRequest.GameServerId);

      if (!isGameServerExists)
      {
        return BadRequest(new FailedResponse { Errors = new List<string> { "Game server is not exist" } });
      }

      var createdCategory = await _shopService.CreateCategoryAsync(categoryRequest, HttpContext.GetUserId());

      if (createdCategory == null)
      {
        return BadRequest(new FailedResponse { Errors = new List<string> { "Category already exists" } });
      }

      return Ok(createdCategory);
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.EditCategory)]
    public async Task<IActionResult> EditCategory([FromBody] EditCategoryRequest editCategoryRequest)
    {
      var editedCategory = await _shopService.EditCategoryAsync(editCategoryRequest);

      if (editedCategory == null)
      {
        return BadRequest(new FailedResponse { Errors = new List<string> { "Category not found" } });
      }

      return Ok(editedCategory);
    }

    [HttpDelete]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.RemoveCategory)]
    public async Task<IActionResult> RemoveCategory([FromBody] DeleteCategoryRequest categoryRequest)
    {
      var removedCategory = await _shopService.RemoveCategoryAsync(categoryRequest);

      if (!removedCategory)
        return BadRequest(new FailedResponse { Errors = new List<string> { "Category not found" } });
      else
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
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> GetItems([FromBody] GetItemsRequest getItemsRequest)
    {

      if(getItemsRequest.ItemsForSearch == null)
      {
        return BadRequest(new FailedResponse { Errors = new List<string> { "The ItemsForSearch field is required" } });
      }

      var items = await _shopService.GetPaginatedItemsAsync(getItemsRequest);

      return Ok(items);
    }

  }
}
