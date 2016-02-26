using System.Collections.Generic;
using System.Linq;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Logic
{
   //public class HobbyLogic : IHobbyLogic
    //{
    //    private readonly IHobbyRepository _hobbyRepository;
    //    private readonly ICategoryRepository _categoryRepository;

    //    public HobbyLogic(IHobbyRepository hobbyRepository, ICategoryRepository categoryRepository)
    //    {
    //        _hobbyRepository = hobbyRepository;
    //        _categoryRepository = categoryRepository;
    //    }

    //    public Hobby Get(int id)
    //    {
    //        return _hobbyRepository.FindById(id);
    //    }

    //    public IQueryable<HobbyItemListItem> GetList()
    //    {
    //        return MapHobbyToHobbyItem(_hobbyRepository.All());
    //    }

    //    public int Save(HobbyItemListItem hobbyItemListItem)
    //    {
    //        if (hobbyItemListItem == null) return -1;

    //        var hobby = MapHobbyItemToHobby(hobbyItemListItem);
    //        _hobbyRepository.Insert(hobby);
    //        return hobby.Id;
    //    }

    //    public bool Delete(int id)
    //    {
    //        _hobbyRepository.Delete(id);
    //        return true;
    //     
    //    }

    //    public IQueryable<HobbyItemListItem> GetHobbyItemsByCategoryId(CategoryListItem category)
    //    {
    //        if (category.CategoryId <= 0)
    //        {
    //            //get all the CategoryListItems for a Category Group
    //            var categories = _categoryRepository.GetCategoryListItemsByGroupType(category.CategoryGroupId);
    //            var listofCateoryIds = GetCategoryIds(categories);
    //            return MapHobbyItemToHobbyItemListItem(_hobbyItemRepository.GetHobbyItemsByGroup(listofCateoryIds));
    //        }

    //        return MapHobbyItemToHobbyItemListItem(_hobbyItemRepository.GetHobbyItemsByCategoryId(category.CategoryId));
    //    }

    //    private static IEnumerable<int> GetCategoryIds(IQueryable<Category> categories)
    //    {
    //        if (categories == null || !categories.Any())
    //        {
    //            return new List<int>();
    //        }

    //        var listofCateoryIds = new List<int>(categories.Select(category => category.Id));

    //        return listofCateoryIds;
    //    }

    //    private static IQueryable<HobbyItemListItem> MapHobbyItemToHobbyItemListItem(IQueryable<HobbyItem> hobbyItems)
    //    {
    //        if (hobbyItems == null || !hobbyItems.Any())
    //        {
    //            return Enumerable.Empty<HobbyItemListItem>().AsQueryable();
    //        }

    //        var hobbyList = hobbyItems.Select(x => new HobbyItemListItem
    //        {
    //            HobbyId = x.Id,
    //            CategoryId = x.Category_Id,
    //            ItemDescription = x.ItemDescription,
    //            Price = x.Price,
    //            Rating = x.Rating,
    //            CategoryType = x.Category.CategoryType,
    //            Publisher = x.Publisher,
    //            Developer = x.Developer,
    //            HobbyItemStatus = x.HobbyItemStatus
                
    //        }).OrderBy(s => s.HobbyItemStatus);

    //        return hobbyList;


    //    }

    //    private static HobbyItem MapHobbyItemListItemToHobbyItem(HobbyItemListItem hobbyItemListItem)
    //    {
    //        return new HobbyItem
    //        {
    //            Id = hobbyItemListItem.HobbyId,
    //            Category_Id = hobbyItemListItem.CategoryId,
    //            HobbyItemStatus = hobbyItemListItem.HobbyItemStatus,
    //            Developer = hobbyItemListItem.Developer,
    //            Publisher = hobbyItemListItem.Publisher,
    //            ItemDescription = hobbyItemListItem.ItemDescription,
    //            Price = hobbyItemListItem.Price,
    //            Rating = hobbyItemListItem.Rating
    //        };
    //    }
    //}
}




