using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomBooking.Models
{
    public class Desk
    {
        [Key]
        public int DeskId { get; set; }

        [Required]
        public int ResourceId { get; set; }

        [Required]
        [StringLength(100)]
        public string DeskName { get; set; }

        public byte[]? DeskImage { get; set; }

        // Navigation Properties
        [ForeignKey("ResourceId")]
        public Resource Resource { get; set; }
    }
}
