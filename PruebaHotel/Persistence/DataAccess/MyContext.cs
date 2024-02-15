using Microsoft.EntityFrameworkCore;
using PruebaHotel.Domain.Entity;

namespace PruebaHotel.Persistence.DataAccess
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options): base(options) 
        { 
        }
        
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<ContactEmergency> contactEmergencies { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relaciones entre entidades
            modelBuilder.Entity<Room>()
                .HasOne(h => h.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(h => h.IdHotel)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.IdReservation)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Guest>()
                .HasOne(p => p.Reservation)
                .WithMany(p => p.Guests)
                .HasForeignKey(p => p.IdReservation)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ContactEmergency>()
                .HasOne(c => c.Reservation)
                .WithMany(c => c.ContactEmergencies)
                .HasForeignKey(c => c.IdReservation)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuraciones de entidades

            // Hotel
            modelBuilder.Entity<Hotel>()
                .Property(h => h.Name)
                .HasColumnName("Name")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Hotel>()
                .HasIndex(h => h.Name);

            // Habitación
            modelBuilder.Entity<Room>()
                .Property(h => h.Type)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Room>()
                .HasIndex(h => h.Type);

            // Reserva
            modelBuilder.Entity<Reservation>()
                .Property(r => r.EntryDate)
                .IsRequired();

            modelBuilder.Entity<Reservation>()
                .Property(r => r.DateDeparture)
                .IsRequired();

            modelBuilder.Entity<Reservation>()
                .Property(r => r.QuantityPersons)
                .IsRequired();

            modelBuilder.Entity<Reservation>()
                .Property(r => r.Status)
                .HasMaxLength(50)
                .IsRequired();

            // Pasajero
            modelBuilder.Entity<Guest>()
                .Property(p => p.FullName)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Guest>()
                .Property(p => p.DateBirth)
                .IsRequired();

            modelBuilder.Entity<Guest>()
                .Property(p => p.Gender)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Guest>()
                .Property(p => p.DocumentType)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Guest>()
                .Property(p => p.DocumentNumber)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Guest>()
                .HasIndex(p => new { p.DocumentType, p.DocumentNumber });

            // Contacto de Emergencia
            modelBuilder.Entity<ContactEmergency>()
                .Property(c => c.FullName)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<ContactEmergency>()
                .Property(c => c.Phone)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
