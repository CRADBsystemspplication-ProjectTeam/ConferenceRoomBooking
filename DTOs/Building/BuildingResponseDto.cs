namespace ConferenceRoomBooking.DTOs.Building
{
    public class BuildingResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int LocationId { get; set; }

        public string? LocationName { get; set; }

        public string Address { get; set; } = string.Empty;

        public int? NumberOfFloors { get; set; }

        public byte[]? BuildingImage { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}