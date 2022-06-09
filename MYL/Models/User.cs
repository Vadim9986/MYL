using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone {get; set;}
        public string PasswordConfirm { get; set; }
        public bool IsAdmin { get; set; }
        public List<Favorite> Favorites { get; set; } = new List<Favorite>();


    }
}
