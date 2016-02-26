using System.Linq;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.IRepository
{
    public interface ICategoryRepository : Core.IRepository<Category>
    {
        IQueryable<Category> GetCategoryListItemsByGroupType(int categoryGroupId);
        bool CheckForItems(int categoryId);
    }
}