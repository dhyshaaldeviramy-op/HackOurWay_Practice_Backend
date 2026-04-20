namespace HotelBooking.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
    }
}
