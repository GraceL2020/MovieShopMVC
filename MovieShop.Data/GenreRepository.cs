using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContext context) : base(context)
        {
            
        }
        

    }

    public interface IGenreRepository : IRepository<Genre>
    {

    }

}
