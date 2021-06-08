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
  public class TreatsController : Controller
  {
    private readonly SweetSavoryContext _db;
    private readonly UserManager<User> _userManager;
    public async Task<User> GetUser() =>
      await _userManager
        .FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    public Treat GetTreat(string id) => _db.Treats.FirstOrDefault(t => t.TreatId == id);
    public List<Treat> AllTreats() => _db.Treats.ToList();
    public TreatsController(UserManager<User> userManager, SweetSavoryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [AllowAnonymous]
    [HttpGet]
    public ActionResult Index() => View(AllTreats());

    [HttpGet]
    public ActionResult Create() => View();
    [HttpPost]
    public ActionResult Create(Treat t)
    {
      _db.Treats.Add(t);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    [HttpGet]
    public ActionResult Details(string id)
    {
      var t = GetTreat(id);
      return t switch
      {
        null => RedirectToAction("Index"),
        _ => View(t)
      };
    }

    [HttpGet]
    public ActionResult Edit(string id, string controller)
    {
      ViewBag.flavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      ViewBag.controller = controller;
      return View(GetTreat(id));
    }
    [HttpPost]
    public ActionResult Edit(Treat t)
    {
      _db.Entry(t).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(string id) => View(GetTreat(id));

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(string id)
    {
      _db.Treats.Remove(GetTreat(id));
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
