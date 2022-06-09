using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYL.DataBase;
using MYL.Interfaces;
using System.Linq;
using MYL.Services;
using MYL.Models;
using MYL.ViewModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MYL.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly DataBaseContext _db;
        private readonly IFileService _fileService;
        private readonly IUserService _UserService;
        public AdminPanelController(DataBaseContext db, IFileService fileService, IUserService userService)
        {
            _db = db;
            _fileService = fileService;
            _UserService = userService;
        }

        public IActionResult AdminPanel()
        {
            var userName = HttpContext.Session.GetString("Name");
            if (userName is null || !_UserService.Get(userName).IsAdmin)
            {
                return Redirect("../Home/Index");
            }
            ViewBag.User = _UserService.Get(userName);
            ViewBag.CountUser = _db.Users.Count();
            return View();
        }
        [HttpPost]
        public ViewResult GetQuestionary(SearchViewModel search)
        {
            List<Questionary> model = _db.People.Include(x => x.User).Where(x => x.Age >= search.AgeStart && x.Age <= search.AgeEnd).Where(x => !x.User.IsAdmin).ToList();
            if (search.Gender is not null)
            {
                model = model.Where(x => x.Gen.Contains(search.Gender)).ToList();
            }

            if (search.Country is not null)
            {
                model = model.Where(x => x.Country.Contains(search.Country)).ToList();
            }


            switch (search.Sort)
            {
                case "NewDesc":
                    model = model.OrderByDescending(x => x.Id).ToList();
                    break;
                case "NewAsc":
                    model = model.OrderBy(x => x.Id).ToList();
                    break;
            }
            return View(model);
        }
        public IActionResult DeleteFromWebSite(string username)
        {
            _UserService.DeleteUser(username);
            return RedirectToAction("AdminPanel");
        }
    }
}
