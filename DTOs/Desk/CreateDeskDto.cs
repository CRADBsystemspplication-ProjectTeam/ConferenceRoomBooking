using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Desk
{
    public class CreateDeskDto
    {
        [Required]
        public int ResourceId { get; set; }

        [Required]
        [StringLength(100)]
        public string DeskName { get; set; }

        public byte[]? DeskImage { get; set; }
    }
}
