using System.Linq;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Repository
{
    public class CategoryRepository : Core.Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(GameTrackerContext context)
            : base(context)
        {
        }
        public IQueryable<Category> GetCategoryListItemsByGroupType(int categoryGroupId)
        {
            return GameTrackerContext.Categories.Where(x => x.CategoryGroup_Id == categoryGroupId);
        }

        public bool CheckForItems(int categoryId)
        {
            return CheckForVideoGames(categoryId) || CheckForBoardGames(categoryId);
        }

        private bool CheckForBoardGames(int categoryId)
        {
            return GameTrackerContext.BoardGames.Any(x => x.Category_Id == categoryId);
        }

        private bool CheckForVideoGames(int categoryId)
        {
            return GameTrackerContext.VideoGames.Any(x => x.Category_Id == categoryId);
        }
    }
}
