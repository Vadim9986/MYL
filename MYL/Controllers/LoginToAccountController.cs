using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MYL.Models;
using MYL.DataBase;
using MYL.ViewModels;

namespace MYL.Controllers
{
    public class LoginToAccountController : Controller
    {
        private readonly DataBaseContext db;
        public LoginToAccountController(DataBaseContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult LoginToAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginToAccount(UserLogin user)
        {
            var userFromDb = db.Users.ToList().FirstOrDefault(x => x.Username== user.Username);
            if (userFromDb is not null && userFromDb.Password == user.Password)
            {
                ControllerContext.HttpContext.Session.SetString("Name", user.Username);
                if(userFromDb.IsAdmin)
                {
                    return Redirect("../AdminPanel/AdminPanel");
                }

                return Redirect("../MyQuestionary/MyQuestionary");
            }
            return View();
        }
    }
}