
using System.ComponentModel.DataAnnotations;

namespace GameTrackerAngV1.Persistance.Core
{
    public class EntityBase : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}