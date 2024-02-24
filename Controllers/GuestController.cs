using Microsoft.AspNetCore.Mvc;
using PruebaHotel.Application.Dto;
using PruebaHotel.Application.Service;

namespace PruebaHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly GuestService _guestService;
        public GuestController(GuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet("/byReservation/{id}")]
        public async Task<IActionResult> getGuestbyReservation(int id)
        {
            var guest = await _guestService.GetAllByReservaAsync(id);
            if (guest == null) return NotFound();
            return Ok(guest);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getGuestbyid(int id)
        {
            var guest = await _guestService.GetByIdAsync(id);
            if (guest == null) return NotFound();
            return Ok(guest);
        }

        [HttpPost]
        public async Task<IActionResult> createGuest(CreateGuestIDto guestDto)
        {
            var guest = await _guestService.CreateAsync(guestDto);
            if (guest == null) return NotFound();
            return Ok(guest);
        }

        [HttpPut]
        public async Task<IActionResult> updateGuest(UpdateGuestIDto guestDto)
        {
            var guest = await _guestService.UpdateAsync(guestDto);
            if (guest == null) return NotFound();
            return Ok(guest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            await _guestService.DeleteAsync(id);
            return Ok();
        }
    }
}
