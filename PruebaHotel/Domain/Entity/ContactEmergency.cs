using PruebaHotel.Application.Dto;

namespace PruebaHotel.Domain.Entity
{
    public class ContactEmergency
    {
        public int IdContactEmergency { get; set; } // Clave primaria
        public int IdReservation { get; set; } // Clave foránea a la entidad Reservation
        public string FullName { get; set; } // Nombre completo del contacto de emergencia
        public string Phone { get; set; } // Teléfono del contacto de emergencia

        public Reservation Reservation { get; set; } // Relación uno a muchos con la entidad Reservation

        public ContactEmergencyIDto ToDto()
        {
            return new ContactEmergencyIDto
            {

                IdContactEmergency = IdContactEmergency,
                IdReservation = IdReservation,
                FullName = FullName,
                Phone = Phone
            };
        }
    }
}
