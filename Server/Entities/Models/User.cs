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
    public DonateRole DonateRole { get; set; }
    public string FirstName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime LastActivity { get; set; }
    public string Avatar { get; set; }
    public string Skin { get; set; }
    public string Cape { get; set; }

  }
}
