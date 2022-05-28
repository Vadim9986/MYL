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

namespace MYL.Controllers
{
    public class QuestionaryController : Controller
    {
        DataBaseContext _context;

        public QuestionaryController(DataBaseContext context)
        {
            _context = context;
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


            if (avatar != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)avatar.Length);
                }
                person.Avatar = imageData;
            }

            List<byte[]> byteFiles = new List<byte[]>();
            if (uploadedPhotos != null)
            {
                foreach (var item in uploadedPhotos)
            {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(item.OpenReadStream()))
                    {
                          byteFiles.Add(binaryReader.ReadBytes((int)item.Length));
                    }
                }
            }
            
            List<Photo> photos = new();
            foreach(var file in byteFiles)
            {
                photos.Add(new Photo(file));
            }
            person.Photos = photos;
 
            if (uploadedPhotos.Count > 6 || uploadedPhotos.FirstOrDefault(x => x.Length > 5145728) is not null)
            {
                ViewBag.IsFileValid = "Вы не можете загрузить больше 6 фотографий/ Размер каждой фотографии не должен привышать 5мб";
                ModelState.AddModelError("Photos", "Не верно");
            }
            if (ModelState.IsValid && uploadedPhotos.Count <= 6)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return Redirect("../MyQuestionary/MyQuestionary");
            }

          
            return View(person);
        }
    }
}