using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYL.DataBase;
using MYL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Controllers
{
    public class MyQuestionaryController : Controller
    {
        DataBaseContext _context;
        IFavoriteService _favoriteService;
        IUserService _userService;

        public MyQuestionaryController(DataBaseContext context, IFavoriteService favoriteService, IUserService userService)
        {
            _context = context;
            _favoriteService = favoriteService;
            _userService = userService;
        }
        public IActionResult MyQuestionary()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Account = userName;
                var user = _context.People.Include(x => x.User).Include(x => x.Photos).FirstOrDefault(x => x.User.Username == userName);
                return View(user);
        }

        public IActionResult UserQuestionary(int Id)
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Account = userName;
                var user = _context.People.Include(x => x.User).Include(x=>x.Photos).FirstOrDefault(x => x.Id == Id);
                return View("../MyQuestionary/MyQuestionary", user);
        }

        public bool AddToFavourite(int id)
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            if (userName is not null)
            {
                _favoriteService.Add(_userService.Get(userName), id);
                return true;
            }

            return false;
        }
    }
}
