using PruebaHotel.Application.Dto;
using PruebaHotel.Domain.Entity;
using PruebaHotel.Domain.Interface;
using PruebaHotel.Domain.Repository;
using PruebaHotel.Persistence.Repository;

namespace PruebaHotel.Application.Service
{
    public class RoomService: IRoomService  
    {
        private readonly RoomRepository _roomRepository;

        public RoomService(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<RoomIDto> CreateAsync(CreateRoomIDto roomDto)
        {
            var room = new Room
            {
                IdHotel = roomDto.IdHotel,
                Type = roomDto.Type,
                CostBase = roomDto.CostBase,
                Tax = roomDto.Tax,
                LocationInHotel = roomDto.LocationInHotel,
                Enabled = true
            };

            await _roomRepository.AddAsync(room);

            return room.ToDto();
        }

        public async Task DeleteAsync(int id)
        {
            if (id != null)
            {
                await _roomRepository.DeleteAsync(id);
            }
        }

        public async Task<IEnumerable<RoomIDto>> GetAllByHotelAsync(int idHotel)
        {
            var rooms = await _roomRepository.GetRoomsByHotelAsync(idHotel);
            return rooms.Select(room => room.ToDto());
        }

        public async Task<RoomIDto> GetByIdAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            return room?.ToDto();
        }

        public async Task<RoomIDto> UpdateAsync(UpdateRoomIDto roomDto)
        {
            var room = await _roomRepository.GetByIdAsync(roomDto.IdRoom);

            if (room == null)
                return null;

            room.Type = roomDto.Type;
            room.CostBase = roomDto.CostBase;
            room.Tax = roomDto.Tax;
            room.LocationInHotel = roomDto.LocationInHotel;
            room.Enabled = roomDto.Enabled;

            await _roomRepository.UpdateAsync(room);

            return room.ToDto();
        }
    }
}
