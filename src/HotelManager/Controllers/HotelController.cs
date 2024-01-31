using Microsoft.AspNetCore.Mvc;
using HotelManager.Models;
using HotelManager.Repository;
using HotelManager.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HotelManager.Controllers
{
    [ApiController]
    [Route("hotel")]
    /* [Authorize] */
    public class HotelController : Controller
    {
        private readonly IHotelRepository _repository;

        public HotelController(IHotelRepository repository)
        {
            _repository = repository;
        }

        // 4. Desenvolva o endpoint GET /hotel
        [HttpGet]
        public IActionResult GetHotels()
        {
            return Ok(_repository.GetHotels());
        }

        // 5. Desenvolva o endpoint POST /hotel
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Policy = "admin")]
        public IActionResult PostHotel([FromBody] Hotel hotel)
        {
            return Created("", _repository.AddHotel(hotel));
        }


    }
}