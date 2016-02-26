using System.Linq;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Logic
{
    public interface ICategoryLogic
    {
        Category Get(int id);
        IQueryable<CategoryListItem> GetList();
        int Save(CategoryListItem category);
        bool Delete(int id);
        IQueryable<CategoryListItem> GetCategoryListItemsByGroupType(int categoryGroupId);
     }
}
