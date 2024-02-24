using PruebaHotel.Application.Dto;
using PruebaHotel.Domain.Entity;
using PruebaHotel.Domain.Interface;
using PruebaHotel.Domain.Repository;
using PruebaHotel.Persistence.Repository;

namespace PruebaHotel.Application.Service
{
    public class GuestService : IGuestService
    {
        private readonly GuestRepository _Guestrepository;
        public GuestService(GuestRepository repository) {
            _Guestrepository = repository;
        }
        public async Task<GuestIDto> CreateAsync(CreateGuestIDto guestDto)
        {
            var guest = new Guest
            {
                IdReservation = guestDto.IdReservation,
                FullName = guestDto.FullName,
                DateBirth = guestDto.DateBirth,
                Gender = guestDto.Gender,
                DocumentType  = guestDto.DocumentType,
                DocumentNumber = guestDto.DocumentNumber,
                Email = guestDto.Email,
                Phone = guestDto.Phone,
            };
            await _Guestrepository.AddAsync(guest);

            return guest.ToDto();
        }

        public async Task DeleteAsync(int id)
        {
           if(id != null) {
              await _Guestrepository.DeleteAsync(id);
           }
        }

        public async Task<IEnumerable<GuestIDto>> GetAllByReservaAsync(int idReservation)
        {
            var Guests = await _Guestrepository.GetAllAsync();
            return Guests.Select(x => x.ToDto());
        }

        public async Task<GuestIDto> GetByIdAsync(int id)
        {
            var repository = await _Guestrepository.GetByIdAsync(id);
            return repository?.ToDto();
        }

        public async Task<GuestIDto> UpdateAsync(UpdateGuestIDto GuestDto)
        {
            var guest = await _Guestrepository.GetByIdAsync(GuestDto.IdGuest);

            if (guest == null)
                return null;

            guest.IdReservation = GuestDto.IdReservation;
            guest.FullName = GuestDto.FullName;
            guest.DateBirth = GuestDto.DateBirth;
            guest.Gender = GuestDto.Gender;
            guest.DocumentType = GuestDto.DocumentType;
            guest.DocumentNumber = GuestDto.DocumentNumber;
            guest.Email = GuestDto.Email;
            guest.Phone = GuestDto.Phone;

            await _Guestrepository.UpdateAsync(guest);

            return guest.ToDto();
        }
    }
}
