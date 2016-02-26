using System.Collections.Generic;
using System.Linq;
using GameTrackerAngV1.Persistance.IRepository;
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Repository
{
    //public class HobbyRepository : Core.Repository<Hobby> , IHobbyRepository
    //{
    //    public HobbyRepository(GameTrackerContext context) : base(context)
    //    {
    //    }

    //    public IQueryable<Hobby> GetHobbyByCategoryId(int categoryId)
    //    {
    //        return GameTrackerContext.Hobbys.Where(b => b.Category_Id == categoryId);
    //    }

    //    public IQueryable<Hobby> GetHobbyByGroup(IEnumerable<int> categoryIds)
    //    {
    //        return GameTrackerContext.Hobbys.Where(b => categoryIds.Contains(b.Category_Id));
    //    }
    //}
}
