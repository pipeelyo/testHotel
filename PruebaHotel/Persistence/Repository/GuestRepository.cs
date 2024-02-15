using Microsoft.EntityFrameworkCore;
using PruebaHotel.Domain.Entity;
using PruebaHotel.Domain.Repository;
using PruebaHotel.Persistence.DataAccess;

namespace PruebaHotel.Persistence.Repository
{
    public class GuestRepository: IGuestRepository
    {
        private readonly MyContext _context;

        public GuestRepository(MyContext context)
        {
            _context = context;
        }
        public async Task<List<Guest>> GetAllAsync()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<Guest?> GetByIdAsync(int idGuest)
        {
            return await _context.Guests.FindAsync(idGuest);
        }

        public async Task<Guest> AddAsync(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return guest;
        }

        public async Task UpdateAsync(Guest guest)
        {
            _context.Guests.Update(guest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int idGuest)
        {
            var guest = await GetByIdAsync(idGuest);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                await _context.SaveChangesAsync();
            }
        }
    }
}
