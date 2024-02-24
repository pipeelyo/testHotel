using PruebaHotel.Application.Dto;

namespace PruebaHotel.Domain.Interface
{
    public interface IContactEmergencyService
    {
        Task<ContactEmergencyIDto> GetByReservaAsync(int idReserva);
        Task<ContactEmergencyIDto> CreateAsync(CreateContactEmergencyIDto contactoEmergenciaDto);
        Task<ContactEmergencyIDto> UpdateAsync(UpdateContactEmergencyIDto contactoEmergenciaDto);
    }
}
