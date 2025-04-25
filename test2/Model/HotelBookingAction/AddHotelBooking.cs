namespace test2.Model.HotelBookingAction
{
    public class AddHotelBooking
    {
        public int user_id { get; set; }
        public int hotel_id { get; set; }
        public DateTime bookingDate { get; set; }
        public string status { get; set; }
    }
}