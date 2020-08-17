using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Policy;
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

      if (!createdGameServer.Success)
      {
        return BadRequest(createdGameServer.Errors);
      }

      return Ok(createdGameServer.Response);
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.EditGameServer)]
    [ProducesResponseType(typeof(GameServerResponse), 200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> EditGameServer([FromBody] EditGameServerRequest gameServerRequest)
    {
      var editedGameServer = await _shopService.EditGameServerAsync(gameServerRequest);

      if (!editedGameServer.Success)
      {
        return BadRequest(editedGameServer.Errors);
      }

      return Ok(editedGameServer.Response);
    }

    [HttpDelete]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.RemoveGameServer)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> RemoveGameServer([FromBody] GameServerRequest gameServerRequest)
    {
      var removedServer = await _shopService.RemoveGameServerAsync(gameServerRequest);

      if (!removedServer.Success)
        return BadRequest(removedServer.Errors);
      else
        return Ok("The server has been removed");
    }

    [HttpGet]
    [Route(ApiRoutes.Shop.GetGameServers)]
    [ProducesResponseType(typeof(ICollection<GameServerResponse>), 200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> GetGameServers()
    {
      var gameServers = await _shopService.GetGameServersAsync();

      if(!gameServers.Success)
      {
        return BadRequest(gameServers.Errors);
      }

      return Ok(gameServers.Response);
    }



    // <---------- Category ---------->


    [HttpPost]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.AddCategory)]
    [ProducesResponseType(typeof(CategoryResponse), 200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> AddCategory([FromBody] CategoryRequest categoryRequest)
    {
      var createdCategory = await _shopService.CreateCategoryAsync(categoryRequest, HttpContext.GetUserId());

      if (!createdCategory.Success)
      {
        return BadRequest(createdCategory.Errors);
      }

      return Ok(createdCategory.Response);
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.EditCategory)]
    [ProducesResponseType(typeof(CategoryResponse), 200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> EditCategory([FromBody] EditCategoryRequest editCategoryRequest)
    {
      var editedCategory = await _shopService.EditCategoryAsync(editCategoryRequest);

      if (!editedCategory.Success)
      {
        return BadRequest(editedCategory.Errors);
      }

      return Ok(editedCategory.Response);
    }

    [HttpDelete]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.RemoveCategory)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> RemoveCategory([FromBody] DeleteCategoryRequest categoryRequest)
    {
      var removedCategory = await _shopService.RemoveCategoryAsync(categoryRequest);

      if (!removedCategory.Success)
        return BadRequest(removedCategory.Errors);
      else
        return Ok("The category has been removed");
    }

    [HttpPost]
    [Route(ApiRoutes.Shop.GetCategories)]
    [ProducesResponseType(typeof(ICollection<GameServerResponse>), 200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> GetCategories([FromBody] GetCategoryRequest categoryRequest)
    {
      var categories = await _shopService.GetCategoriesAsync(categoryRequest);

      if (!categories.Success)
      {
        return BadRequest(categories.Errors);
      }

      return Ok(categories.Response);
    }

    // <---------- Item ---------->


    [HttpPost]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.AddItem)]
    [ProducesResponseType(typeof(ItemResponse), 200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> AddItem([FromBody] ItemRequest itemRequest)
    {
      var createdItem = await _shopService.CreateItemAsync(itemRequest, HttpContext.GetUserId());

      if (!createdItem.Success)
      {
        return BadRequest(createdItem.Errors);
      }

      return Ok(createdItem.Response);
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.EditItem)]
    [ProducesResponseType(typeof(ItemResponse), 200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> EditItem([FromBody] EditItemRequest editItemRequest)
    {
      var editedItem = await _shopService.EditItemAsync(editItemRequest);

      if (!editedItem.Success)
      {
        return BadRequest(editedItem.Errors);
      }

      return Ok(editedItem.Response);
    }

    [HttpDelete]
    [Authorize(AuthenticationSchemes = ApiRoutes.AuthScheme, Roles = "Admin")]
    [Route(ApiRoutes.Shop.RemoveItem)]
    [ProducesResponseType(200)]
    [ProducesResponseType(typeof(FailedResponse), 400)]
    public async Task<IActionResult> RemoveItem([FromBody] DeleteItemRequest itemRequest)
    {
      var removedItem = await _shopService.RemoveItemAsync(itemRequest);

      if (!removedItem.Success)
        return BadRequest(removedItem.Errors);
      else
        return Ok("The item has been removed");
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
