using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Location
{
    public class LocationUpdateDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public byte[]? LocationImage { get; set; }  // Nullable image field
        public bool? IsActive { get; set; }
    }
}
