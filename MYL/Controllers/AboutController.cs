using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult AboutUs()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Account = userName;
            return View();
        }
    }
}
