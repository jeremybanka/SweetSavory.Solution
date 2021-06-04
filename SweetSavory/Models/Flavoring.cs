namespace SweetSavory.Models
{
  public class Flavoring
  {
    public string FlavoringId { get; set; }
    public string FlavorId { get; set; }
    public string TreatId { get; set; }
    public virtual Flavor Flavor { get; set; }
    public virtual Treat Treat { get; set; }
  }
}
