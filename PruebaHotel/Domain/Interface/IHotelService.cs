using PruebaHotel.Application.Dto;

namespace PruebaHotel.Domain.Interface
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelDto>> GetAllAsync();
        Task<HotelDto> GetByIdAsync(int id);
        Task<HotelDto> CreateAsync(CreateHotelDto hotelDto);
        Task<HotelDto> UpdateAsync(UpdateHotelDto hotelDto);
        Task DeleteAsync(int id);
    }
}
