using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MYL.Models;

namespace MYL.ViewModels
{
    public class UserRegistration
    {

        [Required(ErrorMessage = "Пожалуйста, укажите адрес электронной почты")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите имя пользователя ")]
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "Некорректный логин")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите пароль")]
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "Некорректный пароль")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
        public User GetUserModel()
        {
            return new User()
            {
                Email = this.Email,
                Username = this.Username,
                Password = this.Password,
            };
        }
    }
}
