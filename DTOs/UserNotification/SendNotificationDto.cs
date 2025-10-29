using ConferenceRoomBooking.Enum;

namespace ConferenceRoomBooking.DTOs.UserNotification
{
    public class SendNotificationDto
    {
        public int UserId { get; set; }
        public int? BookingId { get; set; }
        public NotificationType NotificationType { get; set; }
        public string NotificationSubject { get; set; }
        public string Description { get; set; }
    }
}
