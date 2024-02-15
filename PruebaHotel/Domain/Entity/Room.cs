using PruebaHotel.Application.Dto;

namespace PruebaHotel.Domain.Entity
{
    public class Room
    {
            public int IdRoom { get; set; } // Clave primaria
            public int IdHotel { get; set; } // Clave foránea a la entidad Hotel
            public string Type { get; set; } // Tipo de habitación (individual, doble, etc.)
            public decimal CostBase { get; set; } // Precio base de la habitación
            public decimal Tax { get; set; } // Impuesto aplicado a la habitación
            public string LocationInHotel { get; set; } // Ubicación de la habitación dentro del hotel
            public bool Enabled { get; set; } = true; // Indica si la habitación está disponible

            public Hotel Hotel { get; set; } // Relación uno a muchos con la entidad Hotel

            public ICollection<Reservation> Reservations { get; set; }

            public RoomIDto ToDto()
            {
                return new RoomIDto
                {
                    IdRoom = IdRoom,
                    IdHotel = IdHotel,
                    Type = Type,
                    CostBase = CostBase,
                    Tax = Tax,
                    LocationInHotel = LocationInHotel,
                    Enabled = Enabled
                };
            }
    }
}
