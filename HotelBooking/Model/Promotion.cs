using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Model
{
    public class Promotion
    {
        [Key]
        public int PromotionId { get; set; }
        public string Code { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
