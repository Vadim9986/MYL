using Microsoft.AspNetCore.Http;
using MYL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Services
{
    public class FileServices : IFileService
    {
        public byte[] FromImageToByte(IFormFile uploadedFile)
        {
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(uploadedFile.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)uploadedFile.Length);
            }

            return imageData;
        }

       
    }
}
