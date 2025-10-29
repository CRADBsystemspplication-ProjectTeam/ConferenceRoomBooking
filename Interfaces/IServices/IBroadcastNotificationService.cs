using ConferenceRoomBooking.DTOs.BroadCastNotification;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IServices
{
    public interface IBroadcastNotificationService
    {
        Task<BroadcastNotification> CreateBroadcastAsync(SendBroadcastDto dto);
        Task<BroadcastNotification> UpdateBroadcastAsync(int id, SendBroadcastDto dto);
        Task<bool> DeleteBroadcastAsync(int id);
        Task<BroadcastNotification> GetBroadcastByIdAsync(int id);
        Task<IEnumerable<BroadcastNotification>> GetAllBroadcastsAsync();
        Task ProcessPendingBroadcastsAsync();

        // Additional methods matching repository filtering capabilities
        Task<IEnumerable<BroadcastNotification>> GetByDateRangeAsync(DateTime from, DateTime to);
        Task<IEnumerable<BroadcastNotification>> GetByDepartmentIdAsync(int departmentId);
        Task<IEnumerable<BroadcastNotification>> GetByLocationIdAsync(int locationId);
    }
}
