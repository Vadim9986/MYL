using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Controllers
{
    public class EditController : Controller
    {
        DataBaseContext _context;

        public EditController(DataBaseContext context)
        {
            _context = context;
        }
        public IActionResult Edit()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            var user = _context.People.Include(x => x.User).Include(x => x.Photos).FirstOrDefault(x => x.User.Username == userName);


            return View(user);
        }
    }
}
