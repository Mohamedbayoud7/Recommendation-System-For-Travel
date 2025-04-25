using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test2.Model.CitiesActions;
using test2.Model;
using test2.Model.HotelAction;
using Microsoft.AspNetCore.Authorization;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly TourismDbContext dbContext;
        public HotelController(TourismDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var AllHotels = dbContext.hotels.ToList();
            return Ok(AllHotels);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetAllHotelsById(int id)
        {
            var hotels = dbContext.hotels.Find(id);
            if (hotels is null)
            {
                return NotFound();
            }
            return Ok(hotels);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddHotels(AddHotels addHotels)
        {
            var HotelsEntity = new hotels()
            {
                hotel_id = addHotels.hotel_id,
                name = addHotels.name,
                city_id = addHotels.city_id,
                address = addHotels.address,
                Latitude = addHotels.Latitude,
                Longitude = addHotels.Longitude,
                price_per_night = addHotels.price_per_night,
                rating = addHotels.rating
            };
            dbContext.hotels.Add(HotelsEntity);
            dbContext.SaveChanges();
            return Ok(HotelsEntity);
        }
        [Authorize]
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateHotels(int id, UpdateHotels updateHotels)
        {
            var hotels = dbContext.hotels.Find(id);
            if (hotels is null)
            {
                return NotFound();
            }
            hotels.name = updateHotels.name;
            hotels.descreption = updateHotels.descreption;
            hotels.address = updateHotels.address;
            hotels.Latitude = updateHotels.Latitude;
            hotels.Longitude = updateHotels.Longitude;
            hotels.price_per_night = updateHotels.price_per_night;
            hotels.rating = (decimal)(double)updateHotels.rating;

            dbContext.SaveChanges();
            return Ok(hotels);
        }
        [Authorize]
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteHotels(int id)
        {
            var hotels = dbContext.hotels.Find(id);
            if (hotels is null)
            {
                return NotFound();
            }
            dbContext.hotels.Remove(hotels);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
