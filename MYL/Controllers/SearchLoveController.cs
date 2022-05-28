using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYL.DataBase;
using MYL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Controllers
{
    public class SearchLoveController : Controller
    {
        private readonly DataBaseContext _db;
        public SearchLoveController(DataBaseContext db)
        {
            _db = db;
        }
        public IActionResult SearchLove()
        {
            var user = HttpContext.Session.GetString("Name");
            ViewBag.Account = user;
            return View();
        }

        public ViewResult GetQuestionary(SearchViewModel search)
        {
            var model = _db.People.Include(x => x.User).Where(x => x.Age >= search.AgeStart && x.Age <= search.AgeEnd).ToList();
            return View(model);
        }
    }
}
