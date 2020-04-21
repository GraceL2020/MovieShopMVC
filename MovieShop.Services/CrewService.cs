using MovieShop.Data;
using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Services
{
    public class CrewService : ICrewService
    {
        private readonly ICrewRepository _CrewRepository;

        public CrewService(ICrewRepository crewRepository)
        {
            _CrewRepository = crewRepository;
        }
        public Crew GetCrewDetails(int crewId)
        {
            return _CrewRepository.GetCrewWithMovies(crewId);
        }
    }

    public interface ICrewService
    {
        Crew GetCrewDetails(int CrewId);
    }
}
