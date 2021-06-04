using System;
using System.Collections.Generic;

namespace SweetSavory.Models
{
  public class Flavor
  {
    public Flavor()
    {
      FlavorId = Guid.NewGuid().ToString();
      Flavorings = new HashSet<Flavoring>();
    }
    public string FlavorId { get; set; }
    public virtual ICollection<Flavoring> Flavorings { get; }
  }
}
