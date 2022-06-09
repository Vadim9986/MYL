using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using MYL.DataBase;
using MYL.Interfaces;
using MYL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Controllers
{
    public class ChangePasswordController : Controller
    {
        DataBaseContext _context;
        private readonly IUserService _UserService;
        public ChangePasswordController(IUserService UserService, DataBaseContext context)
        {
            _UserService = UserService;
            _context = context;
        }
        public IActionResult ChangePassword()
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            ViewBag.Account = userName;
            return View();
        }
        public IActionResult ChangeUserPassword(User newUser)
        {
            var user = _context.Users.ToList().FirstOrDefault(x => x.Email == newUser.Email);
            user.Password = newUser.Password is null ? user.Password : newUser.Password;
            user.PasswordConfirm = newUser.PasswordConfirm is null ? user.PasswordConfirm : newUser.PasswordConfirm;
            _context.SaveChanges();
            return Redirect("../Home/Index");
        }
    }
}
