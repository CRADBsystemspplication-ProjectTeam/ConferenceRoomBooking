namespace ConferenceRoomBooking.DTOs.Room
{
    public class RoomAmenityFilterDto
    {
        public int? LocationId { get; set; }
        public int? BuildingId { get; set; }
        public int? FloorId { get; set; }
        public int? MinCapacity { get; set; }
        public bool? TV { get; set; }
        public bool? Whiteboard { get; set; }
        public bool? Wifi { get; set; }
        public bool? DigitalProjector { get; set; }
        public bool? VideoConferenceEquipment { get; set; }
        public bool? HasAirConditioning { get; set; }
    }
}
