using ConferenceRoomBooking.DTOs.User;

namespace ConferenceRoomBooking.Interfaces.IServices
{
    public interface IUserService
    {
        // User Management (Admin-only operations)
        Task<UserProfileDto?> GetUserByIdAsync(int id);
        Task<IEnumerable<UserProfileDto>> GetAllUsersAsync();
        Task<IEnumerable<UserProfileDto>> GetUsersByLocationAsync(int locationId);
        Task<IEnumerable<UserProfileDto>> GetUsersByDepartmentAsync(int departmentId);
        Task<IEnumerable<UserProfileDto>> SearchUsersAsync(string keyword);
        Task<UserProfileDto> CreateUserAsync(CreateUserDto dto);   // Admin creates new employee
        Task UpdateUserAsync(int id, UpdateUserDto dto);
        Task DeleteUserAsync(int userId);

        // Employee Profile (Self-access section)
        Task<UserProfileDto?> GetProfileAsync(int userId);
        Task UpdateProfileAsync(int userId, UpdateProfileDto dto);

        // Validation Utilities
        Task<bool> IsEmailAvailableAsync(string email);
        Task<bool> IsEmployeeIdAvailableAsync(string employeeId);
    }

}
