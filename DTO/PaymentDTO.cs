namespace HotelBooking.DTO
{
    public class PaymentDTO
    {
        public int BookingId { get; set; }
        public int Amount { get; set; }
        public string Method { get; set; }
    }
}
