using ConferenceRoomBooking.DTOs.Event;

namespace ConferenceRoomBooking.Interfaces.IServices
{
    public interface IEventService
    {
        Task<EventResponseDto> CreateEventAsync(CreateEventDto dto);

        Task<EventResponseDto> UpdateEventAsync(int eventId, UpdateEventDto dto);

        Task<bool> DeleteEventAsync(int eventId);

        Task<IEnumerable<EventResponseDto>> GetAllEventsAsync();

        Task<EventResponseDto?> GetEventByIdAsync(int eventId);

        Task<IEnumerable<EventResponseDto>> SearchEventsAsync(string keyword);

        Task<IEnumerable<EventResponseDto>> FilterEventsByLocationNameAsync(string locationName);

        Task<IEnumerable<EventResponseDto>> GetUpcomingEventsAsync();

        Task<IEnumerable<EventResponseDto>> GetPastEventsAsync();

        Task<int> GetTotalEventCountAsync();

        Task<int> GetEventParticipantCountAsync(int eventId);
    }

}
