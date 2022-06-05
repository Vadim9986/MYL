using Microsoft.AspNetCore.Mvc;
using MYL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using MYL.Models;
using MYL.ViewModels;
using MYL.Interfaces;

namespace MYL.Controllers
{
    public class QuestionaryController : Controller
    {
        DataBaseContext _context;
        IUserService _userService;
        IFileService _fileService;

        public QuestionaryController(DataBaseContext context, IUserService userService, IFileService fileService)
        {
            _context = context;
            _userService = userService;
            _fileService = fileService;
        }
        public IActionResult Quest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quest(Questionary person,IFormFile avatar, IFormFileCollection uploadedPhotos)
        {
            var userName = ControllerContext.HttpContext.Session.GetString("Name");
            person.User = _context.Users.FirstOrDefault(x => x.Username == userName);
            ViewBag.Account = userName;
            if (uploadedPhotos.Count > 6 || uploadedPhotos.FirstOrDefault(x => x.Length > 5145728) is not null)
            {
                ViewBag.IsFileValid = "You cannot upload more than 6 photos / The size of each photo should not exceed 5mb";
                ModelState.AddModelError("Photos", "Не верно");
            }
            if (ModelState.IsValid && uploadedPhotos.Count <= 6)
            {
                person.Photos = _userService.EditUserPhoto(person, uploadedPhotos);
                person.Avatar = _fileService.FromImageToByte(avatar);
                _context.People.Add(person);
                _context.SaveChanges();
                return Redirect("../MyQuestionary/MyQuestionary");
            }

            return View(person);
        }
    }
}