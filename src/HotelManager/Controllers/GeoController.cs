using Microsoft.AspNetCore.Mvc;
using HotelManager.Models;
using HotelManager.Repository;
using HotelManager.Dto;
using HotelManager.Services;


namespace HotelManager.Controllers
{
    [ApiController]
    [Route("geo")]
    public class GeoController : Controller
    {
        private readonly IHotelRepository _repository;
        private readonly IGeoService _geoService;


        public GeoController(IHotelRepository repository, IGeoService geoService)
        {
            _repository = repository;
            _geoService = geoService;
        }

        // 11. Desenvolva o endpoint GET /geo/status
        [HttpGet]
        [Route("status")]
        public async Task<IActionResult> GetStatus()
        {
            var status = await _geoService.GetGeoStatus();
            if (status == default) return default!;
            return Ok(status);
        }

        // 12. Desenvolva o endpoint GET /geo/address
        [HttpGet]
        [Route("address")]
        public async Task<IActionResult> GetHotelsByLocation([FromBody] GeoDto address)
        {
            try
            {
                var hotelsList = await _geoService.GetHotelsByGeo(address, _repository);
                return Ok(hotelsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}