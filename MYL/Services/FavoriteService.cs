using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MYL.DataBase;
using MYL.Interfaces;
using MYL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace MYL.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly DataBaseContext _db;
        private readonly IUserService UserService;
        public bool Add(string userName, int productId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int favoriteId)
        {
            var favorite = Get(favoriteId);
            _db.Favorites.Remove(favorite);
            _db.SaveChanges();
        }

       

        public Favorite Get(int favoriteId)
        {
            return _db.Favorites.Include(x => x.User).ToList().FirstOrDefault(x => x.Id == favoriteId);
        }

       
    }
}
