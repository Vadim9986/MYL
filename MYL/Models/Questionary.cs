using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Models
{
    public class Questionary
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name length must be between 3 and 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please, enter your surname")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Surname length must be between 3 and 50 characters")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please, enter your gender")]
        public string Gen { get; set; }
        [Required(ErrorMessage = "Please, enter your valide mobile phone")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Incorrect mobile phone")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Please, enter your age")]
        [Range(18, 110, ErrorMessage = "You must be over 18 years of age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please, enter your country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please, enter your region")]
        public string Region { get; set; }
        [Required(ErrorMessage = "Please, enter your city")]
        public string City { get; set; }
        public string Instagram { get; set; }
        public string Telegram { get; set; }
        public string Facebook { get; set; }
        public string EmailContact { get; set; }

        public byte[] Avatar { get; set; }
        [Required(ErrorMessage = "Please, write something about yourself")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "About yourself length must be between 3 and 300 characters")]
        public string AboutYourself { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public User User { get; set; }
    }
}
