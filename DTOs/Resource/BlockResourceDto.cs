using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DTOs.Resource
{
    public class BlockResourceDto
    {
        public DateTime? BlockedFrom { get; set; }
        public DateTime? BlockedUntil { get; set; }

        [MaxLength(500)]
        public string? BlockReason { get; set; }
    }
}
