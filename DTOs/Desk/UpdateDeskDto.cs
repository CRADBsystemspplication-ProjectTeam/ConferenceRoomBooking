using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Desk
{
    public class UpdateDeskDto
    {
        [StringLength(100)]
        public string? DeskName { get; set; }

        public byte[]? DeskImage { get; set; }
    }
}
