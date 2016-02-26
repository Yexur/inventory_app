
using System.Linq;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Logic
{
    public class GenreLogic : IGenreLogic
    {
        private readonly IGenreRepository _genreRepository;

        public GenreLogic(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public Genre Get(int id)
        {
            return _genreRepository.FindById(id);
        }

        public IQueryable<Genre> GetList()
        {
            return _genreRepository.All();
        }

        public void Save(Genre genre)
        {
            _genreRepository.Insert(genre);
        }

        public void Delete(int id)
        {
            _genreRepository.Delete(id);
        }
    }
}
