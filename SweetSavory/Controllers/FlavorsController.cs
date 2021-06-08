using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SweetSavory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
  [Authorize]
  public class FlavorsController : Controller
  {
    private readonly SweetSavoryContext _db;
    private readonly UserManager<User> _userManager;
    public async Task<User> Who() =>
      await _userManager
        .FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    public Flavor GetFlavor(string id) => _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
    public List<Flavor> AllFlavors() => _db.Flavors.ToList();
    public FlavorsController(UserManager<User> userManager, SweetSavoryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [AllowAnonymous]
    [HttpGet]
    public ActionResult Index() => View(AllFlavors());

    [HttpGet]
    public ActionResult Create() => View();
    [HttpPost]
    public ActionResult Create(Flavor f)
    {
      _db.Flavors.Add(f);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    [HttpGet]
    public ActionResult Details(string id)
    {
      var t = GetFlavor(id);
      return t switch
      {
        null => RedirectToAction("Index"),
        _ => View(t)
      };
    }

    [HttpGet]
    public ActionResult Edit(string id, string controller)
    {
      ViewBag.treatId = new SelectList(_db.Treats, "TreatId", "Name");
      ViewBag.controller = controller;
      return View(GetFlavor(id));
    }
    [HttpPost]
    public ActionResult Edit(Flavor f)
    {
      _db.Entry(f).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(string id) => View(GetFlavor(id));

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(string id)
    {
      _db.Flavors.Remove(GetFlavor(id));
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
