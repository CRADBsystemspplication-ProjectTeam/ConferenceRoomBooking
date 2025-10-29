using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Room
{
    public class CreateRoomDto
    {
        [Required]
        public int ResourceId { get; set; }

        [Required]
        [StringLength(100)]
        public string RoomName { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Capacity { get; set; }

        public bool TV { get; set; } = false;
        public bool Whiteboard { get; set; } = false;
        public bool Wifi { get; set; } = false;
        public bool DigitalProjector { get; set; } = false;
        public bool VideoConferenceEquipment { get; set; } = false;
        public bool HasAirConditioning { get; set; } = false;

        [StringLength(20)]
        public string? PhoneExtension { get; set; }

        public byte[]? RoomImage { get; set; }
    }
}
