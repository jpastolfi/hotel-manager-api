using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomDto> GetRooms(int HotelId) {
            throw new NotImplementedException();
        }

        public RoomDto AddRoom(Room room) {
           throw new NotImplementedException();
        }

        public void DeleteRoom(int RoomId) {
            throw new NotImplementedException();
        }
    }
}