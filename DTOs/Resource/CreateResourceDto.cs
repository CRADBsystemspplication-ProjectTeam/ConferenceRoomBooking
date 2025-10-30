﻿using ConferenceRoomBooking.Enum;
using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Resource
{
    public class CreateResourceDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int BuildingId { get; set; }

        [Required]
        public int FloorId { get; set; }

        public bool IsUnderMaintenance { get; set; } = false;


        public bool IsActive { get; set; } = true;

        public DateTime? BlockedFrom { get; set; }
        public DateTime? BlockedUntil { get; set; }

        [MaxLength(500)]
        public string? BlockReason { get; set; }
    }
}
