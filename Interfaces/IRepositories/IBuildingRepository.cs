using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IRepositories
{
    public interface IBuildingRepository : IBaseRepository<Building>
    {
        Task<IEnumerable<Building>> GetBuildingsByLocationIdAsync(int locationId);
        Task<IEnumerable<Building>> SearchBuildingsAsync(string searchTerm);
        Task<IEnumerable<Building>> GetBuildingsSortedAsync(string sortBy, bool ascending);
    }
}
