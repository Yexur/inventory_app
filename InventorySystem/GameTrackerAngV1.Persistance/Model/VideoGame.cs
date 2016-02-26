
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using GameTrackerAngV1.Persistance.Core;

namespace GameTrackerAngV1.Persistance.Model
{
    public class VideoGame : EntityBase, IHobby
    {
        [DataMember]
        public double Rating { get; set; }

        [DataMember]
        public string Publisher { get; set; }

        [DataMember]
        public string Developer { get; set; }

        [DataMember]
        [Display(Name = "Release Date")]
        public string ReleaseDate { get; set; }  //the release date is a string because it can have values like TBD, Q4 2015 etc

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

        [ForeignKey("Genre_Id")]
        public virtual Genre Genre { get; set; }

        [DataMember]
        public int Genre_Id { get; set; }

        [ForeignKey("Status_Id")]
        public virtual ItemStatus Status { get; set; }

        [DataMember]
        public int Status_Id { get; set; }

        [ForeignKey("Tracking_Id")]
        public virtual TrackingCode TrackingCode { get; set; }

        [DataMember]
        public int Tracking_Id { get; set; }

        [DataMember]
        [Required]
        public int Category_Id { get; set; }

        [ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }
    }
}
