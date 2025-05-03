using System.ComponentModel.DataAnnotations.Schema;

namespace test2.Model.HotelAction
{
    public class UpdateHotels
    {
        public string name { get; set; }
        public string descreption { get; set; }
        public string address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public decimal price_per_night { get; set; }
        public decimal rating { get; set; }
        public int HistoricalplaceId { get; set; }

    }
}