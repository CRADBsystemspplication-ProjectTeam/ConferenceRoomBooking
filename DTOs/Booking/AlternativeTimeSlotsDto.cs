namespace ConferenceRoomBooking.DTOs.Booking
{
    public class AlternativeTimeSlotsDto
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public List<TimeSlotDto> AvailableSlots { get; set; } = new();
    }
}
