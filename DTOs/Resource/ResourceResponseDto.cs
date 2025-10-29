namespace ConferenceRoomBooking.DTOs.Resource
{
    public class ResourceResponseDto
    {
        public int ResourceId { get; set; }
        public ResourceType ResourceType { get; set; }
        public int LocationId { get; set; }
        public int BuildingId { get; set; }
        public int FloorId { get; set; }
        public bool IsUnderMaintenance { get; set; }
        public int? MinBookingDuration { get; set; }
        public int? MaxBookingDuration { get; set; }
        public bool IsActive { get; set; }
        public DateTime? BlockedFrom { get; set; }
        public DateTime? BlockedUntil { get; set; }
        public string? BlockReason { get; set; }
        public DateTime CreatedAt { get; set; }

        // Location Information
        public string? LocationAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }

        // Building Information
        public string? BuildingName { get; set; }

        // Floor Information
        public string? FloorNumber { get; set; }
    }
}
