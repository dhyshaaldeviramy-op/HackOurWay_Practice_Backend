using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Model
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
        public string Method { get; set; }
        public Booking Booking { get; set; }
    }
}
