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
        [Required(ErrorMessage = "Пожалуйста, укажите имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите фамилию")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите свой пол")]
        public string Gen { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите действующий мобильный телефон")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Некорректный мобильный телефон")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите свой возраст")]
        [Range(18, 110, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите страну")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите область")]
        public string Region { get; set; }
        [Required(ErrorMessage = "Пожалуйста, укажите город")]
        public string City { get; set; }
        public byte[] Avatar { get; set; }
        [Required(ErrorMessage = "Пожалуйста, напишите о себе")]
        public string AboutYourself { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public User User { get; set; }
    }
}
