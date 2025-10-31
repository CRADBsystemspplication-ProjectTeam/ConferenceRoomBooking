using ConferenceRoomBooking.Enum;
using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.EventRSVP
{
    public class CreateRsvpDto
    {
        [Required]
        public int EventId { get; set; }

        [Required]
        public RsvpStatusType Status { get; set; }
    }
}