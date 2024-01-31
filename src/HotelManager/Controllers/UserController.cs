using Microsoft.AspNetCore.Mvc;
using HotelManager.Models;
using HotelManager.Repository;
using HotelManager.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HotelManager.Controllers
{
    [ApiController]
    [Route("user")]

    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult GetUsers()
        {
            IEnumerable<UserDto> foundUsers = _repository.GetUsers();
            return Ok(foundUsers);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserDtoInsert user)
        {
            var repetedUserCheck = _repository.GetUserByEmail(user.Email!);
            if (repetedUserCheck != null) return Conflict(new { message = "User email already exists" });
            var addUser = _repository.Add(user);
            return Created("", addUser);
        }
    }
}