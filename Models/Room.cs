using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomBooking.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        public int ResourceId { get; set; }

        [Required]
        [StringLength(100)]
        public string RoomName { get; set; }

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

        // Navigation Properties
        [ForeignKey("ResourceId")]
        public Resource Resource { get; set; }
    }
}
