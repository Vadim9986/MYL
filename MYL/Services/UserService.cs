using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MYL.DataBase;
using MYL.Interfaces;
using MYL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Services
{
    public class UserService : IUserService
    {
        private readonly DataBaseContext _db;
        private readonly IFileService _fileService;
        public UserService(DataBaseContext db, IFileService fileService)
        {
            _db = db;
            _fileService = fileService;
        }

        public void ChangePassword(User user, string password)
        {
            var newUser = _db.Users.ToList().FirstOrDefault(x => x.Email == user.Email);
            newUser.Password = password;
            newUser.PasswordConfirm = password;
            _db.SaveChanges();
        }

        public User Get(string username)
        {
            throw new NotImplementedException();
        }

        public void EditUser(Questionary newUser, string userName, IFormFile uploadedFile, IFormFileCollection uploadedPhotos)
        {
            var user = _db.People.Include(x => x.User).Include(x => x.Photos).ToList().FirstOrDefault(x => x.User.Username == userName);
            user.Avatar = uploadedFile is null ? user.Avatar : _fileService.FromImageToByte(uploadedFile); 
            user.Name = newUser.Name;
            user.Surname = newUser.Surname;
            user.Gen = newUser.Gen;
            user.Phone = newUser.Phone;
            user.Age = newUser.Age;
            user.Country = newUser.Country;
            user.Region = newUser.Region;
            user.City = newUser.City;
            user.Instagram = newUser.Instagram;
            user.Telegram = newUser.Telegram;
            user.EmailContact = newUser.EmailContact;
            user.Facebook = newUser.Facebook;
            user.Photos = uploadedPhotos is null ? user.Photos : EditUserPhoto(newUser, uploadedPhotos);
            _db.SaveChanges();
        }

        public List<Photo> EditUserPhoto(Questionary newUser, IFormFileCollection uploadedPhotos)
        {
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

            var questionaries = _db.People.Where(x => x.Id == newUser.Id);
            _db.People.RemoveRange(questionaries);
            _db.SaveChanges();

            List<Photo> photos = new();
            foreach (var file in byteFiles)
            {
                photos.Add(new Photo(file));
            }
            return photos;
        }
    }
}
