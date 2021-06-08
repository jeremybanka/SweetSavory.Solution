using System;

namespace SweetSavory.Models
{
  public class Flavoring
  {
    public Flavoring()
    {
      FlavoringId = Guid.NewGuid().ToString();
    }
    public string FlavoringId { get; set; }
    public string FlavorId { get; set; }
    public string TreatId { get; set; }
    public virtual Flavor Flavor { get; set; }
    public virtual Treat Treat { get; set; }
  }
}
