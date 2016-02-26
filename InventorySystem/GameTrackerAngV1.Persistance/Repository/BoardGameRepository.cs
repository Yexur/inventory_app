
using System.Linq;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Repository
{
    public class BoardGameRepository : Core.Repository<BoardGame>, IBoardGameRepository
    {
        public BoardGameRepository(GameTrackerContext context)
            : base(context)
        {
        }

        public IQueryable<BoardGame> GetBoardGamesByCategoryId(int categoryId)
        {
            return GameTrackerContext.BoardGames.Where(v => v.Category_Id == categoryId);
        }
    }
}
