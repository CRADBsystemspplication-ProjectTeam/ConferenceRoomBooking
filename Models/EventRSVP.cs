using ConferenceRoomBooking.Models.ConferenceRoomAndDeskBookingApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomBooking.Models
{
    public class EventRSVP
    {
        [Key]
        public int RSVPId { get; set; }

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }

        // Store lists as JSON if needed, or as separate related entries (this is flexible)
        [Required]
        public List<int>? InterestedUserIds { get; set; } = new();

        [Required]
        public List<int>? NotInterestedUserIds { get; set; } = new();

        [Required]
        public List<int>? MaybeUserIds { get; set; } = new();

        // Navigation property
        public Event? Event { get; set; }
    }

}
