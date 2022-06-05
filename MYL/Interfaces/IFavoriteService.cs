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
        public void Add(User user, int questionaryId);
        public void Delete(Favorite favorite);
        public Favorite Get(int favoriteId);
        public List<Favorite> Get(string userName);
    }
}
