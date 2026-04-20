using System.ComponentModel.DataAnnotations;
namespace HotelBooking.Model
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
        public Room Room { get; set; }
        public Payment Payment { get; set; }
    }
}
