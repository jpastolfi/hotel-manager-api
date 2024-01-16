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

        // 6. Desenvolva o endpoint GET /room/:hotelId
        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            IEnumerable<RoomDto> Rooms = from room in _context.Rooms
                                         where room.HotelId == HotelId
                                         select new RoomDto
                                         {
                                             RoomId = room.RoomId,
                                             Name = room.Name,
                                             Capacity = room.Capacity,
                                             Image = room.Image,
                                             Hotel = new HotelDto
                                             {
                                                 HotelId = HotelId,
                                                 Name = room.Hotel!.Name,
                                                 Address = room.Hotel.Address,
                                                 CityId = room.Hotel.CityId,
                                                 CityName = room.Hotel.City!.Name,
                                             },
                                         };
            return Rooms;
        }

        // 7. Desenvolva o endpoint POST /room
        public RoomDto AddRoom(Room room)
        {
            throw new NotImplementedException();
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId)
        {
            throw new NotImplementedException();
        }
    }
}