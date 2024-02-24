using Microsoft.EntityFrameworkCore;
using PruebaHotel.Domain.Repository;
using PruebaHotel.Persistence.DataAccess;
using PruebaHotel.Persistence.Repository;
using System;

namespace PruebaHotel.Domain.WorkUnits
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;

        public UnitOfWork(MyContext context) 
        {
            _context = context;
            HotelRepository = new HotelRepository(_context);
            RoomRepository = new RoomRepository(_context);
            ReservationRepository = new ReservationRepository(_context);
            GuestRepository = new GuestRepository(_context);
            ContactEmergencyRepository = new ContactEmergencyRepository(_context);
        }

        public IHotelRepository HotelRepository { get; }

        public IRoomRepository RoomRepository { get; }

        public IReservationRepository ReservationRepository { get; }

        public IGuestRepository GuestRepository { get; }

        public IContactEmergencyRepository ContactEmergencyRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
