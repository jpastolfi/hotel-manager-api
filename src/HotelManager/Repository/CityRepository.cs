using HotelManager.Models;
using HotelManager.Dto;
using System.IO.Compression;

namespace HotelManager.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly IHotelManagerContext _context;
        public CityRepository(IHotelManagerContext context)
        {
            _context = context;
        }

        // 4. Refatore o endpoint GET /city
        public IEnumerable<CityDto> GetCities()
        {
            var cityReturn = _context.Cities.Select(c => new CityDto
            {
                CityId = c.CityId,
                Name = c.Name,
                State = c.State,
            }).ToList();
            return cityReturn;
        }

        // 2. Refatore o endpoint POST /city
        public CityDto AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
            return new CityDto
            {
                CityId = city.CityId,
                Name = city.Name,
                State = city.State,
            };
        }

        // 3. Desenvolva o endpoint PUT /city
        public CityDto UpdateCity(City city)
        {
            City chosenCity = _context.Cities.FirstOrDefault(c => c.CityId == city.CityId)!;
            chosenCity.Name = city.Name;
            chosenCity.State = city.State;
            _context.SaveChanges();
            CityDto cityToReturn = new()
            {
                CityId = city.CityId,
                Name = city.Name,
                State = city.State,
            };
            return cityToReturn;
        }

    }
}