
using System.Linq;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Logic
{
   public interface ITrackingCodeLogic
    {
        TrackingCode Get(int id);
        IQueryable<TrackingCode> GetList();
        void Save(TrackingCode trackingCode);
        void Delete(int id);
    }
}
