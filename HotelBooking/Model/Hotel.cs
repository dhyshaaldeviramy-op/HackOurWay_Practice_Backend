using System.ComponentModel.DataAnnotations;
namespace HotelBooking.Model
{
    public class Hotel
    {
        [Key]
        public int hotelId { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
