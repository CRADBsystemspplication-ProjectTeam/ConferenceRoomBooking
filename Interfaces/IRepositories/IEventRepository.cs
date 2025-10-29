﻿using ConferenceRoomBooking.Models.ConferenceRoomAndDeskBookingApplication.Models;

namespace ConferenceRoomBooking.Interfaces.IRepositories
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task<IEnumerable<Event>> SearchEventsAsync(string keyword);

        Task<IEnumerable<Event>> FilterEventsByLocationNameAsync(string locationName);

        Task<IEnumerable<Event>> GetUpcomingEventsAsync();

        Task<IEnumerable<Event>> GetPastEventsAsync();

        Task<int> GetTotalEventCountAsync();

        Task<int> GetEventParticipantCountAsync(int eventId);
    }

}
