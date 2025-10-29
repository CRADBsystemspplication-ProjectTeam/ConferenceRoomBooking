using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Enum;
using ConferenceRoomBooking.Interfaces.IRepositories;
using ConferenceRoomBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Repositories
{
    public class BookingCheckInRepository : BaseRepository<BookingCheckIn>, IBookingCheckInRepository
    {
        public BookingCheckInRepository(ConferenceRoomBookingDbContext context) : base(context) { }

        public async Task<BookingCheckIn> CheckInAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null) throw new ArgumentException("Booking not found");

            var checkIn = new BookingCheckIn
            {
                BookingId = bookingId,
                CheckInTime = DateTime.UtcNow,
                IsCheckedIn = true
            };

            booking.SessionStatus = SessionStatus.CheckedIn;
            await _context.BookingCheckIns.AddAsync(checkIn);
            await _context.SaveChangesAsync();
            return checkIn;
        }

        public async Task<BookingCheckIn> CheckOutAsync(int bookingId)
        {
            var checkIn = await _context.BookingCheckIns.FirstOrDefaultAsync(c => c.BookingId == bookingId);
            if (checkIn == null) throw new ArgumentException("Check-in record not found");

            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking != null) booking.SessionStatus = SessionStatus.Completed;

            checkIn.CheckOutTime = DateTime.UtcNow;
            checkIn.IsCheckedOut = true;
            await _context.SaveChangesAsync();
            return checkIn;
        }

        public async Task<BookingCheckIn?> GetCheckInByBookingIdAsync(int bookingId)
        {
            return await _context.BookingCheckIns
                .Include(c => c.Booking)
                .FirstOrDefaultAsync(c => c.BookingId == bookingId);
        }
    }
}