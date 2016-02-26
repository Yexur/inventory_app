
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using GameTrackerAngV1.Persistance.Core;

namespace GameTrackerAngV1.Persistance.Model
{
    public class BoardGame : EntityBase, IHobby
    {
        [DataMember]
        public double Rating { get; set; }

        [DataMember]
        public string Publisher { get; set; }

        [DataMember]
        public string Designer { get; set; }

        [DataMember]
        [Display(Name = "Number of Players")]
        public string NumberOfPlayers { get; set; } //this is a string because the values will be 1-4, 4-6, 8 etc.

        [DataMember]
        [Display(Name = "Playing Time")]
        public string PlayingTime { get; set; } // this is a string becasue the playing time can be 30-40 minutes, 50 min - 1 hour etc.

        [DataMember]
        [Display(Name = "Month Purchased")]
        public string PurchaseMonth { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Title")]
        public string Description { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]
        public int Status_Id { get; set; }

        [ForeignKey("Status_Id")]
        public virtual ItemStatus Status { get; set; }

        [DataMember]
        [Required]
        public int Category_Id { get; set; }

        [ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }
    }
}


