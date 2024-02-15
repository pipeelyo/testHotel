using PruebaHotel.Application.Dto;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PruebaHotel.Domain.Entity
{
    public class Hotel
    {
        [Key]
        public int IdHotel { get; set; } // Clave primaria
        public string Name { get; set; } // Nombre del hotel
        public string Location { get; set; } // Ubicación del hotel
        public string? Description { get; set; } // Descripción del hotel (opcional)
        public bool Enabled { get; set; } = true; // Indica si el hotel está activo

        public ICollection<Room> Rooms { get; set; } // Relación uno a muchos con las habitaciones

        public HotelDto ToDto()
        {
            return new HotelDto
            {
                IdHotel = IdHotel,
                Name = Name,
                Location = Location,
                Description = Description,
                Enabled = Enabled
            };
        }
    }
}
