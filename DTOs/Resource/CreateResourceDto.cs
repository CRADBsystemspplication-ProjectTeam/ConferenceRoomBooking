using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Resource
{
    public class CreateResourceDto
    {
        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int BuildingId { get; set; }

        [Required]
        public int FloorId { get; set; }

        public bool IsUnderMaintenance { get; set; } = false;

        [Range(15, 1440)]
        public int? MinBookingDuration { get; set; }

        [Range(15, 1440)]
        public int? MaxBookingDuration { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? BlockedFrom { get; set; }
        public DateTime? BlockedUntil { get; set; }

        [MaxLength(500)]
        public string? BlockReason { get; set; }
    }
}
