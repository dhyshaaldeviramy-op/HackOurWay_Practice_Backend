using HotelBooking.Data;
using HotelBooking.DTO;
using HotelBooking.Model;
using HotelBooking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext _context;

        public PaymentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> ProcessPaymentAsync(PaymentDTO dto)
        {
            // 1) Validate booking
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.BookingId == dto.BookingId);

            if (booking == null)
                throw new Exception("Booking not found");

            // 2) ❗ Prevent duplicate payment
            var existingPayment = await _context.Payments
                .FirstOrDefaultAsync(p => p.BookingId == dto.BookingId);

            if (existingPayment != null)
                throw new Exception("Payment already completed for this booking");

            // 3) Create payment
            var payment = new Payment
            {
                BookingId = dto.BookingId,
                Amount = dto.Amount,
                Method = dto.Method,
                Status = "Paid"
            };

            _context.Payments.Add(payment);

            // 4) Update booking status
            booking.Status = "Paid";

            // 5) Save
            await _context.SaveChangesAsync();

            return "Payment Successful";
        }
    }
}