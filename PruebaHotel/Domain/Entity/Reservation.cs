using PruebaHotel.Application.Dto;

namespace PruebaHotel.Domain.Entity
{
    public class Reservation
    {
        public int IdReservation { get; set; } // Clave primaria
        public int IdRoom { get; set; } // Clave foránea a la entidad Room
        public DateTime EntryDate { get; set; } // Fecha de entrada
        public DateTime DateDeparture { get; set; } // Fecha de salida
        public int QuantityPersons { get; set; } // Cantidad de personas en la reserva
        public decimal Total { get; set; } // Precio total de la reserva
        public string Status { get; set; } // Estado de la reserva (pendiente, confirmada, cancelada)

        public Room Room { get; set; } // Relación uno a muchos con la entidad Room
        public ICollection<Guest> Guests { get; set; } // Relación uno a muchos con las entidades Guest
        public ICollection<ContactEmergency> ContactEmergencies { get; set; } // Relación uno a muchos con las entidades ContactEmergency
        public ReservationIDto ToDto()
        {
            return new ReservationIDto
            {
                IdReservation = IdReservation,
                IdRoom = IdRoom,
                EntryDate = EntryDate,
                DateDeparture = DateDeparture,
                QuantityPersons = QuantityPersons,
                Total = Total,
                Status = Status
            };
        }
    }
}
