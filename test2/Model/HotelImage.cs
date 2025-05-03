using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test2.Model
{
    public class HotelImage
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public hotels Hotel { get; set; }

    }
}