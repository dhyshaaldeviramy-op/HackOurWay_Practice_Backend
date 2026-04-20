namespace HotelBooking.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }

        public int Availability { get; set; } 
    }
}
