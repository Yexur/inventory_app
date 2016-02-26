
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Repository
{
    public class TrackingCodeRepository : Core.Repository<TrackingCode> , ITrackingCodeRepository
    {
        public TrackingCodeRepository(GameTrackerContext context) : base(context)
        {
        }
    }
}
