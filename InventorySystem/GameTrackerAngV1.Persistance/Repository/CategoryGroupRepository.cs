
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Repository
{
   public class CategoryGroupRepository : Core.Repository<CategoryGroup> , ICategoryGroupRepository
   {
       public CategoryGroupRepository(GameTrackerContext context) : base(context)
       {
       }
   }
}
