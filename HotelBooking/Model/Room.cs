using System.ComponentModel.DataAnnotations;
namespace HotelBooking.Model
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Availability { get; set; }
        public Hotel Hotel { get; set; } 
        public ICollection<Booking> Bookings { get; set; }
    }
}
