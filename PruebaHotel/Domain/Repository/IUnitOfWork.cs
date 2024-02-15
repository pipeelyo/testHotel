namespace PruebaHotel.Domain.Repository
{
    public interface IUnitOfWork
    {
        IHotelRepository HotelRepository { get; }

        IRoomRepository RoomRepository { get; }

        IReservationRepository ReservationRepository { get; }

        IGuestRepository GuestRepository { get; }

        IContactEmergencyRepository ContactEmergencyRepository { get; }

        Task SaveChangesAsync();
    }
}
