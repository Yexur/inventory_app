
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using GameTrackerAngV1.Persistance.Core;

namespace GameTrackerAngV1.Persistance.Model
{
    public class Category: EntityBase
        
    {
        private ICollection<VideoGame> _videoGames;
        private ICollection<BoardGame> _boardGames;
        
        [DataMember]
        [Required] 
        public string CategoryType { get; set; }

        [DataMember]
        [Required]
        public int CategoryGroup_Id { get; set; }

        [ForeignKey("CategoryGroup_Id")]
        public virtual CategoryGroup CategoryGroup { get; set; }

       public virtual ICollection<VideoGame> VideoGames
       {
            get { return _videoGames ?? (new Collection<VideoGame>()); }
            set { _videoGames = value; }
       }

       public virtual ICollection<BoardGame> BoardGames
       {
           get { return _boardGames ?? (new Collection<BoardGame>()); }
           set { _boardGames = value; }
       }
    }
}
