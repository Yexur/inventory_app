
using System.Linq;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;


namespace GameTrackerAngV1.Persistance.Logic
{
    public class TrackingCodeLogic : ITrackingCodeLogic
    {
        private readonly ITrackingCodeRepository _trackingCodeRepository;

        public TrackingCodeLogic(ITrackingCodeRepository trackingCodeRepository)
        {
            _trackingCodeRepository = trackingCodeRepository;
        }

        public TrackingCode Get(int id)
        {
            return _trackingCodeRepository.FindById(id);
        }

        public IQueryable<TrackingCode> GetList()
        {
            return _trackingCodeRepository.All();
        }

        public void Save(TrackingCode trackingCode)
        {
            _trackingCodeRepository.Insert(trackingCode);
        }

        public void Delete(int id)
        {
            _trackingCodeRepository.Delete(id);
        }
    }
}
