using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Enum;
using ConferenceRoomBooking.Interfaces.IRepositories;
using ConferenceRoomBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ConferenceRoomBookingDbContext context) : base(context) { }

        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId)
        {
            return await _context.Bookings
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByResourceIdAsync(int resourceId)
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Where(b => b.ResourceId == resourceId)
                .OrderBy(b => b.Date)
                .ThenBy(b => b.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByStatusAsync(SessionStatus status)
        {
            return await _context.Bookings
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Where(b => b.SessionStatus == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Bookings
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Where(b => b.Date >= startDate && b.Date <= endDate)
                .OrderBy(b => b.Date)
                .ThenBy(b => b.StartTime)
                .ToListAsync();
        }

        public async Task<bool> IsResourceAvailableAsync(int resourceId, DateTime date, TimeSpan startTime, TimeSpan endTime, int? excludeBookingId = null)
        {
            var query = _context.Bookings
                .Where(b => b.ResourceId == resourceId &&
                           b.Date.Date == date.Date &&
                           b.SessionStatus != SessionStatus.Cancelled &&
                           ((b.StartTime < endTime && b.EndTime > startTime)));

            if (excludeBookingId.HasValue)
                query = query.Where(b => b.BookingId != excludeBookingId.Value);

            return !await query.AnyAsync();
        }

        public async Task<bool> CancelBookingAsync(int bookingId, string cancellationReason)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null) return false;

            booking.SessionStatus = SessionStatus.Cancelled;
            booking.CancellationReason = cancellationReason;
            booking.CancelledAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Booking>> GetNoShowBookingsAsync()
        {
            var currentTime = DateTime.UtcNow;
            return await _context.Bookings
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Where(b => b.SessionStatus == SessionStatus.Reserved &&
                           b.Date.Date <= currentTime.Date &&
                           b.EndTime <= currentTime.TimeOfDay)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetOverdueBookingsAsync()
        {
            var currentTime = DateTime.UtcNow;
            return await _context.Bookings
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Where(b => b.SessionStatus == SessionStatus.CheckedIn &&
                           (b.Date.Date < currentTime.Date ||
                            (b.Date.Date == currentTime.Date && b.EndTime < currentTime.TimeOfDay)))
                .ToListAsync();
        }
    }
}