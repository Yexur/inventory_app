
using System.Linq;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Logic
{
    public interface IGenreLogic
    {
        Genre Get(int id);
        IQueryable<Genre> GetList();
        void Save(Genre genre);
        void Delete(int id);
    }
}
