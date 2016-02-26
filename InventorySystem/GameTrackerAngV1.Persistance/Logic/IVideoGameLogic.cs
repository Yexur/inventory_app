
using System.Linq;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Logic
{
    public interface IVideoGameLogic
    {
        VideoGame Get(int id);
        IQueryable<VideoGame> GetList();
        int Save(VideoGameListItem videoGameListItem);
        void Delete(int id);
        IQueryable<VideoGameListItem> GetPurchasedVideoGamesByCategoryId(int categoryId);
    }
}
