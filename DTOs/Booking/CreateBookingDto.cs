using ConferenceRoomBooking.Enum;
using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Booking
{
    public class CreateBookingDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ResourceId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public string MeetingName { get; set; }

        [Required]
        public int ParticipantCount { get; set; }

        [MaxLength(500)]
        public string? Purpose { get; set; }

        public bool SendReminder { get; set; } = true;
    }

}
