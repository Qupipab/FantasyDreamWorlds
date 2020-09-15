using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Shop.Request
{
  public class DeleteItemRequest
  {

    [Required]
    public Guid Id { get; set; }

  }
}
