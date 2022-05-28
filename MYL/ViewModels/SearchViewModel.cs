using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.ViewModels
{
    public class SearchViewModel
    {
        public string Gender { get; set; }
        public int AgeStart { get; set; }
        public int AgeEnd { get; set; }
        public string Country { get; set; }
        public string Sort { get; set; }
    }
}
