namespace PruebaHotel.Application.Dto
{
    public class RoomIDto
    {
        public int IdRoom { get; set; }
        public int IdHotel { get; set; }
        public string Type { get; set; }
        public decimal CostBase { get; set; }
        public decimal Tax { get; set; }
        public string LocationInHotel { get; set; }
        public bool Enabled { get; set; } = true;
    }

    public class CreateRoomIDto
    {
        public int IdHotel { get; set; }
        public string Type { get; set; }
        public decimal CostBase { get; set; }
        public decimal Tax { get; set; }
        public string LocationInHotel { get; set; }
        public bool Enabled { get; set; } = true;
    }

    public class UpdateRoomIDto
    {
        public int IdRoom { get; set; }
        public int IdHotel { get; set; }
        public string Type { get; set; }
        public decimal CostBase { get; set; }
        public decimal Tax { get; set; }
        public string LocationInHotel { get; set; }
        public bool Enabled { get; set; } = true;
    }
}
