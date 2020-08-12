using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
  public class Category
  {

    [Key]
    public int Id { get; set; }
    public Guid CreatorId { get; set; }
    public string RuTitle { get; set; }
    public string EnTitle { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    [Required]
    public int ServerId { get; set; }
    public ICollection<ItemCategory> ItemCategories { get; set; }

  }
}
