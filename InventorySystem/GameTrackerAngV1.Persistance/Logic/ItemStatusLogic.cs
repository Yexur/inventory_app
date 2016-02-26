using System.Linq;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Logic
{
    public class ItemStatusLogic : IItemStatusLogic
    {
        private readonly IItemStatusRepository _itemStatusRepository;

        public ItemStatusLogic(IItemStatusRepository itemStatusRepository)
        {
            _itemStatusRepository = itemStatusRepository;
        }
        public ItemStatus Get(int id)
        {
            return _itemStatusRepository.FindById(id);
        }

        public IQueryable<ItemStatus> GetList()
        {
            return _itemStatusRepository.All();
        }

        public void Save(ItemStatus itemStatus)
        {
            _itemStatusRepository.Insert(itemStatus);
        }

        public void Delete(int id)
        {
            _itemStatusRepository.Delete(id);
        }
    }
}
