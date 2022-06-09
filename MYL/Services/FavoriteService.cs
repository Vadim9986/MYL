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
        private readonly IUserService _userService;
        public FavoriteService(DataBaseContext db, IUserService userService)
        {
            _db = db;
            _userService = userService;
        }
        public void Add(User user, int questionaryId)
        {
            var userWithFav = Get(user.Username).FirstOrDefault(x => x.Questionary.Id == questionaryId);
            if (userWithFav is null)
            {
                Favorite favorite = new Favorite();
                favorite.User = user;
                favorite.Questionary = _db.People.FirstOrDefault(x => x.Id == questionaryId);
                _db.Favorites.Add(favorite);
                _db.SaveChanges();
            }
            else
            {
                var favorite = _db.Favorites.Include(x => x.User).Include(x => x.Questionary).ToList().FirstOrDefault(x => x.User.Username == user.Username && x.Questionary.Id == questionaryId);
                Delete(favorite);
            }
        }

        public void Delete(Favorite favorite)
        {
            _db.Favorites.Remove(favorite);
            _db.SaveChanges();
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

       public List<Favorite> Get(string userName)
       {
            return _db.Favorites.Include(x => x.User).Include(x => x.Questionary).Where(x => x.User.Username == userName).ToList();
       }
    }
}
