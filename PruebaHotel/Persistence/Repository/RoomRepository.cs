using Microsoft.EntityFrameworkCore;
using PruebaHotel.Domain.Entity;
using PruebaHotel.Domain.Repository;
using PruebaHotel.Persistence.DataAccess;

namespace PruebaHotel.Persistence.Repository
{
    public class RoomRepository: IRoomRepository
    {
        private readonly MyContext _context;

        public RoomRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetRoomsByHotelAsync(int id)
        {
            return await _context.Rooms.Where(h => h.IdHotel == id).Include(h => h.Hotel).ToListAsync();
        }

        public async Task<Room> AddAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task DeleteAsync(int id)
        {
            var habitación = await GetByIdAsync(id);
            if (habitación != null)
            {
                _context.Rooms.Remove(habitación);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
