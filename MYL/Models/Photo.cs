using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public Photo(byte[] image)
        {
            Image = image;
        }
    }
}
