using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IRepositories
{
    public interface IEventRSVPRepository : IBaseRepository<EventRSVP>
    {
        Task<EventRSVP?> GetUserRsvpAsync(int eventId, int userId);

        Task<IEnumerable<EventRSVP>> GetRsvpsByEventAsync(int eventId);

        Task<IEnumerable<EventRSVP>> GetRsvpsByUserAsync(int userId);

        Task<bool> AddUserRsvpAsync(EventRSVP rsvp);

        Task<bool> UpdateUserRsvpAsync(int eventId, int userId, string status);

        Task<int> GetInterestedCountAsync(int eventId);

        Task<int> GetNotInterestedCountAsync(int eventId);

        Task<int> GetMaybeCountAsync(int eventId);
    }

}
