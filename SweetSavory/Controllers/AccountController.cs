using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

using SweetSavory.Models;
using SweetSavory.ViewModels;

namespace SweetSavory.Controllers
{
  [AllowAnonymous]
  public class AccountController : Controller
  {
    private readonly SweetSavoryContext _db;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public AccountController(
      UserManager<User> userManager,
      SignInManager<User> signInManager,
      SweetSavoryContext db
    )
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public async Task<User> Who() =>
      await _userManager.FindByIdAsync(
        User.FindFirst(ClaimTypes.NameIdentifier)?.Value
      );

    [HttpGet] public async Task<ActionResult> Index() => View(await Who());

    [HttpGet] public ActionResult Register() => View();
    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel rvm)
    {
      Console.WriteLine("attempt to register");
      User u = new() { UserName = rvm.Email };
      IdentityResult ir = await _userManager.CreateAsync(u, rvm.Password);
      if (ir.Succeeded) return RedirectToAction("Index");
      return View();
    }

    [HttpGet] public ActionResult Login() => View();
    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel lvm)
    {
      Microsoft.AspNetCore.Identity.SignInResult sir
      =
      await _signInManager.PasswordSignInAsync(
          lvm.Email,
          lvm.Password,
          isPersistent: true,
          lockoutOnFailure: false
      );
      if (sir.Succeeded) return RedirectToAction("Index");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Logout()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
  }
}
