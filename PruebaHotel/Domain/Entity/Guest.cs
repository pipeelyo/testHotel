using PruebaHotel.Application.Dto;
using System.ComponentModel.DataAnnotations;

namespace PruebaHotel.Domain.Entity
{
    public class Guest
    {
        [Key]
        public int IdGuest { get; set; } // Clave primaria
        public int IdReservation { get; set; } // Clave foránea a la entidad Reservation
        public string FullName { get; set; } // Nombre completo del huésped
        public DateTime DateBirth { get; set; } // Fecha de nacimiento del huésped
        public string Gender { get; set; } // Género del huésped
        public string DocumentType { get; set; } // Tipo de documento del huésped
        public string DocumentNumber { get; set; } // Número de documento del huésped
        public string Email { get; set; } // Correo electrónico del huésped
        public string Phone { get; set; } // Teléfono del huésped

        public Reservation Reservation { get; set; } // Relación uno a muchos con la entidad Reservation

        public GuestIDto ToDto()
        {
            return new GuestIDto
            {
                IdGuest = IdGuest,
                IdReservation = IdReservation,
                FullName = FullName,
                DateBirth = DateBirth,
                Gender = Gender,
                DocumentType = DocumentType,
                DocumentNumber = DocumentNumber,
                Email = Email, 
                Phone = Phone
            };
        }
    }
}
