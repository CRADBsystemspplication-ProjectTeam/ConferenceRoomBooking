using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IRepositories
{
    public interface IBookingCheckInRepository : IBaseRepository<BookingCheckIn>
    {
        Task<BookingCheckIn> CheckInAsync(int bookingId);
        Task<BookingCheckIn> CheckOutAsync(int bookingId);
        Task<BookingCheckIn?> GetCheckInByBookingIdAsync(int bookingId);
    }
}
