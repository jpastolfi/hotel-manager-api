using HotelManager.Models;
using HotelManager.Dto;

namespace HotelManager.Repository
{
    public interface ICityRepository
    {
        IEnumerable<CityDto> GetCities();
        CityDto AddCity(City city);
        CityDto UpdateCity(City city);
    }
}