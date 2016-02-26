
using System.Collections.Generic;
using System.Linq;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.IRepository
{
    public interface IBoardGameRepository : Core.IRepository<BoardGame>
    {
        IQueryable<BoardGame> GetBoardGamesByCategoryId(int categoryId);
    }
}
