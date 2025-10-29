namespace ConferenceRoomBooking.DTOs.Resource
{
    public class ResourceDetailResponseDto : ResourceResponseDto
    {
        // Room details (if ResourceType is Room)
        public int? RoomId { get; set; }
        public string? RoomName { get; set; }
        public int? Capacity { get; set; }
        public bool? TV { get; set; }
        public bool? Whiteboard { get; set; }
        public bool? Wifi { get; set; }
        public bool? DigitalProjector { get; set; }
        public bool? VideoConferenceEquipment { get; set; }
        public bool? HasAirConditioning { get; set; }
        public string? PhoneExtension { get; set; }
        public byte[]? RoomImage { get; set; }

        // Desk details (if ResourceType is Desk)
        public int? DeskId { get; set; }
        public string? DeskName { get; set; }
        public byte[]? DeskImage { get; set; }
    }
}
