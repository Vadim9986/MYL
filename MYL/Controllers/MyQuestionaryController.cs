﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Controllers
{
    public class MyQuestionaryController : Controller
    {
        DataBaseContext _context;

        public MyQuestionaryController(DataBaseContext context)
        {
            _context = context;
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

    }
}
