using Microsoft.EntityFrameworkCore;
using PruebaHotel.Domain.Entity;
using PruebaHotel.Domain.Repository;
using PruebaHotel.Persistence.DataAccess;

namespace PruebaHotel.Persistence.Repository
{
    public class ContactEmergencyRepository: IContactEmergencyRepository
    {

        private readonly MyContext _context;

        public ContactEmergencyRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<List<ContactEmergency>> GetAllAsync()
        {
            return await _context.contactEmergencies
            .Include(ce => ce.Reservation)
            .ToListAsync();
        }

        public async Task<IEnumerable<ContactEmergency>> GetByReservaAsync(int idReserva)
        {
            return await _context.contactEmergencies
                .Where(ce => ce.IdReservation == idReserva)
                .Include(ce => ce.Reservation)
            .ToListAsync();
        }

        public async Task<ContactEmergency?> GetByIdAsync(int idContactEmergency)
        {
            return await _context.contactEmergencies
                .Include(ce => ce.Reservation)
                .FirstOrDefaultAsync(ce => ce.IdContactEmergency == idContactEmergency);
        }

        public async Task<ContactEmergency> AddAsync(ContactEmergency contactEmergency)
        {
            _context.contactEmergencies.Add(contactEmergency);
            await _context.SaveChangesAsync();
            return contactEmergency;
        }

        public async Task UpdateAsync(ContactEmergency contactEmergency)
        {
            _context.contactEmergencies.Update(contactEmergency);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int idContactEmergency)
        {
            var contactEmergency = await GetByIdAsync(idContactEmergency);
            if (contactEmergency != null)
            {
                _context.contactEmergencies.Remove(contactEmergency);
                await _context.SaveChangesAsync();
            }
        }

    }
}
