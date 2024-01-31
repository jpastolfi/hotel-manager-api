using Microsoft.AspNetCore.Mvc;


namespace HotelManager.Controllers
{
    [ApiController]
    [Route("/")]
    public class StatusController : Controller
    {
        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok(new { message = "online" });
        }
    }
}
