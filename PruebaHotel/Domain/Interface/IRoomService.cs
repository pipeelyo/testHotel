using PruebaHotel.Application.Dto;

namespace PruebaHotel.Domain.Interface
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomIDto>> GetAllByHotelAsync(int idHotel);
        Task<RoomIDto> GetByIdAsync(int id);
        Task<RoomIDto> CreateAsync(CreateRoomIDto habitacionDto);
        Task<RoomIDto> UpdateAsync(UpdateRoomIDto habitacionDto);
        Task DeleteAsync(int id);
    }
}
