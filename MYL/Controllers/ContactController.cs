using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MYL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MYL.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly Service service;
        public ContactController(ILogger<ContactController> logger, Service service)
        {
            _logger = logger;
            this.service = service;
        }

        
        public ViewResult Contact()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Account = userName;
            return View();
        }
        public IActionResult SendEmail( string email)
        {
            service.SendEmail(email);
            return RedirectToAction("Index");
        }
        

    }
}
