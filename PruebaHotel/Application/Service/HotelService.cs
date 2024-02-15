using PruebaHotel.Application.Dto;
using PruebaHotel.Domain.Entity;
using PruebaHotel.Domain.Interface;
using PruebaHotel.Persistence.Repository;

namespace PruebaHotel.Application.Service
{
    public class HotelService : IHotelService
    {
        private readonly HotelRepository _hotelRepository;

        public HotelService(HotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<HotelDto> CreateAsync(CreateHotelDto hotelDto)
        {   
            var hotel = new Hotel
            {
                Name = hotelDto.Name,
                Location = hotelDto.Location,
                Description = hotelDto.Description,
                Enabled = true
            };

            await _hotelRepository.AddAsync(hotel);

            return hotel.ToDto();
        }

        public async Task DeleteAsync(int id)
        {
            if (id != null)
            {
                await _hotelRepository.DeleteAsync(id);
            }
        }

        public async Task<IEnumerable<HotelDto>> GetAllAsync()
        {
            var hotels = await _hotelRepository.GetAllAsync();
            return hotels.Select(x => x.ToDto());
        }

        public async Task<HotelDto> GetByIdAsync(int id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);
            return hotel?.ToDto();
        }

        public async Task<HotelDto> UpdateAsync(UpdateHotelDto hotelDto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(hotelDto.IdHotel);

            if (hotel == null)
                return null;

            hotel.Name = hotelDto.Name;
            hotel.Location = hotelDto.Location;
            hotel.Description = hotelDto.Description;
            hotel.Enabled = hotelDto.Enabled;

            await _hotelRepository.UpdateAsync(hotel);

            return hotel.ToDto();
        }
    }
}
