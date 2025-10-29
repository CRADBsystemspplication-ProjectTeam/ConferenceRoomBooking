using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ConferenceRoomBooking.Models
{
    public class Building
    {

        [Key]
        public int BuildingId { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        [StringLength(100)]
        public string BuildingName { get; set; }

        public int NoOfFloors { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public ICollection<Floor> Floors { get; set; } = new List<Floor>();
        public ICollection<Resource> Resources { get; set; } = new List<Resource>();
    }
}
