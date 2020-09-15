using AutoMapper;
using Entities.Helpers;
using Entities.Models;
using Entities.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.DTO.Pagination.Response;
using WebAPI.DTO.Request;
using WebAPI.DTO.Shop.Request;
using WebAPI.DTO.Shop.Response;
using WebAPI.Helpers;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{

  public class ShopService : IShopService
  {

    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;

    public ShopService(IShopRepository shopRepository, IMapper mapper)
    {
      _shopRepository = shopRepository;
      _mapper = mapper;
    }


    // <---------- GameServer ---------->


    public async Task<ResponseResult<GameServerResponse>> CreateGameServerAsync(GameServerRequest gameServerRequest, string creatorId)
    {
      var dateNow = DateTimeOffset.UtcNow;

      gameServerRequest.Title.ToLower();

      var gameServer = _mapper.Map<GameServer>(gameServerRequest);

      gameServer.CreatorId = Guid.Parse(creatorId);
      gameServer.CreatedAt = dateNow;
      gameServer.UpdatedAt = dateNow;

      var createdGameServer = await _shopRepository.CreateGameServerAsync(gameServer);

      if(createdGameServer == null)
      {
        return new ResponseResult<GameServerResponse>
        {
          Errors = new[] { "Game server already exists" }
        };
      }

      var mappedGameServerResponse = _mapper.Map<GameServerResponse>(createdGameServer);

      return new ResponseResult<GameServerResponse>
      {
        Success = true,
        Response = mappedGameServerResponse
      };
    }
    
    public async Task<ResponseResult<GameServerResponse>> EditGameServerAsync(EditGameServerRequest editGameServer)
    {
      var editedGameServer = await _shopRepository.EditGameServerAsync(editGameServer.NewTitle, editGameServer.OldTitle);

      if (editedGameServer == null)
      {
        return new ResponseResult<GameServerResponse>
        {
          Errors = new[] { "Game server not found" }
        };
      }

      var mappedGameServerResponse = _mapper.Map<GameServerResponse>(editedGameServer);

      return new ResponseResult<GameServerResponse>
      {
        Success = true,
        Response = mappedGameServerResponse
      };
    }

    public async Task<ResponseResult<bool>> RemoveGameServerAsync(GameServerRequest gameServerRequest)
    {
      var gameServer = _mapper.Map<GameServer>(gameServerRequest);

      var removedGameServer = await _shopRepository.RemoveGameServerAsync(gameServer);

      if (!removedGameServer)
      {
        return new ResponseResult<bool>
        {
          Errors = new[] { "Game server not found" }
        };
      }

      return new ResponseResult<bool>
      {
        Success = true
      };
    }

    public async Task<ResponseResult<ICollection<GameServerResponse>>> GetGameServersAsync()
    {
      var gameServers = await _shopRepository.GetGameServersAsync();
      
      var mappedGameServers = _mapper.Map<ICollection<GameServerResponse>>(gameServers);

      return new ResponseResult<ICollection<GameServerResponse>>
      {
        Success = true,
        Response = mappedGameServers
      };
    }
    

    // <---------- Category ---------->


    public async Task<ResponseResult<CategoryResponse>> CreateCategoryAsync(CategoryRequest categoryRequest, string creatorId)
    {

      var isGameServerExists = await _shopRepository.IsGameServerExistsAsync(categoryRequest.GameServerId);

      if(!isGameServerExists)
      {
        return new ResponseResult<CategoryResponse>
        {
          Errors = new[] { "Game server is not exist" }
        };
      }

      var dateNow = DateTimeOffset.UtcNow;

      var category = _mapper.Map<Category>(categoryRequest);

      category.CreatorId = Guid.Parse(creatorId);
      category.CreatedAt = dateNow;
      category.UpdatedAt = dateNow;

      var createdCategory = await _shopRepository.CreateCategoryAsync(category);

      if (createdCategory == null)
      {
        return new ResponseResult<CategoryResponse>
        {
          Errors = new[] { "Category already exists" }
        };
      }

      var mappedCategoryResponse = _mapper.Map<CategoryResponse>(createdCategory);

      return new ResponseResult<CategoryResponse>
      {
        Success = true,
        Response = mappedCategoryResponse
      };
    }

    public async Task<ResponseResult<CategoryResponse>> EditCategoryAsync(EditCategoryRequest editCategory)
    {
      var editedCategory = await _shopRepository.EditCategoryAsync(editCategory.CategoryId, editCategory.NewRuTitle, editCategory.NewEnTitle);

      if (editedCategory == null)
      {
        return new ResponseResult<CategoryResponse>
        {
          Errors = new[] { "Category not found" }
        };
      }

      var mappedEditedCategory = _mapper.Map<CategoryResponse>(editedCategory);

      return new ResponseResult<CategoryResponse>
      {
        Success = true,
        Response = mappedEditedCategory
      };
    }

    public async Task<ResponseResult<bool>> RemoveCategoryAsync(DeleteCategoryRequest categoryRequest)
    {
      var removedCategory = await _shopRepository.RemoveCategoryAsync(categoryRequest.CategoryId);

      if (!removedCategory)
      {
        return new ResponseResult<bool>
        {
          Errors = new[] { "Category not found" }
        };
      }

      return new ResponseResult<bool>
      {
        Success = true
      };
    }

    public async Task<ResponseResult<ICollection<CategoryResponse>>> GetCategoriesAsync(GetCategoryRequest categoryRequest)
    {
      var categories = await _shopRepository.GetCategoriesAsync(categoryRequest.GameServerId);

      if (categories == null)
      {
        return new ResponseResult<ICollection<CategoryResponse>>
        {
          Errors = new string[] { "Categories with this server Id not found" }
        };
      }

      var mappedCategories = _mapper.Map<ICollection<CategoryResponse>>(categories);

      return new ResponseResult<ICollection<CategoryResponse>>
      {
        Success = true,
        Response = mappedCategories
      };
    }


    // <---------- Item ---------->


    public async Task<ResponseResult<ItemResponse>> CreateItemAsync(ItemRequest itemRequest, string creatorId)
    {
      var isCategoryExists = await _shopRepository.IsCategoryExistsAsync(itemRequest.CategoryId);

      if(!isCategoryExists)
      {
        return new ResponseResult<ItemResponse>
        {
          Errors = new[] { "Item category is not exists" }
        };
      }

      var dateNow = DateTimeOffset.UtcNow;

      var item = _mapper.Map<Item>(itemRequest);

      item.Id = Guid.NewGuid();
      item.CreatorId = Guid.Parse(creatorId);
      item.CreatedAt = dateNow;
      item.UpdatedAt = dateNow;

      var createdItem = await _shopRepository.CreateItemAsync(item, itemRequest.CategoryId);

      if (createdItem == null)
      {
        return new ResponseResult<ItemResponse>
        {
          Errors = new[] { "Item with this name already exists" }
        };
      }

      var itemCategory = new ItemCategory
      {
        ItemId = item.Id,
        CategoryId = itemRequest.CategoryId
      };

      var createdItemCategory = await _shopRepository.CreateItemCategoryAsync(itemCategory);

      if (createdItemCategory == null)
      {
        return new ResponseResult<ItemResponse>
        {
          Errors = new[] { "Item with this category already exists" }
        };
      }

      var mappedItemResponse = _mapper.Map<ItemResponse>(createdItem);

      return new ResponseResult<ItemResponse>
      {
        Success = true,
        Response = mappedItemResponse
      };
    }

    public async Task<ResponseResult<ItemResponse>> EditItemAsync(EditItemRequest requestItem)
    {

      var item = _mapper.Map<Item>(requestItem);

      item.UpdatedAt = DateTimeOffset.UtcNow;

      var editedItem = await _shopRepository.EditItemAsync(item);

      if (editedItem == null)
      {
        return new ResponseResult<ItemResponse>
        {
          Errors = new[] { "Item not found" }
        };
      }

      var mappedEditedItem = _mapper.Map<ItemResponse>(editedItem);

      return new ResponseResult<ItemResponse>
      {
        Success = true,
        Response = mappedEditedItem
      };
    }

    public async Task<ResponseResult<bool>> RemoveItemAsync(DeleteItemRequest itemRequest)
    {
      var removedItem = await _shopRepository.RemoveItemAsync(itemRequest.Id);

      if (!removedItem)
      {
        return new ResponseResult<bool>
        {
          Errors = new[] { "Item not found" }
        };
      }

      return new ResponseResult<bool>
      {
        Success = true
      };
    }

    public async Task<PagedResponse<ItemResponse>> GetPaginatedItemsAsync(GetItemsRequest getItemsRequest)
    {
      var paginationFilter = _mapper.Map<PaginationFilter>(getItemsRequest.PaginationQuery);

      var items = _shopRepository.GetItems(getItemsRequest.ServerId,
                                           getItemsRequest.CategoryId,
                                           getItemsRequest.ItemsForSearch.ToLower(),
                                           getItemsRequest.SortType,
                                           getItemsRequest.Language);

      var paginatedItems = await RequestPaginationHelper.PaginateAsync(items, paginationFilter);

      var itemsResponse = _mapper.Map<ICollection<ItemResponse>>(paginatedItems);

      return ResponsePaginationHelper.CreatePaginatedResponse(paginationFilter, itemsResponse, items.Count());
    }
  }
}
