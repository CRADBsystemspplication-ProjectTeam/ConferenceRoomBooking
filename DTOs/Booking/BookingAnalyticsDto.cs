﻿namespace ConferenceRoomBooking.DTOs.Booking
{
    public class BookingAnalyticsDto
    {
        public int TotalBookings { get; set; }
        public int ActiveBookings { get; set; }
        public int CompletedBookings { get; set; }
        public int CancelledBookings { get; set; }
        public int NoShowCount { get; set; }

        public double AverageBookingDuration { get; set; }
        public double ResourceUtilizationRate { get; set; }
        public double NoShowRate { get; set; }

        public Dictionary<string, int> BookingsByResource { get; set; } = new();
        public Dictionary<string, int> BookingsByDay { get; set; } = new();
        public Dictionary<string, int> BookingsByHour { get; set; } = new();

        public List<TopResourceDto> MostBookedResources { get; set; } = new();
        public List<TopUserDto> TopUsers { get; set; } = new();
    }
}
