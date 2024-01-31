using HotelManager.Models;
using HotelManager.Dto;

namespace HotelManager.Repository
{
    public interface IHotelRepository
    {
        IEnumerable<HotelDto> GetHotels();
        HotelDto AddHotel(Hotel hotel);
    }
}