using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test2.Model
{
    public class user
    {
        internal static int id;

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public DateTime CreatedAt { get; set; }
        //Relationships
        public ICollection<hotelbookings> hotelbookings { get; set; }
        public ICollection<tripBookings> tripBookings { get; set; }
        public ICollection<reviews> reviews { get; set; }

    }
    public class cities
    {
        internal string address;
        internal decimal price_per_night;

        [Key]
        public int city_id { get; set; }
        public string name { get; set; }
        public string descreption { get; set; }
        public int rating { get; set; }
        public string image { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [NotMapped]
        public int AveragePerNight { get; set; }
        //Relationships
        public ICollection<hotels> hotels { get; set; }
        public ICollection<historicalplaces> historicalPlaces { get; set; }
        public ICollection<trips> trips { get; set; }

    }

    public class hotels
    {
        [Key]
        public int hotel_id { get; set; }
        public string name { get; set; }
        public string descreption { get; set; }
        public int city_id { get; set; }
        public string address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public decimal price_per_night { get; set; }
        public decimal rating { get; set; }
        public int HistoricalPlaceId { get; set; }
        public ICollection<HotelImage> Images { get; set; }



        //Relationships
        [ForeignKey("HistoricalPlaceId")]
        public historicalplaces HistoricalPlace { get; set; }

        public cities cities { get; set; }
        public ICollection<hotelbookings>hotelbookings { get; set; }
        public ICollection<reviews>reviews  { get; set; }
        
    }

    

    public enum hotelrating
    {
        zero = 0,
        one = 1,
        two = 2,
        three = 3,
        four = 4,
        five = 5
    }

    public class historicalplaces
    {
        [Key]
        public int place_id { get; set; }
        public string name { get; set; }
        public int city_id { get; set; }
        public string descreption { get; set; }
        public int rating { get; set; }
        public decimal entry_fee { get; set; }
        public ICollection<PlaceImage> Images { get; set; }

        //Relationships
        public cities cities { get; set; }
        public ICollection<hotels> hotels { get; set; }
        public ICollection<trips> trips { get; set; }
    }
public class trips
    {
        [Key]
        public int trip_id { get; set; }
        public string title { get; set; }
        public int city_id { get; set; }
        public decimal price { get; set; }
        public int duration { get; set; }
        public string description { get; set; }
        //Relationships
        public cities cities { get; set; }
        public ICollection<hotelbookings> hotelbookings { get; set; }
        public ICollection<tripBookings> tripBookings { get; set; }
        public ICollection<reviews> reviews { get; set; }

    }
    public class hotelbookings
    {
        [Key]
        public int booking_id { get; set; }
        public int user_id { get; set; }
        public int hotel_id { get; set; }
        public DateTime bookingDate { get; set; }
        public string status { get; set; }
        //Relationships
        public user user { get; set; }
        public hotels hotels { get; set; }
    }
    public enum bookingStatus
    {
        pending,
        confirmed,
        cancelled

    }
    public class tripBookings
    {
        [Key]
        public int booking_id { get; set; }
        public int user_id { get; set; }
        public int trip_id { get; set; }
        public user user { get; set; }
        public trips trips { get; set; }
        public DateTime booking_date { get; set; }
        public string status { get; set; }

    }
    public class reviews
    {
        [Key]
        public int review_id { get; set; }
        public int user_id { get; set; }
        public int trip_id { get; set; }
        public int hotel_id { get; set; }
        public double rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        //Relationships
        public user user { get; set; }
        public trips trips { get; set; }
        public hotels hotels { get; set; }


    }
}
