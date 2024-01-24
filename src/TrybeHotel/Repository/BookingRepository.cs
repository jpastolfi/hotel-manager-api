using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly ITrybeHotelContext _context;
        public BookingRepository(ITrybeHotelContext context)
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
            Booking addedBooking = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingToAdd.BookingId)!;
            Hotel chosenHotel = _context.Hotels.FirstOrDefault(h => h.HotelId == addedBooking.Room!.HotelId)!;
            var response = new BookingResponse()
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
                    }
                }
            };
            return response;
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