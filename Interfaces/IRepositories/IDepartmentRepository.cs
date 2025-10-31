using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IRepositories
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<Department?> GetByNameAsync(string departmentName);
        Task<IEnumerable<Department>> GetActiveDepartmentsAsync();
    }
}