namespace ConferenceRoomBooking.DTOs.BookingCheckIn
{
    public class CheckInStatisticsDto
    {
        public int TotalCheckIns { get; set; }
        public int TotalNoShows { get; set; }
        public double NoShowRate { get; set; }
        public double AverageCheckInDuration { get; set; }
        public int OnTimeCheckIns { get; set; }
        public int LateCheckIns { get; set; }
    }

}
