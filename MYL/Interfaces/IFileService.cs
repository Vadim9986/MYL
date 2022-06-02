using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Interfaces
{
        public interface IFileService
        {
            public byte[] FromImageToByte(IFormFile avatar);
         
        }
    
}
