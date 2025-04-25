using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test2.Model;
using test2.Model.HotelBookingAction;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly TourismDbContext dbContext;
        public HotelBookingController(TourismDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }

        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var bookings = dbContext.hotelbookings.ToList();
            return Ok(bookings);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBookingById(int id)
        {
            var booking = dbContext.hotelbookings.Find(id);
            if (booking is null)
                return NotFound();

            return Ok(booking);
        }

        [HttpPost]
        public IActionResult AddBooking(AddHotelBooking model)
        {
            var booking = new hotelbookings()
            {
                user_id = model.user_id,
                hotel_id = model.hotel_id,
                bookingDate = model.bookingDate,
                status = model.status
            };

            dbContext.hotelbookings.Add(booking);
            dbContext.SaveChanges();
            return Ok(booking);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBooking(int id, UpdateHotelBooking model)
        {
            var booking = dbContext.hotelbookings.Find(id);
            if (booking is null)
                return NotFound();

            booking.bookingDate = model.bookingDate;
            booking.status = model.status;

            dbContext.SaveChanges();
            return Ok(booking);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = dbContext.hotelbookings.Find(id);
            if (booking is null)
                return NotFound();

            dbContext.hotelbookings.Remove(booking);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
