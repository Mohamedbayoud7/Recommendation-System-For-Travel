using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindController : ControllerBase
    {
        [HttpGet("{id:int}/{ Name:alpha}")]
        public IActionResult Get1(int id, string Name)
        {
            return Ok();
        }
    }
}
