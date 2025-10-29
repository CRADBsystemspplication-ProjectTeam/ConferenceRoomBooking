using ConferenceRoomBooking.Enum;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IRepositories
{
    public interface IUserNotificationRepository : IBaseRepository<UserNotification>
    {
        Task<IEnumerable<UserNotification>> GetByUserIdAsync(int userId);
        Task<IEnumerable<UserNotification>> GetByStatusAsync(EmailStatus status);
    }
}
