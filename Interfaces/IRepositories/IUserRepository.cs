using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByEmployeeIdAsync(string employeeId);

        //Filtering/Querying
        Task<IEnumerable<User>> GetByDepartmentAsync(int departmentId);
        Task<IEnumerable<User>> GetByLocationAsync(int locationId);
        Task<IEnumerable<User>> SearchAsync(string keyword);

        // Utility Methods
        Task<bool> ExistsByEmailAsync(string email);
        Task<bool> ExistsByEmployeeIdAsync(string employeeId);
    }

}
