using TrybeHotel.Models;
using TrybeHotel.Dto;
using System.IO.Compression;

namespace TrybeHotel.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ITrybeHotelContext _context;
        public UserRepository(ITrybeHotelContext context)
        {
            _context = context;
        }
        public UserDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto Login(LoginDto login)
        {
            var userObj = _context.Users.FirstOrDefault(user => user.Email! == login.Email && user.Password! == login.Password);
            if (userObj == null) return null!;
            return new UserDto
            {
                UserId = userObj.UserId,
                Name = userObj.Name,
                Email = userObj.Email,
                UserType = userObj.UserType,
            };
        }
        public UserDto Add(UserDtoInsert user)
        {
            User userObj = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserType = "client",
            };
            _context.Users.Add(userObj);
            _context.SaveChanges();
            return new UserDto
            {
                UserId = userObj.UserId,
                Name = userObj.Name,
                Email = userObj.Email,
                UserType = userObj.UserType
            };
        }

        public UserDto GetUserByEmail(string userEmail)
        {
            var selectedUser = _context.Users.FirstOrDefault(user => user.Email!.Equals(userEmail));
            if (selectedUser == null) return null!;
            return new UserDto
            {
                UserId = selectedUser.UserId,
                Name = selectedUser.Name,
                Email = selectedUser.Email,
                UserType = selectedUser.UserType,
            };
        }

        public IEnumerable<UserDto> GetUsers()
        {
            throw new NotImplementedException();
        }

    }
}