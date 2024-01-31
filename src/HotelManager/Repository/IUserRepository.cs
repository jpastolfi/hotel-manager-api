using HotelManager.Models;
using HotelManager.Dto;

namespace HotelManager.Repository
{
    public interface IUserRepository
    {
        UserDto GetUserById(int userId);
        UserDto Add(UserDtoInsert user);
        UserDto Login(LoginDto login);
        UserDto GetUserByEmail(string userEmail);
        IEnumerable<UserDto> GetUsers();
    }

}