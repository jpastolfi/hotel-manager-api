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
            User foundUser = _context.Users.FirstOrDefault(u => u.UserId == userId)!;
            if (foundUser is null) return null!;
            return new UserDto()
            {
                UserId = foundUser.UserId,
                Name = foundUser.Name,
                Email = foundUser.Email,
                UserType = foundUser.UserType,
            };
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
            User userObj = new()
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
            IEnumerable<User> foundUsers = _context.Users;
            var userList = foundUsers.Select(u => new UserDto()
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                UserType = u.UserType,
            });
            return userList;
        }
    }
}