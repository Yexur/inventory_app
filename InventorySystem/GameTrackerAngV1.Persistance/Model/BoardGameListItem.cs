
namespace GameTrackerAngV1.Persistance.Model
{
    public class BoardGameListItem
    {
        public double Rating { get; set; }

        public string Publisher { get; set; }

        public string Designer { get; set; }

        public string NumberOfPlayers { get; set; } //this is a string because the values will be 1-4, 4-6, 8 etc.
        
        public string PlayingTime { get; set; } // this is a string becasue the playing time can be 30-40 minutes, 50 min - 1 hour etc.
        
        public string PurchaseMonth { get; set; }
        
        public string Description { get; set; }
        
        public double Price { get; set; }
        
        public string Note { get; set; }
        
        public string Status { get; set; }

        public string CategoryType { get; set; }

        public int CategoryId { get; set; }

        public int BoardGameId { get; set; }
    }
}
