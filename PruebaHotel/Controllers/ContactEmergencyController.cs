using Microsoft.AspNetCore.Mvc;
using PruebaHotel.Application.Dto;
using PruebaHotel.Application.Service;
using PruebaHotel.Domain.Entity;
using PruebaHotel.Domain.Interface;

namespace PruebaHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactEmergencyController : Controller
    {
        private readonly contactEmergencyService _contactEmergencyService;

        public ContactEmergencyController(contactEmergencyService contactEmergencyService)
        {
            _contactEmergencyService = contactEmergencyService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getContactEmergencybyReservation(int id)
        {
            var guest = await _contactEmergencyService.GetByReservaAsync(id);
            if (guest == null) return NotFound();
            return Ok(guest);
        }

        [HttpPost]
        public async Task<IActionResult> createContactEmergency(CreateContactEmergencyIDto ContactEmergencyDto)
        {
            var guest = await _contactEmergencyService.CreateAsync(ContactEmergencyDto);
            if (guest == null) return NotFound();
            return Ok(guest);
        }

        [HttpPut]
        public async Task<IActionResult> updateContactEmergency(UpdateContactEmergencyIDto ContactEmergencyDto)
        {
            var guest = await _contactEmergencyService.UpdateAsync(ContactEmergencyDto);
            if (guest == null) return NotFound();
            return Ok(guest);
        }
    }
}
