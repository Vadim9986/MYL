using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MYL.Controllers
{
    public class FavoritesController : Controller
    {
        public IActionResult Favorites()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Account = userName;
            return View();
        }
    }
}
