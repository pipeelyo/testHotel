using PruebaHotel.Application.Dto;
using PruebaHotel.Domain.Entity;
using PruebaHotel.Domain.Interface;
using PruebaHotel.Persistence.Repository;

namespace PruebaHotel.Application.Service
{
    public class contactEmergencyService : IContactEmergencyService
    {
        private readonly ContactEmergencyRepository _contactEmergencyRepository;

        public contactEmergencyService(ContactEmergencyRepository contactEmergencyRepository)
        {
            _contactEmergencyRepository = contactEmergencyRepository;
        }
        public async Task<ContactEmergencyIDto> CreateAsync(CreateContactEmergencyIDto contactEmergencyDto)
        {
            var contactEmergency = new ContactEmergency
            {
                IdReservation = contactEmergencyDto.IdReservation,
                FullName = contactEmergencyDto.FullName,
                Phone = contactEmergencyDto.Phone,
            };
            await _contactEmergencyRepository.AddAsync(contactEmergency);
            return contactEmergency.ToDto();
        }

        public async Task<ContactEmergencyIDto> GetByReservaAsync(int idReserva)
        {
            var contactEmergencies = await _contactEmergencyRepository.GetAllAsync();
            return (ContactEmergencyIDto)contactEmergencies.Select(x => x.ToDto());
        }

        public async Task<ContactEmergencyIDto> UpdateAsync(UpdateContactEmergencyIDto contactEmergencyDto)
        {
            var contacEmergency = await _contactEmergencyRepository.GetByIdAsync(contactEmergencyDto.IdReservation);
            if (contacEmergency != null) 
                return null;
            
            contacEmergency.IdReservation = contactEmergencyDto.IdReservation;
            contacEmergency.FullName = contactEmergencyDto.FullName;
            contacEmergency.Phone = contactEmergencyDto.Phone;

            return contacEmergency.ToDto();
        }
    }
}
