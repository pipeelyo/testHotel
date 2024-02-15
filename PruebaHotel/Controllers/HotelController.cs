using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaHotel.Application.Dto;
using PruebaHotel.Application.Service;

namespace PruebaHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
       private readonly HotelService  _hotelService;
       public HotelController(HotelService hotelService)
       {
            _hotelService = hotelService;
       }
       
        [HttpGet]
        public async Task<IActionResult> getHotels()
        {
            try
            {
                var hotels = await _hotelService.GetAllAsync();
                return Ok(hotels);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> getHotel(int id)
        {
            try
            {
                var hotel = await _hotelService.GetByIdAsync(id);
                if(hotel == null)
                    return NotFound();
                return Ok(hotel);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> createHotel(CreateHotelDto hotelDto)
        {
            try
            {
                var hotel = await _hotelService.CreateAsync(hotelDto);
                if(hotel == null) return NotFound();
                return Ok(hotel);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> updateHotel(UpdateHotelDto hotelDto)
        {
            try
            {
                var hotel = _hotelService.UpdateAsync(hotelDto);
                if(hotel == null) return NotFound();
                return Ok(hotel);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                await _hotelService.DeleteAsync(id);
                return NoContent();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
