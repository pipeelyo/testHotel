using PruebaHotel.Application.Dto;

namespace PruebaHotel.Domain.Interface
{
    public interface IGuestService
    {
        Task<IEnumerable<GuestIDto>> GetAllByReservaAsync(int idReservation);
        Task<GuestIDto> GetByIdAsync(int id);
        Task<GuestIDto> CreateAsync(CreateGuestIDto GuestDto);
        Task DeleteAsync(int id);
        Task<GuestIDto> UpdateAsync(UpdateGuestIDto GuestDto);
    }
}
