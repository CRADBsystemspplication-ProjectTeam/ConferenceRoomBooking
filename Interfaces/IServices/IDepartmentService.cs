using ConferenceRoomBooking.DTOs.Department;

namespace ConferenceRoomBooking.Interfaces.IServices
{
    public interface IDepartmentService
    {
        Task<DepartmentResponseDto?> CreateDepartmentAsync(CreateDepartmentDto dto);
        Task<DepartmentResponseDto?> GetDepartmentByIdAsync(int id);
        Task<IEnumerable<DepartmentResponseDto>> GetAllDepartmentsAsync();
        Task<IEnumerable<DepartmentResponseDto>> GetActiveDepartmentsAsync();
        Task<DepartmentResponseDto?> UpdateDepartmentAsync(int id, UpdateDepartmentDto dto);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}