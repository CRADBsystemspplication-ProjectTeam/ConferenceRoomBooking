namespace ConferenceRoomBooking.Interfaces.IServices
{
    public interface INotificationBackgroundService
    {
        Task SendEntryRemindersAsync();
        Task SendExitRemindersAsync();
        Task SendOverdueRemindersAsync();
        Task SendNoCheckInRemindersAsync();
        Task SendNoCheckOutRemindersAsync();
    }
}
