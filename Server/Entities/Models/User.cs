using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
  public class User : IdentityUser
  {

    [StringLength(36)]
    public string Uuid { get; set; }
    public uint? Coins { get; set; }
    public uint? Econs { get; set; }
    public string FirstName { get; set; }
    public DateTimeOffset? DateOfBirth { get; set; }
    public DateTimeOffset RegistrationDate { get; set; }
    public DateTimeOffset LastActivity { get; set; }
    public string Avatar { get; set; }
    public string Skin { get; set; }
    public string Cape { get; set; }

  }
}
