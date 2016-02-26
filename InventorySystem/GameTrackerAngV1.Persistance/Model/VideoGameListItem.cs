
namespace GameTrackerAngV1.Persistance.Model
{
    public class VideoGameListItem
    {
        public double Rating { get; set; }

        public string Publisher { get; set; }

        public string Developer { get; set; }

        public string ReleaseDate { get; set; }  //the release date is a string because it can have values like TBD, Q4 2015 etc

        public string Genre { get; set; }

        public string TrackingCode { get; set; }

        public string PurchaseMonth { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Note { get; set; }

        public string Status { get; set; }

        public string CategoryType { get; set; }

        public int CategoryId { get; set; }

        public int VideoGameId { get; set; }
    }
}
