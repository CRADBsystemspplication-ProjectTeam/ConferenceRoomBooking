using ConferenceRoomBooking.DTOs.Booking;
using ConferenceRoomBooking.Enum;
using ConferenceRoomBooking.Interfaces.IRepositories;
using ConferenceRoomBooking.Interfaces.IServices;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IResourceRepository _resourceRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserNotificationService _notificationService;

        public BookingService(
            IBookingRepository bookingRepository,
            IResourceRepository resourceRepository,
            IUserRepository userRepository,
            IUserNotificationService notificationService)
        {
            _bookingRepository = bookingRepository;
            _resourceRepository = resourceRepository;
            _userRepository = userRepository;
            _notificationService = notificationService;
        }

        public async Task<BookingResponseDto> BookResource(CreateBookingDto bookingDto)
        {
            var resource = await _resourceRepository.GetByIdAsync(bookingDto.ResourceId);
            if (resource == null) throw new ArgumentException("Resource not found");

            var isAvailable = await _bookingRepository.IsResourceAvailableAsync(
                bookingDto.ResourceId, bookingDto.Date, bookingDto.StartTime, bookingDto.EndTime);
            
            if (!isAvailable) throw new InvalidOperationException("Resource is not available for the selected time");

            var booking = new Booking
            {
                UserId = bookingDto.UserId,
                ResourceId = bookingDto.ResourceId,
                ResourceType = bookingDto.ResourceType,
                MeetingName = bookingDto.MeetingName,
                Date = bookingDto.Date,
                StartTime = bookingDto.StartTime,
                EndTime = bookingDto.EndTime,
                ParticipantCount = bookingDto.ParticipantCount,
                SessionStatus = SessionStatus.Reserved
            };

            var createdBooking = await _bookingRepository.AddAsync(booking);
            
            // Send booking confirmation email
            await SendBookingConfirmationAsync(createdBooking);
            
            return await MapToResponseDto(createdBooking);
        }

        public async Task<BookingResponseDto?> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            return booking == null ? null : await MapToResponseDto(booking);
        }

        public async Task<IEnumerable<BookingResponseDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllAsync();
            var tasks = bookings.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<BookingResponseDto>> GetUserBookingsAsync(int userId)
        {
            var bookings = await _bookingRepository.GetBookingsByUserIdAsync(userId);
            var tasks = bookings.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<BookingResponseDto>> GetBookingsByStatusAsync(SessionStatus status)
        {
            var bookings = await _bookingRepository.GetBookingsByStatusAsync(status);
            var tasks = bookings.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<BookingResponseDto>> GetBookingsForCalendarAsync(DateTime startDate, DateTime endDate)
        {
            var bookings = await _bookingRepository.GetBookingsByDateRangeAsync(startDate, endDate);
            var tasks = bookings.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<BookingResponseDto>> GetBookingsByResourceIdAsync(int resourceId, DateTime? date = null)
        {
            var bookings = await _bookingRepository.GetBookingsByResourceIdAsync(resourceId);
            if (date.HasValue)
                bookings = bookings.Where(b => b.Date.Date == date.Value.Date);
            
            var tasks = bookings.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<bool> CancelBookingAsync(int bookingId, int userId, string reason)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null || booking.UserId != userId) return false;

            var result = await _bookingRepository.CancelBookingAsync(bookingId, reason);
            
            if (result)
            {
                await SendBookingCancellationAsync(booking, reason);
            }
            
            return result;
        }

        public async Task<bool> ValidateBookingAvailabilityAsync(int resourceId, DateTime date, TimeSpan startTime, TimeSpan endTime, int? excludeBookingId = null)
        {
            return await _bookingRepository.IsResourceAvailableAsync(resourceId, date, startTime, endTime, excludeBookingId);
        }

        public async Task<AlternativeTimeSlotsDto> GetAlternativeTimeSlotsAsync(int resourceId, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            var bookings = await _bookingRepository.GetBookingsByResourceIdAsync(resourceId);
            var dayBookings = bookings.Where(b => b.Date.Date == date.Date && b.SessionStatus != SessionStatus.Cancelled)
                                    .OrderBy(b => b.StartTime).ToList();

            var alternatives = new List<TimeSlotDto>();
            var workingHours = TimeSpan.FromHours(9);
            var workingEnd = TimeSpan.FromHours(18);
            var duration = endTime - startTime;

            for (var time = workingHours; time.Add(duration) <= workingEnd; time = time.Add(TimeSpan.FromMinutes(30)))
            {
                var slotEnd = time.Add(duration);
                var hasConflict = dayBookings.Any(b => b.StartTime < slotEnd && b.EndTime > time);
                
                if (!hasConflict)
                {
                    alternatives.Add(new TimeSlotDto { StartTime = time, EndTime = slotEnd });
                }
            }

            return new AlternativeTimeSlotsDto { AlternativeSlots = alternatives };
        }

        public async Task<BookingAnalyticsDto> GetBookingAnalyticsAsync(DateTime? startDate = null, DateTime? endDate = null, int? locationId = null)
        {
            var start = startDate ?? DateTime.UtcNow.AddDays(-30);
            var end = endDate ?? DateTime.UtcNow;
            
            var bookings = await _bookingRepository.GetBookingsByDateRangeAsync(start, end);
            
            return new BookingAnalyticsDto
            {
                TotalBookings = bookings.Count(),
                CompletedBookings = bookings.Count(b => b.SessionStatus == SessionStatus.Completed),
                CancelledBookings = bookings.Count(b => b.SessionStatus == SessionStatus.Cancelled),
                NoShowBookings = bookings.Count(b => b.SessionStatus == SessionStatus.NoShow)
            };
        }

        public async Task<IEnumerable<BookingResponseDto>> GetUpcomingBookingsAsync(int userId, int hours = 24)
        {
            var bookings = await _bookingRepository.GetBookingsByUserIdAsync(userId);
            var upcoming = bookings.Where(b => 
                b.Date >= DateTime.UtcNow.Date && 
                b.SessionStatus == SessionStatus.Reserved &&
                b.Date.Add(b.StartTime) <= DateTime.UtcNow.AddHours(hours));
            
            var tasks = upcoming.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<BookingResponseDto>> GetBookingHistoryAsync(int userId)
        {
            var bookings = await _bookingRepository.GetBookingsByUserIdAsync(userId);
            var history = bookings.Where(b => b.Date < DateTime.UtcNow.Date || 
                                            b.SessionStatus == SessionStatus.Completed ||
                                            b.SessionStatus == SessionStatus.Cancelled);
            
            var tasks = history.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<bool> HasConflictingBookingsAsync(int userId, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            var userBookings = await _bookingRepository.GetBookingsByUserIdAsync(userId);
            return userBookings.Any(b => 
                b.Date.Date == date.Date &&
                b.SessionStatus != SessionStatus.Cancelled &&
                b.StartTime < endTime && b.EndTime > startTime);
        }

        private async Task<BookingResponseDto> MapToResponseDto(Booking booking)
        {
            var user = await _userRepository.GetByIdAsync(booking.UserId);
            var resource = await _resourceRepository.GetByIdAsync(booking.ResourceId);

            return new BookingResponseDto
            {
                BookingId = booking.BookingId,
                UserId = booking.UserId,
                UserName = user != null ? $"{user.FirstName} {user.LastName}" : "Unknown",
                ResourceId = booking.ResourceId,
                ResourceName = resource?.Name ?? "Unknown",
                ResourceType = booking.ResourceType,
                MeetingName = booking.MeetingName,
                Date = booking.Date,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime,
                ParticipantCount = booking.ParticipantCount,
                SessionStatus = booking.SessionStatus,
                CancellationReason = booking.CancellationReason,
                CancelledAt = booking.CancelledAt
            };
        }

        private async Task SendBookingConfirmationAsync(Booking booking)
        {
            var resource = await _resourceRepository.GetByIdAsync(booking.ResourceId);
            var subject = "Booking Confirmation";
            var body = $@"Your booking has been confirmed!

Details:
Meeting: {booking.MeetingName}
Resource: {resource?.Name}
Date: {booking.Date:yyyy-MM-dd}
Time: {booking.StartTime} - {booking.EndTime}
Participants: {booking.ParticipantCount}

Please check-in on time.";
            
            await _notificationService.SendNotificationAsync(new DTOs.UserNotification.SendNotificationDto
            {
                UserId = booking.UserId,
                Title = subject,
                Message = body,
                Type = Enum.NotificationType.BookingConfirmation
            });
        }

        private async Task SendBookingCancellationAsync(Booking booking, string reason)
        {
            var resource = await _resourceRepository.GetByIdAsync(booking.ResourceId);
            var subject = "Booking Cancelled";
            var body = $@"Your booking has been cancelled.

Details:
Meeting: {booking.MeetingName}
Resource: {resource?.Name}
Date: {booking.Date:yyyy-MM-dd}
Time: {booking.StartTime} - {booking.EndTime}
Reason: {reason}";
            
            await _notificationService.SendNotificationAsync(new DTOs.UserNotification.SendNotificationDto
            {
                UserId = booking.UserId,
                Title = subject,
                Message = body,
                Type = Enum.NotificationType.BookingCancellation
            });
        }
    }
}