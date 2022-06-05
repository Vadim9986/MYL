using Microsoft.AspNetCore.Http;
using MYL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYL.Interfaces
{
    public interface IFavoriteService
    {
        public bool Add(string userName, int productId);
        public void Delete(int favoriteId);
        public Favorite Get(int favoriteId);
    }
}
