
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Repository
{
    public class ItemStatusRepository : Core.Repository<ItemStatus> , IItemStatusRepository
    {
        public ItemStatusRepository(GameTrackerContext context) : base(context)
        {
        }
    }
}
