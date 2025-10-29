using ConferenceRoomBooking.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomBooking.Models
{
    public class BroadcastNotification
    {
        [Key]
        public int NotificationId { get; set; }

        [Required]
        [StringLength(200)]
        public string NotificationSubject { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        public BroadcastNotificationType NotificationType { get; set; }

        [Required]
        public EmailStatus Status { get; set; } = EmailStatus.Pending;

        public DateTime? SentAt { get; set; }

        // Target audience filters
        public UserRole? UserType { get; set; } // null = all users

        public int? LocationId { get; set; }

        public int? DepartmentId { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
