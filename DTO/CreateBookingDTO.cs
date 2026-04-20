namespace HotelBooking.DTO
{
    public class CreateBookingDTO
    {
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
