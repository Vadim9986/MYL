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

        [Required(ErrorMessage = "Please, enter your email")]
        [EmailAddress(ErrorMessage = "Incorrect email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please, enter your username ")]
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "Incorrect username")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Please, enter your password")]
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "Incorrect password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please, confirm your password")]
        [Compare("Password", ErrorMessage = "Incorrect confirm password")]
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
