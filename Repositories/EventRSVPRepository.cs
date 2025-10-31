using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Enum;
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
            return await _context.EventRSVPs
                .FirstOrDefaultAsync(r => r.EventId == eventId && r.UserId == userId);
        }

        public async Task<IEnumerable<EventRSVP>> GetRsvpsByEventAsync(int eventId)
        {
            return await _context.EventRSVPs
                .Where(r => r.EventId == eventId)
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<EventRSVP>> GetRsvpsByUserAsync(int userId)
        {
            return await _context.EventRSVPs
                .Where(r => r.UserId == userId)
                .Include(r => r.Event)
                .ToListAsync();
        }

        public async Task<int> GetCountByStatusAsync(int eventId, RsvpStatusType status)
        {
            return await _context.EventRSVPs
                .CountAsync(r => r.EventId == eventId && r.Status == status);
        }
    }
}