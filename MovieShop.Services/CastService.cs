using MovieShop.Data;
using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public bool AddCast(Cast cast)
        {
            _castRepository.Add(cast);
            return _castRepository.Save();
        }

        public Cast GetCastDetails(int castId)
        {
            return _castRepository.GetCastWithMovies(castId);
        }
    }

    public interface ICastService
    {
        Cast GetCastDetails(int castId);
        bool AddCast(Cast cast);
    }
}
