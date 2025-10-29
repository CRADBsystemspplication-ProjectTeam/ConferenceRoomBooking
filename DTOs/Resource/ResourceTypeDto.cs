﻿using ConferenceRoomBooking.Enum;
using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Resource
{
    public class ResourceTypeDto
    {
        [Required]
        public ResourceType ResourceType { get; set; }
    }
}
