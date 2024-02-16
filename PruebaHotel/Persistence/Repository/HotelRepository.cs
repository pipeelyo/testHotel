using Microsoft.EntityFrameworkCore;
using PruebaHotel.Domain.Entity;
using PruebaHotel.Domain.Repository;
using PruebaHotel.Persistence.DataAccess;

namespace PruebaHotel.Persistence.Repository
{
    public class HotelRepository: IHotelRepository
    {
        private readonly MyContext _context;

        public HotelRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<Hotel> AddAsync(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task DeleteAsync(int id)
        {
            var hotel = await GetByIdAsync(id);
            if (hotel != null) {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Hotel>> GetAllAsync()
        {
            using (var context = new MyContext())
            {
                // Consulta LINQ para obtener todos los hoteles
                var hotels = await context.Hotels.ToListAsync();

                // Retorna la lista de hoteles
                return hotels;
            }
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async Task UpdateAsync(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
