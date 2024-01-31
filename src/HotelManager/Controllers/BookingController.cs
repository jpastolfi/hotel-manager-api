using Microsoft.AspNetCore.Mvc;
using HotelManager.Models;
using HotelManager.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using HotelManager.Dto;

namespace HotelManager.Controllers
{
    [ApiController]
    [Route("booking")]

    public class BookingController : Controller
    {
        private readonly IBookingRepository _repository;
        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Authorize(Policy = "Client")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Add([FromBody] BookingDtoInsert bookingInsert)
        {
            string user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
            if (user is null) return Unauthorized();
            BookingResponse response = _repository.Add(bookingInsert, user);
            if (response == null) return BadRequest(new { message = "Guest quantity over room capacity" });
            return Created("", response);
        }


        [HttpGet("{Bookingid}")]
        [Authorize(Policy = "Client")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetBooking(int Bookingid)
        {
            string user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
            if (user is null) return Unauthorized();
            var foundBooking = _repository.GetBooking(Bookingid, user);
            if (foundBooking is null) return Unauthorized();
            return Ok(foundBooking);
        }
    }
}