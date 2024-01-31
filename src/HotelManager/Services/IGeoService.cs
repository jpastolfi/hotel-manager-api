using HotelManager.Dto;
using HotelManager.Repository;

namespace HotelManager.Services
{
    public interface IGeoService
    {
        Task<object> GetGeoStatus();
        Task<List<GeoDtoHotelResponse>> GetHotelsByGeo(GeoDto geoDto, IHotelRepository repository);
    }
}