using PruebaHotel.Application.Dto;

namespace PruebaHotel.Domain.Interface
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationIDto>> GetAllByHabitacionAsync(int idHabitacion);
        Task<ReservationIDto> GetByIdAsync(int id);
        Task<ReservationIDto> CreateAsync(CreateReservationIDto reservaDto);
        Task<ReservationIDto> UpdateAsync(UpdateReservationIDto reservaDto);
        Task DeleteAsync(int id);
    }
}
