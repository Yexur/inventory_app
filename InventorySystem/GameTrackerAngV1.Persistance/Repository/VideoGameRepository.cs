
using System.Linq;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Repository
{
    public class VideoGameRepository : Core.Repository<VideoGame> , IVideoGameRepository
    {
        public VideoGameRepository(GameTrackerContext context) : base(context)
        {
        }

        public IQueryable<VideoGame> GetVideoGamesByCategoryId(int categoryId)
        {
            return GameTrackerContext.VideoGames.Where(v => v.Category_Id == categoryId);
        }
    }
}
