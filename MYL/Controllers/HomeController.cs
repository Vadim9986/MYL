using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("Name");
            ViewBag.Account = user;
            if(user is null)
            {
                return View();
            }
            return Redirect("../Questionary/Quest");
            
        }
        public IActionResult ExitAccount()
        {
            ControllerContext.HttpContext.Session.Remove("Name");
            return Redirect("../Home/Index");
        }
    }
}
