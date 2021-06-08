using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Library.Controllers
{
  [AllowAnonymous]
  public class HomeController : Controller
  {
    public IActionResult Index() => View();
  }

}
