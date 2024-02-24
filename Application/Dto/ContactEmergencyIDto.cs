namespace PruebaHotel.Application.Dto
{
    public class ContactEmergencyIDto
    {
        public int IdContactEmergency { get; set; }
        public int IdReservation { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }

    public class CreateContactEmergencyIDto
    {
        public int IdReservation { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }

    public class UpdateContactEmergencyIDto
    {
        public int IdContactEmergency { get; set; }
        public int IdReservation { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }
}
