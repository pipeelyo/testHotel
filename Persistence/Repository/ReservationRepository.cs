using Microsoft.EntityFrameworkCore;
using PruebaHotel.Domain.Entity;
using PruebaHotel.Domain.Repository;
using PruebaHotel.Persistence.DataAccess;

namespace PruebaHotel.Persistence.Repository
{
    public class ReservationRepository: IReservationRepository
    {
        private readonly MyContext _context;

        public ReservationRepository(MyContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Reservation>> GetReservationsByRoomAsync(int idRoom)
        {
            return await _context.Reservations
                .Where(r => r.IdRoom == idRoom)
                .Include(r => r.Room)
                .ThenInclude(h => h.Hotel)
                .ToListAsync();
        }


        public async Task<bool> ExistReservationByRoomAndDatesAsync(int idHabitacion, DateTime fechaEntrada, DateTime fechaSalida)
        {
            return await _context.Reservations.AnyAsync(r =>
                r.IdRoom == idHabitacion &&
                (r.EntryDate <= fechaEntrada && r.DepartureDate >= fechaEntrada) ||
                (r.EntryDate <= fechaSalida && r.DepartureDate >= fechaSalida));
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Reservations
                .Include(r => r.Room)
                .ThenInclude(h => h.Hotel)
                .FirstOrDefaultAsync(r => r.IdReservation == id);
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _context.Reservations
                .Include(r => r.Room)
                .ThenInclude(h => h.Hotel)
                .ToListAsync();
        }

        public async Task<Reservation> AddAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation = await GetByIdAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
