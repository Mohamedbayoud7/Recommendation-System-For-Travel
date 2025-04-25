namespace test2.Model.ReviewActions
{
    public class AddReview
    {
        public int user_id { get; set; }
        public int trip_id { get; set; }
        public int hotel_id { get; set; }
        public double rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}