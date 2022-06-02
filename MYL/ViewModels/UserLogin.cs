using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.ViewModels
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Please, enter your username")]
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "Некорректный логин")]
        public string Username{ get; set; }
        [Required(ErrorMessage = "Please, enter your password")]
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "Некорректный пароль")]
        public string Password { get; set; }
    }
}
