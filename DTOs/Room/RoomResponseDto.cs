namespace ConferenceRoomBooking.DTOs.Room
{
    public class RoomResponseDto
    {
        public int RoomId { get; set; }
        public int ResourceId { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public bool TV { get; set; }
        public bool Whiteboard { get; set; }
        public bool Wifi { get; set; }
        public bool DigitalProjector { get; set; }
        public bool VideoConferenceEquipment { get; set; }
        public bool HasAirConditioning { get; set; }
        public string? PhoneExtension { get; set; }
        public byte[]? RoomImage { get; set; }

        // Resource Information
        public int LocationId { get; set; }
        public int BuildingId { get; set; }
        public int FloorId { get; set; }
        public bool IsUnderMaintenance { get; set; }
        public bool IsActive { get; set; }
        public DateTime? BlockedFrom { get; set; }
        public DateTime? BlockedUntil { get; set; }
        public string? BlockReason { get; set; }
        public int? MinBookingDuration { get; set; }
        public int? MaxBookingDuration { get; set; }

        // Location Details
        public string? LocationAddress { get; set; }
        public string? City { get; set; }
        public string? BuildingName { get; set; }
        public string? FloorNumber { get; set; }

    }
}
