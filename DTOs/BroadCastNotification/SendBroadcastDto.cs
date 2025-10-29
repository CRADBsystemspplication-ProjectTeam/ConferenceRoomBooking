using ConferenceRoomBooking.Enum;
using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.BroadCastNotification
{
    public class SendBroadcastDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Message { get; set; } = string.Empty;

        [Required]
        public BroadcastNotificationType Type { get; set; }

        public int? TargetLocationId { get; set; }
        public int? TargetDepartmentId { get; set; }
    }
}