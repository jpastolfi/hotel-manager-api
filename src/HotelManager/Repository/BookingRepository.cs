using HotelManager.Models;
using HotelManager.Dto;
using Microsoft.EntityFrameworkCore;

namespace HotelManager.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly IHotelManagerContext _context;
        public BookingRepository(IHotelManagerContext context)
        {
            _context = context;
        }

        public BookingResponse Add(BookingDtoInsert booking, string email)
        {
            Room roomToBook = GetRoomById(booking.RoomId);
            if (booking.GuestQuant > roomToBook.Capacity) return null!;
            var userToBook = _context.Users.First(u => u.Email == email);
            Booking bookingToAdd = new()
            {
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestQuant = booking.GuestQuant,
                UserId = userToBook.UserId,
                RoomId = booking.RoomId,
                User = userToBook,
                Room = roomToBook,
            };
            _context.Bookings.Add(bookingToAdd);
            _context.SaveChanges();
            var response = (from b in _context.Bookings
                            join r in _context.Rooms
                            on b.Room!.Name equals r.Name
                            join h in _context.Hotels
                            on r.Hotel!.HotelId equals h.HotelId
                            where b.BookingId == bookingToAdd.BookingId
                            select new BookingResponse()
                            {
                                BookingId = b.BookingId,
                                CheckIn = b.CheckIn,
                                CheckOut = b.CheckOut,
                                GuestQuant = b.GuestQuant,
                                Room = new RoomDto()
                                {
                                    RoomId = r.RoomId,
                                    Name = r.Name,
                                    Capacity = r.Capacity,
                                    Image = r.Image,
                                    Hotel = new HotelDto()
                                    {
                                        HotelId = h.HotelId,
                                        Name = h.Name,
                                        Address = h.Address,
                                        CityId = h.CityId,
                                        CityName = h.City!.Name,
                                        State = h.City.State,
                                    }
                                }
                            }).FirstOrDefault();
            return response!;
            /* var response = new BookingResponse()
            {
                BookingId = addedBooking.BookingId,
                CheckIn = addedBooking.CheckIn,
                CheckOut = addedBooking.CheckOut,
                GuestQuant = addedBooking.GuestQuant,
                Room = new RoomDto()
                {
                    RoomId = addedBooking.Room!.RoomId,
                    Name = addedBooking.Room.Name,
                    Capacity = addedBooking.Room.Capacity,
                    Image = addedBooking.Room.Image,
                    Hotel = new HotelDto()
                    {
                        HotelId = chosenHotel.HotelId,
                        Name = chosenHotel.Name,
                        Address = chosenHotel.Address,
                        CityId = chosenHotel.CityId,
                        CityName = chosenHotel.Name,
                        State = chosenHotel.City!.State,
                    }
                }
            }; */
            /* return response; */
        }

        public BookingResponse GetBooking(int bookingId, string email)
        {
            Booking foundBooking = _context.Bookings
                .Include(b => b.Room)
                .ThenInclude(r => r!.Hotel)
                .ThenInclude(c => c!.City)
                .Include(b => b.User)
                .FirstOrDefault(b => b.BookingId == bookingId)!;
            if (foundBooking.User!.Email != email) return null!;
            return new()
            {
                BookingId = foundBooking!.BookingId,
                CheckIn = foundBooking.CheckIn,
                CheckOut = foundBooking.CheckOut,
                GuestQuant = foundBooking.GuestQuant,
                Room = new RoomDto()
                {
                    RoomId = foundBooking.RoomId,
                    Name = foundBooking.Room!.Name,
                    Capacity = foundBooking.Room.Capacity,
                    Image = foundBooking.Room.Image,
                    Hotel = new HotelDto()
                    {
                        HotelId = foundBooking.Room.HotelId,
                        Name = foundBooking.Room.Hotel!.Name,
                        Address = foundBooking.Room.Hotel.Address,
                        CityId = foundBooking.Room.Hotel.CityId,
                        CityName = foundBooking.Room.Hotel.City!.Name,
                        State = foundBooking.Room.Hotel.City.State,
                    }
                }
            };
        }

        public Room GetRoomById(int RoomId)
        {
            Room room = _context.Rooms.First(r => r.RoomId == RoomId);
            if (room == null) return null!;
            return room;
        }

    }

}