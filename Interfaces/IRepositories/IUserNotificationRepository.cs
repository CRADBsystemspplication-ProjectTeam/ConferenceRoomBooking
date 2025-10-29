using ConferenceRoomBooking.Enum;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IRepositories
{
    public interface IUserNotificationRepository : IBaseRepository<UserNotification>
    {
        Task<IEnumerable<UserNotification>> GetByUserIdAsync(int userId);
        Task<IEnumerable<UserNotification>> GetByStatusAsync(EmailStatus status);
        Task<IEnumerable<UserNotification>> GetByDateRangeAsync(DateTime from, DateTime to);
        Task<IEnumerable<UserNotification>> GetPendingNotificationsAsync();
    }
}
