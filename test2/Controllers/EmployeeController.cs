using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using test2.Model;

namespace test2.Controllers
{
    [Route("api/[controller]")] //api/Employee
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly TourismDbContext context;

        public EmployeeController(TourismDbContext _Context)
        {
            context = _Context;
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
            List<user> users = context.user.ToList();
            return Ok(users);
        }
        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            user user = context.user.FirstOrDefault(e => e.Id == Id);
            return Ok(user);
        }
        [HttpPut("{Id}")]
        public IActionResult PutEmployee([FromRoute] int Id, [FromBody] user emp)
        {
            if (ModelState.IsValid)
            {
                user oldEmp = context.user.FirstOrDefault(e => e.Id == Id);
                oldEmp.Id = emp.Id;
                oldEmp.Name = emp.Name;
                oldEmp.Password = emp.Password;
                context.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return BadRequest(ModelState);
            {
                return Ok();
            }
            /*[HttpDelete]
            public IActionResult DeleteEmployee()
            {
                return Ok();
            }*/
        }
    }
}
