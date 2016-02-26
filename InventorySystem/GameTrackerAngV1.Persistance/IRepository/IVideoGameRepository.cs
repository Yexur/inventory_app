
using System.Linq;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.IRepository
{
    public interface IVideoGameRepository : Core.IRepository<VideoGame>
    {
        IQueryable<VideoGame> GetVideoGamesByCategoryId(int categoryId);
    }
}
