using System;
using System.Collections.Generic;

namespace SweetSavory.Models
{
  public class Treat
  {
    public Treat()
    {
      TreatId = Guid.NewGuid().ToString();
      Flavorings = new HashSet<Flavoring>();
    }
    public string TreatId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Flavoring> Flavorings { get; }
  }
}
