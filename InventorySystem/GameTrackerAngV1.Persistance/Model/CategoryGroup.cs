using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GameTrackerAngV1.Persistance.Core;

namespace GameTrackerAngV1.Persistance.Model
{
    public class CategoryGroup : EntityBase
    {
        private ICollection<Category> _categories;

        [DataMember]
        [Required] 
        public string CategoryGroupType { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return _categories ?? (_categories = new Collection<Category>()); }
            set { _categories = value; }
        }
    }
}
