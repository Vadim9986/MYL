using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYL.Interfaces;

namespace MYL.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IFavoriteService _favoriteService;
        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
        public IActionResult Favorites()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Account = userName;
            return View(_favoriteService.Get(userName));
        }
    }
}
