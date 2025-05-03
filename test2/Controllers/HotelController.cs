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
            var hotels = dbContext.hotels.Select(h => new{
                h.hotel_id,
                h.name,
                h.address,
                h.price_per_night,
                h.rating,
                h.Latitude,
                h.Longitude,
                Images = dbContext.HotelImages
                        .Where(i => i.HotelId == h.hotel_id)
                        .Select(i => i.ImageUrl)
                        .ToList()

            }).ToList();
            return Ok(hotels);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetAllHotelsById(int id)
        {
            var hotels = dbContext.hotels.Find(id);
            if (hotels is null)
            
                return NotFound();
            var images = dbContext.HotelImages
        .Where(h => h.HotelId == id)
        .Select(i => i.ImageUrl)
        .ToList();
            return Ok(new
            {
                hotels.hotel_id,
                hotels.name,
                hotels.address,
                hotels.price_per_night,
                hotels.rating,
                hotels.Latitude,
                hotels.Longitude,
                Images = images
            });
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
        [Authorize]
        [HttpPost("upload/{hotelId}")]
        public async Task<IActionResult> UploadImage(int hotelId, IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("No image uploaded.");

            var hotel = dbContext.hotels.Find(hotelId);
            if (hotel == null)
                return NotFound("Hotel not found.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/hotels");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var hotelImage = new HotelImage
            {
                ImageUrl = $"/images/hotels/{fileName}",  
                HotelId = hotelId  
            };

            dbContext.HotelImages.Add(hotelImage);
            dbContext.SaveChanges();

            return Ok(new { ImageUrl = hotelImage.ImageUrl });
        }
        

    }
}
