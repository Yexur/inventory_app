
using GameTrackerAngV1.Persistance.Model;

namespace GameTrackerAngV1.Persistance.Core
{
    public interface IHobby
    {
        string Description { get; set; }
        double Price { get; set; }
        string Note { get; set; }
        int Category_Id { get; set; }
        Category Category { get; set; }
    }
}
