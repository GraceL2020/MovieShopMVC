using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data
{
    public class UserRepository
    {
        


    }

    public interface IUserRepository:IRepository<User>
    {
        IEnumerable<Movie> GetFavoriteMovies(int userId);
    }
}
