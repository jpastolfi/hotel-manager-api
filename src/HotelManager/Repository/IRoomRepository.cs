using HotelManager.Models;
using HotelManager.Dto;

namespace HotelManager.Repository
{
    public interface IRoomRepository
    {
        IEnumerable<RoomDto> GetRooms(int HotelId);
        RoomDto AddRoom(Room room);

        void DeleteRoom(int RoomId);
    }
}