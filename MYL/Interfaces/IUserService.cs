using Microsoft.AspNetCore.Http;
using MYL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Interfaces
{
   public interface IUserService
    {
        public void ChangePassword(User user, string password);
        public void EditUser(Questionary newUser, string userName, IFormFile uploadedFile, IFormFileCollection uploadedPhotos);
        public List<Photo> EditUserPhoto(Questionary newUser, IFormFileCollection uploadedPhotos);
        public User Get(string username);
        public void DeleteUser(string username);
    }

}
