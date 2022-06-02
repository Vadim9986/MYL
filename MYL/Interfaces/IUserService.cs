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
        public void EditUser(Questionary newUser, string userEmail, IFormFile uploadedFile);
        public void EditUserPhoto(Questionary user, IFormFileCollection uploadedPhotos);
        public User Get(string username);
    }

}
