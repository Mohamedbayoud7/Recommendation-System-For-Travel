using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using test2.Model.CitiesActions;
using test2.Model;
using System.Linq;
using test2.Model.HistoricalPlacesActions;
using Microsoft.AspNetCore.Authorization;


namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricalPlacesController : ControllerBase
    {
        private readonly TourismDbContext dbContext;
        public HistoricalPlacesController(TourismDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllHistoricalPlaces()
        {
            var AllHistoricalPlaces = dbContext.historicalplaces.ToList();
            return Ok(AllHistoricalPlaces);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetAllHistoricalPlacesById(int id)
        {
            var historicalPlace = dbContext.historicalplaces.Find(id);
            if (historicalPlace is null)
            
                return NotFound();
            var images = dbContext.PlaceImages
        .Where(h => h.HistoricalPlaceId == id)
        .Select(i => i.ImageUrl)
        .ToList();

            return Ok(new
            {
                historicalPlace.place_id,
                historicalPlace.name,
                historicalPlace.city_id,
                historicalPlace.descreption,
                historicalPlace.rating,
                historicalPlace.entry_fee,
                Images = images

            });
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddHistoricalPlaces(AddHistoricalPlaces addHistoricalPlaces)
        {
            var HistoricalPlacesEntity = new historicalplaces()
            {
                place_id = addHistoricalPlaces.place_id,
                name = addHistoricalPlaces.name,
                city_id = addHistoricalPlaces.city_id,
                descreption = addHistoricalPlaces.descreption,
                rating = addHistoricalPlaces.rating,
                entry_fee = addHistoricalPlaces.entry_fee
            };
            dbContext.historicalplaces.Add(HistoricalPlacesEntity);
            dbContext.SaveChanges();
            return Ok(HistoricalPlacesEntity);
        }
        [Authorize]
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateHistoricalPlaces(int id, UpdateHistoricalPlaces updateHistoricalPlaces)
        {
            var HistoricalPlaces = dbContext.historicalplaces.Find(id);
            if (HistoricalPlaces is null)
            {
                return NotFound();
            }
            HistoricalPlaces.name = updateHistoricalPlaces.name;
            HistoricalPlaces.descreption = updateHistoricalPlaces.descreption;
            HistoricalPlaces.rating = updateHistoricalPlaces.rating;
            HistoricalPlaces.entry_fee = updateHistoricalPlaces.entry_fee;

            dbContext.SaveChanges();
            return Ok(HistoricalPlaces);
        }
        [Authorize]
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteHistoricalPlaces(int id)
        {
            var HistoricalPlaces = dbContext.historicalplaces.Find(id);
            if (HistoricalPlaces is null)
            {
                return NotFound();
            }
            dbContext.historicalplaces.Remove(HistoricalPlaces);
            dbContext.SaveChanges();
            return Ok();
        }
        [Authorize]
        [HttpPost("upload/{placeId}")]
        public async Task<IActionResult> UploadImage(int placeId, IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("No image uploaded.");

            var historicalPlace = dbContext.historicalplaces.Find(placeId);
            if (historicalPlace == null)
                return NotFound("Historical Place not found.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/historicalplaces");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var placeImage = new PlaceImage
            {
                ImageUrl = $"/images/historicalplaces/{fileName}",  
                HistoricalPlaceId = placeId  
            };

            dbContext.PlaceImages.Add(placeImage);
            dbContext.SaveChanges();

            return Ok(new { ImageUrl = placeImage.ImageUrl });
        }
        

    }
}
