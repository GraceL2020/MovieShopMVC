using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data
{
    public class CrewRepository : Repository<Crew>, ICrewRepository
    {
        public CrewRepository(MovieShopDbContext context) : base(context)
        {

        }

        public Crew GetCrewWithMovies(int crewId)
        {
            var Crew = _context.Crews.Where(c => c.Id == crewId).Include(c => c.MovieCrews.Select(m => m.Movie))
                .FirstOrDefault();
            return Crew;
        }
    }

    public interface ICrewRepository : IRepository<Crew>
    {
        Crew GetCrewWithMovies(int CrewId);
    }
}
