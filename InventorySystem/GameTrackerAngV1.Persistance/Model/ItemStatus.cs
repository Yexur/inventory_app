using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GameTrackerAngV1.Persistance.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GameTrackerAngV1.Persistance.Model
{
    public class ItemStatus : EntityBase
    {
        private ICollection<VideoGame> _videoGames;
        private ICollection<BoardGame> _boardGames;

        [DataMember]
        [Required]
        public string Status { get; set; }

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