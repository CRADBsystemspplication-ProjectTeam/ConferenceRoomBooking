using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Room
{
    public class UpdateRoomDto
    {
        [StringLength(100)]
        public string? RoomName { get; set; }

        [Range(1, 1000)]
        public int? Capacity { get; set; }

        public bool? TV { get; set; }
        public bool? Whiteboard { get; set; }
        public bool? Wifi { get; set; }
        public bool? DigitalProjector { get; set; }
        public bool? VideoConferenceEquipment { get; set; }
        public bool? HasAirConditioning { get; set; }

        [StringLength(20)]
        public string? PhoneExtension { get; set; }

        public byte[]? RoomImage { get; set; }
    }
}
