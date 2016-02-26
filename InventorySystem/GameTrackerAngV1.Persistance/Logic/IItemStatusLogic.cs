using System.Linq;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Logic
{
    public interface IItemStatusLogic
    {
        ItemStatus Get(int id);
        IQueryable<ItemStatus> GetList();
        void Save(ItemStatus itemStatus);
        void Delete(int id);
    }
}
