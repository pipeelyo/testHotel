using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using PruebaHotel.Application.Dto;
using PruebaHotel.Application.Service;

namespace PruebaHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;
        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("/byRoom/{id}")]
        public async Task<IActionResult> getReservationByRoom(int id)
        {
            var reservations = _reservationService.GetAllByHabitacionAsync(id);
            if (reservations == null) return NotFound();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getReservationByid(int id)
        {
            var reservation = _reservationService.GetByIdAsync(id);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> createReservation(CreateReservationIDto createReservationIDto)
        {
            var reservation = _reservationService.CreateAsync(createReservationIDto);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        [HttpPut]
        public async Task<IActionResult> updateReservation(UpdateReservationIDto updateReservationIDto)
        {
            var reservation = _reservationService.UpdateAsync(updateReservationIDto);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteReservation(int id)
        {
            var reservation = _reservationService.DeleteAsync(id);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }
    }
}
