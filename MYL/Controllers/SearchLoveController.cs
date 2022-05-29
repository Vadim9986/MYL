using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYL.DataBase;
using MYL.Models;
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
            ViewBag.CountUser = _db.Users.Count();
            return View();
        }
        [HttpPost]
        public ViewResult GetQuestionary(SearchViewModel search)
        {
           List<Questionary> model = _db.People.Include(x => x.User).Where(x => x.Age >= search.AgeStart && x.Age<=search.AgeEnd).ToList();  
            if(search.Gender is not null)
            {
                model = model.Where(x => x.Gen.Contains(search.Gender)).ToList();
            }

            if(search.Country is not null)
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
        
    }
}
