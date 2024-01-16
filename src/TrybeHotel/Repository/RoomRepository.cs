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
            _context.Rooms.Add(room);
            _context.SaveChanges();
            var query = from r in _context.Rooms
                        where r.Name == room.Name
                        select new RoomDto
                        {
                            RoomId = r.RoomId,
                            Name = r.Name,
                            Capacity = r.Capacity,
                            Image = r.Image,
                            Hotel = new HotelDto
                            {
                                HotelId = r.HotelId,
                                Name = r.Hotel!.Name,
                                Address = r.Hotel.Address,
                                CityId = r.Hotel.CityId,
                                CityName = r.Hotel.City!.Name

                            }
                        };
            return query.First();
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId)
        {
            var selectedRoom = (from room in _context.Rooms
                                where room.RoomId == RoomId
                                select room).First();

            _context.Rooms.Remove(selectedRoom);
            _context.SaveChanges();
        }
    }
}