using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Interfaces.IRepositories;
using ConferenceRoomBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Repositories
{
    public class EventRSVPRepository : BaseRepository<EventRSVP>, IEventRSVPRepository
    {
        public EventRSVPRepository(ConferenceRoomBookingDbContext context) : base(context) { }

        public async Task<EventRSVP?> GetUserRsvpAsync(int eventId, int userId)
        {
            return await _context.EventRSVPs.FirstOrDefaultAsync(r => r.EventId == eventId);
        }

        public async Task<IEnumerable<EventRSVP>> GetRsvpsByEventAsync(int eventId)
        {
            return await _context.EventRSVPs.Where(r => r.EventId == eventId).ToListAsync();
        }

        public async Task<IEnumerable<EventRSVP>> GetRsvpsByUserAsync(int userId)
        {
            return await _context.EventRSVPs
                .Where(r => r.InterestedUserIds.Contains(userId) ||
                           r.NotInterestedUserIds.Contains(userId) ||
                           r.MaybeUserIds.Contains(userId))
                .ToListAsync();
        }

        public async Task<bool> AddUserRsvpAsync(EventRSVP rsvp)
        {
            await _context.EventRSVPs.AddAsync(rsvp);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserRsvpAsync(int eventId, int userId, string status)
        {
            var rsvp = await _context.EventRSVPs.FirstOrDefaultAsync(r => r.EventId == eventId);
            if (rsvp == null)
            {
                rsvp = new EventRSVP
                {
                    EventId = eventId,
                    InterestedUserIds = new List<int>(),
                    NotInterestedUserIds = new List<int>(),
                    MaybeUserIds = new List<int>()
                };
                await _context.EventRSVPs.AddAsync(rsvp);
            }

            rsvp.InterestedUserIds.Remove(userId);
            rsvp.NotInterestedUserIds.Remove(userId);
            rsvp.MaybeUserIds.Remove(userId);

            switch (status.ToLower())
            {
                case "interested":
                    rsvp.InterestedUserIds.Add(userId);
                    break;
                case "not_interested":
                    rsvp.NotInterestedUserIds.Add(userId);
                    break;
                case "maybe":
                    rsvp.MaybeUserIds.Add(userId);
                    break;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetInterestedCountAsync(int eventId)
        {
            var rsvp = await _context.EventRSVPs.FirstOrDefaultAsync(r => r.EventId == eventId);
            return rsvp?.InterestedUserIds?.Count ?? 0;
        }

        public async Task<int> GetNotInterestedCountAsync(int eventId)
        {
            var rsvp = await _context.EventRSVPs.FirstOrDefaultAsync(r => r.EventId == eventId);
            return rsvp?.NotInterestedUserIds?.Count ?? 0;
        }

        public async Task<int> GetMaybeCountAsync(int eventId)
        {
            var rsvp = await _context.EventRSVPs.FirstOrDefaultAsync(r => r.EventId == eventId);
            return rsvp?.MaybeUserIds?.Count ?? 0;
        }
    }
}