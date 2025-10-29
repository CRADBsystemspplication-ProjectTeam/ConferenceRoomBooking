using ConferenceRoomBooking.Enum;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IRepositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId);
        Task<IEnumerable<Booking>> GetBookingsByResourceIdAsync(int resourceId);
        Task<IEnumerable<Booking>> GetBookingsByStatusAsync(SessionStatus status);
        Task<IEnumerable<Booking>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<bool> IsResourceAvailableAsync(int resourceId, DateTime date, TimeSpan startTime, TimeSpan endTime, int? excludeBookingId = null);
        Task<bool> CancelBookingAsync(int bookingId, string cancellationReason);
        Task<IEnumerable<Booking>> GetNoShowBookingsAsync();
        Task<IEnumerable<Booking>> GetOverdueBookingsAsync();
    }
}
