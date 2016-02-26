using System.Linq;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Logic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryRepository _categoryRepository;
      
        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category Get(int id)
        {
            return _categoryRepository.FindById(id);
        }

        public IQueryable<CategoryListItem> GetList()
        {
            return MapCategoryToCategoryListItems(_categoryRepository.All());
        }

        public int Save(CategoryListItem categoryListItem)
        {
            if (categoryListItem == null) return -1;

            var category = MapCategoryListItemToCategory(categoryListItem);
            _categoryRepository.Insert(category);
            return category.Id;
        }

        public bool Delete(int id)
        {
            //true means we cannot delete hobby items are associated to this categroy
            if (CheckForItems(id))
            {
                return false; //we did not delete
            }

            _categoryRepository.Delete(id);
            return true;
        }

        public IQueryable<CategoryListItem> GetCategoryListItemsByGroupType(int categoryGroupId)
        {
            return MapCategoryToCategoryListItems(_categoryRepository.GetCategoryListItemsByGroupType(categoryGroupId));
        }

        private static IQueryable<CategoryListItem> MapCategoryToCategoryListItems(IQueryable<Category> categories)
        {
            if (categories == null || !categories.Any())
            {
                return Enumerable.Empty<CategoryListItem>().AsQueryable();
            }

            var categoryList = categories.Select(x => new CategoryListItem()
            {
                CategoryId = x.Id,
                CategoryType = x.CategoryType,
                CategoryGroup = x.CategoryGroup.CategoryGroupType,
                CategoryGroupId = x.CategoryGroup_Id
            });

            return categoryList;
        }

        private Category MapCategoryListItemToCategory(CategoryListItem categoryListItem)
        {
            if (categoryListItem.CategoryId <= 0)
                return new Category
                {
                    Id = categoryListItem.CategoryId,
                    CategoryType = categoryListItem.CategoryType,
                    CategoryGroup_Id = categoryListItem.CategoryGroupId,
                };

            var category = _categoryRepository.FindById(categoryListItem.CategoryId);
            //only the CategoryType can be changed
            category.CategoryType = categoryListItem.CategoryType;
            return category;
        }

        private bool CheckForItems(int categoryId)
        {
            return _categoryRepository.CheckForItems(categoryId);
        }
    }
}
