using Microsoft.AspNetCore.Mvc;
using HotelManager.Models;
using HotelManager.Repository;
using HotelManager.Dto;
using HotelManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HotelManager.Controllers
{
    [ApiController]
    [Route("login")]

    public class LoginController : Controller
    {

        private readonly IUserRepository _repository;
        public LoginController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto login)
        {
            var validUser = _repository.Login(login);
            if (validUser == null) return Unauthorized(new
            {
                message = "Incorrect e-mail or password"
            });

            string token = new TokenGenerator().Generate(validUser);
            return Ok(new { token });
        }
    }
}