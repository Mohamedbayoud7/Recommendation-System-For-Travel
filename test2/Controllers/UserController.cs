using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using test2.Model;
using test2.Model.UserActions;
using Microsoft.AspNetCore.Authorization;

namespace test2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TourismDbContext dbContext;
        public UserController(TourismDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var AllUsers = dbContext.user.ToList();
            return Ok(AllUsers);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetAllUseresById(int id)
        {
            var user = dbContext.user.Find(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult AddUsers(AddUsers addUsers)
        {
            var UsersEntity = new user()
            {
                Name = addUsers.Name,
                Email = addUsers.Email,
                Password = addUsers.Password,
                CreatedAt = addUsers.CreatedAt
            };
            dbContext.user.Add(UsersEntity);
            dbContext.SaveChanges();
            return Ok(UsersEntity);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateUsers(int id ,UpdateUsers updateUsers)
        {
            var user = dbContext.user.Find(id);
            if (user is null)
            {
                return NotFound();
            }
            user.Name = updateUsers.Name;
            user.Email = updateUsers.Email;
            user.Password = updateUsers.Password;
            user.CreatedAt = updateUsers.CreatedAt;

            dbContext.SaveChanges();
            return Ok(user);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteUsers(int id)
        {
            var user = dbContext.user.Find(id);
            if (user is null)
            {
                return NotFound();
            }
            dbContext.user.Remove(user);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
