using ConferenceRoomBooking.Models.ConferenceRoomAndDeskBookingApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomBooking.Models
{
    public class BookingCheckIn
    {
        [Key]
        public int CheckInId { get; set; }

        [Required]
        public int BookingId { get; set; }

        public DateTime? CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public TimeSpan? ActualDuration { get; set; }

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }
    }

}
