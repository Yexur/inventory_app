
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Repository
{
    public class GenreRepository : Core.Repository<Genre> , IGenreRepository
    {
        public GenreRepository(GameTrackerContext context) : base(context)
        {
        }
    }
}
