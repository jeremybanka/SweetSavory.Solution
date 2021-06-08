using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using SweetSavory.Models;

namespace SweetSavory.Controllers
{
  public class FlavoringsController : Controller
  {
    private readonly SweetSavoryContext _db;

    public FlavoringsController(SweetSavoryContext db)
    {
      _db = db;
    }
    public Flavoring FindFlavoring(string id)
      => _db.Flavorings.FirstOrDefault(e => e.FlavoringId == id);

    public Flavoring CheckFlavoring(string TreatId, string FlavorId)
      => _db.Flavorings
        .FirstOrDefault(e => e.FlavorId == FlavorId && e.TreatId == TreatId);

    public void CreateNewFlavoring(string TreatId, string FlavorId)
    {
      _db.Flavorings.Add(new Flavoring() { TreatId = TreatId, FlavorId = FlavorId });
      _db.SaveChanges();
    }

    [HttpPost]
    public ActionResult Delete(string id, string origin)
    {
      var e = FindFlavoring(id);
      _db.Flavorings.Remove(e);
      _db.SaveChanges();
      string entityId = "";
      if (origin == "Treats") entityId = e.TreatId;
      if (origin == "Flavors") entityId = e.FlavorId;

      return RedirectToAction("Edit", origin, new { id = entityId });
    }

    [HttpPost]
    public ActionResult Create(string FlavorId, string TreatId, string origin)
    {
      Console.WriteLine("FlavorId {0}, TreatId {1}", FlavorId, TreatId);
      bool FlavorIsNotPresent = CheckFlavoring(TreatId, FlavorId) == null;
      if (TreatId != "" && FlavorIsNotPresent)
      {
        CreateNewFlavoring(TreatId, FlavorId);
      }
      string entityId = "";
      if (origin == "Treats") entityId = TreatId;
      if (origin == "Flavors") entityId = FlavorId;

      return RedirectToAction("Edit", origin, new { id = entityId });
    }
  }
}