using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using test2.Model;
using test2.Model.CitiesActions;
using Microsoft.AspNetCore.Authorization;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly TourismDbContext dbContext;
        public CitiesController(TourismDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<cities>> GetAllCities()
        {
            var cities = dbContext.cities.ToList();
            return Ok(cities);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetAllCitiesById(int id)
        {
            var cities = dbContext.cities.Find(id);
            if (cities is null)
            {
                return NotFound();
            }
            return Ok(cities);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddCities(AddCities addCities)
        {
            var CitiesEntity = new cities()
            {
                name = addCities.name,
                descreption = addCities.descreption,
                rating = addCities.rating,
                image = addCities.image,
                Latitude =addCities.Latitude,
                Longitude =addCities.Longitude,
                AveragePerNight = addCities.AveragePerNight
            };
            dbContext.cities.Add(CitiesEntity);
            dbContext.SaveChanges();
            return Ok(CitiesEntity);
        }
        [Authorize]
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCities(int id, UpdateCities updateCities)
        {
            var cities = dbContext.cities.Find(id);
            if (cities is null)
            {
                return NotFound();
            }
            cities.name = updateCities.name;
            cities.descreption = updateCities.descreption;
            cities.rating = updateCities.rating;
            cities.image = updateCities.image;
            cities.Latitude =updateCities.Latitude;
            cities.Longitude =updateCities.Longitude;
            cities.AveragePerNight = updateCities.AveragePerNight;

            dbContext.SaveChanges();
            return Ok(cities);
        }
        [Authorize]
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCities(int id)
        {
            var cities = dbContext.cities.Find(id);
            if (cities is null)
            {
                return NotFound();
            }
            dbContext.cities.Remove(cities);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
