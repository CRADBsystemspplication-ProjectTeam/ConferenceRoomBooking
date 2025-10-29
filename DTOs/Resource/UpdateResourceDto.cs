using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Resource
{
    public class UpdateResourceDto
    {
        public bool? IsUnderMaintenance { get; set; }

        [Range(15, 1440)]
        public int? MinBookingDuration { get; set; }

        [Range(15, 1440)]
        public int? MaxBookingDuration { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? BlockedFrom { get; set; }
        public DateTime? BlockedUntil { get; set; }

        [MaxLength(500)]
        public string? BlockReason { get; set; }
    }
}
