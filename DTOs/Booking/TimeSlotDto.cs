namespace ConferenceRoomBooking.DTOs.Booking
{
    public class TimeSlotDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DisplayTime { get; set; } = string.Empty;
    }
}
