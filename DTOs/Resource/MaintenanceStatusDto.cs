using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Resource
{
    public class MaintenanceStatusDto
    {
        [Required]
        public bool IsUnderMaintenance { get; set; }
    }
}
