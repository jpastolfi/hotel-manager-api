using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.AspNetCore.Mvc;

namespace TrybeHotel.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly ITrybeHotelContext _context;
        public CityRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 2. Desenvolva o endpoint GET /city
        public IEnumerable<CityDto> GetCities()
        {
            var cityReturn = _context.Cities.Select(c => new CityDto
            {
                CityId = c.CityId,
                Name = c.Name
            }).ToList();
            return cityReturn;
        }

        // 3. Desenvolva o endpoint POST /city
        public CityDto AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
            return new CityDto
            {
                CityId = city.CityId,
                Name = city.Name
            };
        }

    }
}