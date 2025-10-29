using ConferenceRoomBooking.Enum;

namespace ConferenceRoomBooking.DTOs.BroadCastNotification
{
    public class SendBroadcastDto
    {
        public string NotificationSubject { get; set; }
        public string Description { get; set; }
        public BroadcastNotificationType NotificationType { get; set; }
        public UserRole? UserType { get; set; }
        public int? LocationId { get; set; }
        public int? DepartmentId { get; set; }
    }
}
