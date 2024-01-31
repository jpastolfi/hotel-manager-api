using HotelManager.Models;
using HotelManager.Dto;

namespace HotelManager.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly IHotelManagerContext _context;
        public HotelRepository(IHotelManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<HotelDto> GetHotels()
        {
            IEnumerable<HotelDto> hotelsReturn = from hotel in _context.Hotels
                                                 join city in _context.Cities
                                                 on hotel.CityId equals city.CityId
                                                 select new HotelDto()
                                                 {
                                                     HotelId = hotel.HotelId,
                                                     Name = hotel.Name,
                                                     Address = hotel.Address,
                                                     CityId = city.CityId,
                                                     CityName = city.Name,
                                                     State = city.State,
                                                 };

            return hotelsReturn.ToList();
        }

        public HotelDto AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            var teste = from h in _context.Hotels
                        join c in _context.Cities
                        on h.CityId equals c.CityId
                        where h.Name == hotel.Name
                        select new HotelDto()
                        {
                            HotelId = h.HotelId,
                            Name = h.Name,
                            Address = h.Address,
                            CityId = c.CityId,
                            CityName = c.Name,
                            State = c.State,
                        };
            return teste.First();
        }
    }
}