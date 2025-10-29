﻿using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Event
{
    public class CreateEventDto
    {
        [Required]
        [StringLength(200)]
        public string EventTitle { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }

        public int? LocationId { get; set; }

        public int? BuildingId { get; set; }

        public int? FloorId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public byte[]? EventImage { get; set; }
    }

}
