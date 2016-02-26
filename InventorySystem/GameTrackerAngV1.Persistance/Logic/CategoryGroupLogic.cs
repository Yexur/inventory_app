using System.Linq;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Logic
{
    public class CategoryGroupLogic : ICategoryGroupLogic
    {
        private readonly ICategoryGroupRepository _categoryGroupRepository;

        public CategoryGroupLogic(ICategoryGroupRepository categoryGroupRepository)
        {
            _categoryGroupRepository = categoryGroupRepository;
        }

        public CategoryGroup Get(int id)
        {
            return _categoryGroupRepository.FindById(id);
        }

        public IQueryable<CategoryGroupListItem> GetList()
        {
            var categoryGroups = _categoryGroupRepository.All();

            if (categoryGroups == null || !categoryGroups.Any())
            {
                return Enumerable.Empty<CategoryGroupListItem>().AsQueryable();
            }

            var categoryGroupList = categoryGroups.Select(x => new CategoryGroupListItem()
            {
                CategoryGroup = x.CategoryGroupType,
                CategoryGroupId = x.Id
            });

            return categoryGroupList;

        }

        public void Save(CategoryGroup categoryGroup)
        {
            _categoryGroupRepository.Insert(categoryGroup);
        }

        public void Delete(int id)
        {
            _categoryGroupRepository.Delete(id);
        }
    }
}
