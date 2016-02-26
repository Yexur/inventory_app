
using System.Linq;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Logic
{
    public interface IBoardGameLogic
    {
        BoardGame Get(int id);
        IQueryable<BoardGame> GetList();
        void Save(BoardGame boardGame);
        void Delete(int id);
        IQueryable<BoardGameListItem> GetPurchasedBoardGamesByCategoryId(int categoryId);
    }
}
