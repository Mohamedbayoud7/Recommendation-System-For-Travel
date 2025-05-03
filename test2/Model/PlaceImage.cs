using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test2.Model
{
    public class PlaceImage
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public int HistoricalPlaceId { get; set; }
        [ForeignKey("HistoricalPlaceId")]
        public historicalplaces HistoricalPlace { get; set; }
    }
}