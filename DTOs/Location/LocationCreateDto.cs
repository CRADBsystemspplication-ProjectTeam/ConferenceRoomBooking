using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Location
{
    public class LocationCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        public byte[]? LocationImage { get; set; }  // Nullable image field
    }
}
