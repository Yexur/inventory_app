
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GameTrackerAngV1.Persistance.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GameTrackerAngV1.Persistance.Model
{
    public class Genre : EntityBase    {

        private ICollection<VideoGame> _videoGames;

        [DataMember]
        [Required]
        public string GenreType { get; set; }

        public virtual ICollection<VideoGame> VideoGames
        {
            get { return _videoGames ?? (new Collection<VideoGame>()); }
            set { _videoGames = value; }
        }
    }
}
