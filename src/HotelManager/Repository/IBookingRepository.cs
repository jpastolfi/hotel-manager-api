using HotelManager.Models;
using HotelManager.Dto;

namespace HotelManager.Repository
{
    public interface IBookingRepository
    {
        BookingResponse Add(BookingDtoInsert booking, string email);
        Room GetRoomById(int RoomId);
        BookingResponse GetBooking(int bookingId, string email);
    }
}