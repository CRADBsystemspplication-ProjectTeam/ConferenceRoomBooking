using ConferenceRoomBooking.DTOs.Booking;
using ConferenceRoomBooking.Enum;

namespace ConferenceRoomBooking.Interfaces.IServices
{

    public interface IBookingService
    {
        Task<BookingResponseDto> BookResource(CreateBookingDto bookingDto);
        Task<BookingResponseDto?> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<BookingResponseDto>> GetAllBookingsAsync();
        Task<IEnumerable<BookingResponseDto>> GetUserBookingsAsync(int userId);
        Task<IEnumerable<BookingResponseDto>> GetBookingsByStatusAsync(SessionStatus status);
        Task<IEnumerable<BookingResponseDto>> GetBookingsForCalendarAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<BookingResponseDto>> GetBookingsByResourceIdAsync(int resourceId, DateTime? date = null);
        //Task<BookingResponseDto> UpdateBookingAsync(int bookingId, UpdateBookingDto bookingDto, int userId);
        Task<bool> CancelBookingAsync(int bookingId, int userId, string reason);
        Task<bool> ValidateBookingAvailabilityAsync(int resourceId, DateTime date, TimeSpan startTime, TimeSpan endTime, int? excludeBookingId = null);
        Task<AlternativeTimeSlotsDto> GetAlternativeTimeSlotsAsync(int resourceId, DateTime date, TimeSpan startTime, TimeSpan endTime);
        Task<BookingAnalyticsDto> GetBookingAnalyticsAsync(DateTime? startDate = null, DateTime? endDate = null, int? locationId = null);
        Task<IEnumerable<BookingResponseDto>> GetUpcomingBookingsAsync(int userId, int hours = 24);
        Task<IEnumerable<BookingResponseDto>> GetBookingHistoryAsync(int userId);
        Task<bool> HasConflictingBookingsAsync(int userId, DateTime date, TimeSpan startTime, TimeSpan endTime);
    }


}
