namespace ConferenceRoomBooking.DTOs.Building
{
    public class BuildingUpdateDto
    {
        public string? Name { get; set; }

        public int? LocationId { get; set; }

        public string? Address { get; set; }

        public int? NumberOfFloors { get; set; }

        public byte[]? BuildingImage { get; set; }

        public bool? IsActive { get; set; }
    }
}