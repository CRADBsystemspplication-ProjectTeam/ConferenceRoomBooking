﻿using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.User
{
    public class UserProfileDto
    {
        public byte[]? ProfileImage { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeId { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        public int? LocationId { get; set; }

        public int? DepartmentId { get; set; }

        [StringLength(100)]
        public string? Title { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;
    }

}
