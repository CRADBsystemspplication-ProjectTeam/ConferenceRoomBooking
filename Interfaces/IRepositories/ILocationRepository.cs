using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IRepositories
{
    public interface ILocationRepository : IBaseRepository<Location>
    {
        Task<IEnumerable<Location>> SearchLocationsAsync(string searchTerm);
        Task<IEnumerable<Location>> GetLocationsSortedAsync(string sortBy, bool ascending);
        Task<int> GetBuildingCountAsync(int locationId);
    }
}
