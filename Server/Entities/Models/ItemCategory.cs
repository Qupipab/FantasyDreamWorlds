using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
  public class ItemCategory
  {
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public Guid ItemId { get; set; }
    public Item Item { get; set; }

  }
}
