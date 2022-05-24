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
    public class RegistController : Controller
    {
        private readonly DataBaseContext db;
        public RegistController(DataBaseContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Regist()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Regist(UserRegistration user)
        {
            var personLogin = db.Users.ToList().FirstOrDefault(x => x.Username == user.Username); 
            if(personLogin is not null)
            {
                ModelState.AddModelError("Username", "Аккаунт с таким логином, уже зарегистрирован");
            }
            var personEmail = db.Users.ToList().FirstOrDefault(x => x.Email == user.Email);
            if (personEmail is not null)
            {
                ModelState.AddModelError("Email", "Аккаунт с таким Email , уже зарегистрирован");
            }
            if (ModelState.IsValid)
            {
                ControllerContext.HttpContext.Session.SetString("Name", user.Username);// add session with login
                db.Users.Add(user.GetUserModel()); // add user to data base
                db.SaveChanges(); // save information to data base
                return Redirect("../Questionary/Quest");
            }
            else
                return View(user);
            
        }
        
           
        
    }

}

