namespace PruebaHotel.Application.Dto
{
    public class HotelDto
    {
        public int IdHotel { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
    }

    public class CreateHotelDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }

    public class UpdateHotelDto
    {
        public int IdHotel { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
    }
}
