using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomBooking.Models
{
    public class Floor
    {
        [Key]
        public int FloorId { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int BuildingId { get; set; }

        [Required]
        [StringLength(10)]
        public string FloorNumber { get; set; }

        public int? NumberOfRooms { get; set; }

        public int? NumberOfDesks { get; set; }

        public byte[]? FloorPlanImage { get; set; }

        // Navigation Properties
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [ForeignKey("BuildingId")]
        public Building Building { get; set; }

        public ICollection<Resource> Resources { get; set; } = new List<Resource>();
    }

}
