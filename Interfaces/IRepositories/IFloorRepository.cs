using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IRepositories
{
    public interface IFloorRepository : IBaseRepository<Floor>
    {
        Task<IEnumerable<Floor>> GetFloorsByBuildingIdAsync(int buildingId);
        Task<IEnumerable<Floor>> SearchFloorsAsync(string searchTerm);
        Task<IEnumerable<Floor>> GetFloorsSortedAsync(string sortBy, bool ascending);
    }
}
