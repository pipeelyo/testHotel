namespace PruebaHotel.Application.Dto
{
    public class ReservationIDto
    {
        public int IdReservation { get; set; } 
        public int IdRoom { get; set; } 
        public DateTime EntryDate { get; set; }
        public DateTime DateDeparture { get; set; }
        public int QuantityPersons { get; set; } 
        public decimal Total { get; set; }
        public string Status { get; set; }
    }

    public class CreateReservationIDto
    {
        public int IdRoom { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DateDeparture { get; set; }
        public int QuantityPersons { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
    }

    public class UpdateReservationIDto
    {
        public int IdReservation { get; set; }
        public int IdRoom { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DateDeparture { get; set; }
        public int QuantityPersons { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
    }
}
