using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO.Request
{
  public class CheckUserNameRequest
  {

    [Required]
    [StringLength(30, MinimumLength = 4)]
    public string UserName { get; set; }

  }
}
