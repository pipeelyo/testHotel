using PruebaHotel.Application.Dto;
using PruebaHotel.Domain.Entity;
using PruebaHotel.Domain.Interface;
using PruebaHotel.Domain.Repository;
using PruebaHotel.Persistence.Repository;

namespace PruebaHotel.Application.Service
{
    public class ReservationService: IReservationService  
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationService(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<ReservationIDto> CreateAsync(CreateReservationIDto reservationDto)
        {
            var reservation = new Reservation
            {
                IdRoom = reservationDto.IdRoom,
                EntryDate = reservationDto.EntryDate,
                DepartureDate = reservationDto.DepartureDate,
                QuantityPersons = reservationDto.QuantityPersons,
                Total = reservationDto.Total,
                Status= reservationDto.Status,
            };

            await _reservationRepository.AddAsync(reservation);

            return reservation.ToDto();
        }

        public async Task DeleteAsync(int id)
        {
            if (id != null)
            {
                await _reservationRepository.DeleteAsync(id);
            }
        }

        public async Task<IEnumerable<ReservationIDto>> GetAllByHabitacionAsync(int idHabitacion)
        {
            var reservations = await _reservationRepository.GetReservationsByRoomAsync(idHabitacion);
            return reservations.Select(reservation => reservation.ToDto());
        }

        public async Task<ReservationIDto> GetByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            return reservation?.ToDto();
        }

        public async Task<ReservationIDto> UpdateAsync(UpdateReservationIDto reservationDto) {
        
            var reservation= await _reservationRepository.GetByIdAsync(reservationDto.IdReservation);

            if (reservation == null)
                return null;

            reservation.IdRoom = reservationDto.IdRoom;
            reservation.EntryDate = reservationDto.EntryDate;
            reservation.DepartureDate = reservationDto.DepartureDate;
            reservation.QuantityPersons = reservationDto.QuantityPersons;
            reservation.Total = reservationDto.Total;
            reservation.Status = reservationDto.Status;

            await _reservationRepository.UpdateAsync(reservation);

            return reservation.ToDto();
        }
    }
}
