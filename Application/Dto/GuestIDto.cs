namespace PruebaHotel.Application.Dto
{
    public class GuestIDto
    {
        public int IdGuest { get; set; }
        public int IdReservation { get; set; }
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class CreateGuestIDto
    {
        public int IdReservation { get; set; }
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class UpdateGuestIDto
    {
        public int IdGuest { get; set; }
        public int IdReservation { get; set; }
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
