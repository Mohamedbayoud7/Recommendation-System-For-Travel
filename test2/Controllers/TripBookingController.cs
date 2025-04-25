using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using test2.Model;
using test2.Model.TripBookingActions;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripBookingController : ControllerBase
    {
        private readonly TourismDbContext dbContext;

        public TripBookingController(TourismDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var bookings = dbContext.tripBookings.ToList();
            return Ok(bookings);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public IActionResult GetBookingById(int id)
        {
            var booking = dbContext.tripBookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddBooking(AddTripBooking request)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var booking = new tripBookings()
            {
                user_id = userId,
                trip_id = request.trip_id,
                booking_date = DateTime.UtcNow,
                status = request.status
            };

            dbContext.tripBookings.Add(booking);
            dbContext.SaveChanges();

            return Ok(booking);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public IActionResult UpdateBooking(int id, UpdateTripBooking request)
        {
            var booking = dbContext.tripBookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            booking.booking_date = request.booking_date;
            booking.status = request.status;

            dbContext.SaveChanges();

            return Ok(booking);
        }


        [Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = dbContext.tripBookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            dbContext.tripBookings.Remove(booking);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
