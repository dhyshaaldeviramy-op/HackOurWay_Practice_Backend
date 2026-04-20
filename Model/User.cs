using System.ComponentModel.DataAnnotations;
namespace HotelBooking.Model
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string Role { get; set; }
        //public ICollection<Booking> Bookings { get; set; }


    }
}
