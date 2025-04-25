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
        public IActionResult GetAllHistoricalPlacesById(int id,object historicalplaces)
        {
            var HistoricalPlaces = dbContext.historicalplaces.Find(id);
            if (HistoricalPlaces is null)
            {
                return NotFound();
            }
            return Ok(historicalplaces);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddHistoricalPlaces(AddHistoricalPlaces addHistoricalPlaces)
        {
            //var HistoricalPlacesEntity = new historicalplaces()
            var HistoricalPlacesEntity = new historicalplaces()
            {
                place_id = addHistoricalPlaces.place_id,
                name = addHistoricalPlaces.name,
                city_id = addHistoricalPlaces.city_id,
                descreption = addHistoricalPlaces.descreption,
                rating = addHistoricalPlaces.rating,
                image = addHistoricalPlaces.image,
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
            HistoricalPlaces.image = updateHistoricalPlaces.image;
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
    }
}
