using System.Linq;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Logic
{
    public interface ICategoryGroupLogic
    {
        CategoryGroup Get(int id);
        IQueryable<CategoryGroupListItem> GetList();
        void Save(CategoryGroup categoryGroup);
        void Delete(int id);
    }
}
