using Microsoft.EntityFrameworkCore;
using PruebaHotel.Domain.Entity;

namespace PruebaHotel.Persistence.DataAccess
{
    public class MyContext: DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<ContactEmergency> contactEmergencies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=hotel;User Id=postgres;Password=0000");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ... other service registrations

            services.AddDbContext<MyContext>(options =>
            {
                options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=hotel;User Id=postgres;Password=0000");
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones generales
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(true);

                entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(true);

                entity.Property(e => e.Enabled)
                    .HasDefaultValue(true);

                entity.HasMany(e => e.Rooms)
                    .WithOne(r => r.Hotel)
                    .HasForeignKey(r => r.IdHotel);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                // Tabla y clave primaria
                entity.ToTable("Room", "public");
                entity.HasKey(e => e.IdRoom);

                // Propiedades con configuraciones
                entity.Property(e => e.IdRoom)
                    .HasColumnName("IdRoom") // PostgreSQL columna en minúsculas
                    .ValueGeneratedOnAdd(); // Auto-incremento

                entity.Property(e => e.IdHotel)
                    .IsRequired()
                    .HasColumnName("IdHotel");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Type");

                entity.Property(e => e.CostBase)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired()
                    .HasColumnName("CostBase");

                entity.Property(e => e.Tax)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired()
                    .HasColumnName("Tax");

                entity.Property(e => e.LocationInHotel)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("LocationInHotel");

                entity.Property(e => e.Enabled)
                    .HasDefaultValue(true)
                    .HasColumnName("Enabled");

                // Relación con Hotel (uno a muchos)
                entity.HasOne(e => e.Hotel)
                    .WithMany(h => h.Rooms)
                    .HasForeignKey(e => e.IdHotel)
                    .HasConstraintName("fk_room_hotel"); // Nombre de la restricción de clave externa

                // Índices (opcional)
                entity.HasIndex(e => e.IdHotel); 
            });
            
            modelBuilder.Entity<Reservation>(entity =>
            {
                // Tabla y clave primaria
                entity.ToTable("Reservation", "public");
                entity.HasKey(e => e.IdReservation);

                // Propiedades con configuraciones
                entity.Property(e => e.IdReservation)
                    .HasColumnName("IdReservation")
                    .ValueGeneratedOnAdd(); // Auto-incremento

                entity.Property(e => e.IdRoom)
                    .IsRequired()
                    .HasColumnName("IdRoom");

                entity.Property(e => e.EntryDate)
                    .IsRequired()
                    .HasColumnName("EntryDate")
                    .HasColumnType("date");

                entity.Property(e => e.DepartureDate)
                    .IsRequired()
                    .HasColumnName("DepartureDate")
                    .HasColumnType("date");

                entity.Property(e => e.QuantityPersons)
                    .IsRequired()
                    .HasColumnName("QuantityPersons");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired()
                    .HasColumnName("Total");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Status");

                // Relación con Room (uno a muchos)
                entity.HasOne(e => e.Room)
                    .WithMany(r => r.Reservations)
                    .HasForeignKey(e => e.IdRoom)
                    .HasConstraintName("fk_reservation_room"); // Nombre de la restricción de clave externa

                // Índices (opcional)
                entity.HasIndex(e => e.IdRoom); // Puedes agregar índices según tus necesidades
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                // Tabla y clave primaria
                entity.ToTable("Guest", "public");
                entity.HasKey(e => e.IdGuest);

                // Propiedades con configuraciones
                entity.Property(e => e.IdGuest)
                    .HasColumnName("IdGuest")
                    .ValueGeneratedOnAdd(); // Auto-incremento

                entity.Property(e => e.IdReservation)
                    .IsRequired()
                    .HasColumnName("IdReservation");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("FullName");

                entity.Property(e => e.DateBirth)
                    .IsRequired()
                    .HasColumnName("DateBirth")
                    .HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Gender");

                entity.Property(e => e.DocumentType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("DocumentType");

                entity.Property(e => e.DocumentNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("DocumentNumber");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Email");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Phone");

                // Relación con Reservation (uno a muchos)
                entity.HasOne(e => e.Reservation)
                    .WithMany(r => r.Guests)
                    .HasForeignKey(e => e.IdReservation)
                    .HasConstraintName("fk_guest_reservation"); // Nombre de la restricción de clave externa

                // Índices (opcional)
                entity.HasIndex(e => e.IdReservation); // Puedes agregar índices según tus necesidades
            });

            modelBuilder.Entity<ContactEmergency>(entity =>
            {
                // Tabla y clave primaria
                entity.ToTable("ContactEmergency", "public");
                entity.HasKey(e => e.IdContactEmergency);

                // Propiedades con configuraciones
                entity.Property(e => e.IdContactEmergency)
                    .HasColumnName("IdContactEmergency")
                    .ValueGeneratedOnAdd(); // Auto-incremento

                entity.Property(e => e.IdReservation)
                    .IsRequired()
                    .HasColumnName("IdReservation");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("FullName");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Phone");

                // Relación con Reservation (uno a muchos)
                entity.HasOne(e => e.Reservation)
                    .WithMany(r => r.ContactEmergencies)
                    .HasForeignKey(e => e.IdReservation)
                    .HasConstraintName("fk_contact_emergency_reservation"); // Nombre de la restricción de clave externa

                // Índices (opcional)
                entity.HasIndex(e => e.IdReservation); // Puedes agregar índices según tus necesidades
            });
        }
    }
}
