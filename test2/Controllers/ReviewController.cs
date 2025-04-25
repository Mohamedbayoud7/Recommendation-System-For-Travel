using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test2.Model;
using test2.Model.ReviewActions;


namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly TourismDbContext dbContext;
        public ReviewController(TourismDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllReviews()
        {
            var reviews = dbContext.reviews.ToList();
            return Ok(reviews);
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public IActionResult GetReviewById(int id)
        {
            var review = dbContext.reviews.Find(id);
            if (review == null)
                return NotFound();

            return Ok(review);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddReview(AddReview model)
        {
            var newReview = new reviews
            {
                user_id = model.user_id,
                trip_id = model.trip_id,
                hotel_id = model.hotel_id,
                rating = model.rating,
                Comment = model.Comment,
                CreatedAt = model.CreatedAt
            };

            dbContext.reviews.Add(newReview);
            dbContext.SaveChanges();
            return Ok(newReview);
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public IActionResult UpdateReview(int id, UpdateReview model)
        {
            var review = dbContext.reviews.Find(id);
            if (review == null)
                return NotFound();

            review.rating = model.rating;
            review.Comment = model.Comment;

            dbContext.SaveChanges();
            return Ok(review);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public IActionResult DeleteReview(int id)
        {
            var review = dbContext.reviews.Find(id);
            if (review == null)
                return NotFound();

            dbContext.reviews.Remove(review);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
