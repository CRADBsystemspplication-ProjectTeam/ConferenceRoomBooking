using ConferenceRoomBooking.DTOs.User;
using ConferenceRoomBooking.Interfaces.IRepositories;
using ConferenceRoomBooking.Interfaces.IServices;
using ConferenceRoomBooking.Models;
using System.Security.Cryptography;
using System.Text;

namespace ConferenceRoomBooking.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserNotificationService _notificationService;

        public UserService(IUserRepository userRepository, IUserNotificationService notificationService)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
        }

        public async Task<UserProfileDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : MapToProfileDto(user);
        }

        public async Task<IEnumerable<UserProfileDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(MapToProfileDto);
        }

        public async Task<IEnumerable<UserProfileDto>> GetUsersByLocationAsync(int locationId)
        {
            var users = await _userRepository.GetByLocationAsync(locationId);
            return users.Select(MapToProfileDto);
        }

        public async Task<IEnumerable<UserProfileDto>> GetUsersByDepartmentAsync(int departmentId)
        {
            var users = await _userRepository.GetByDepartmentAsync(departmentId);
            return users.Select(MapToProfileDto);
        }

        public async Task<IEnumerable<UserProfileDto>> SearchUsersAsync(string keyword)
        {
            var users = await _userRepository.SearchAsync(keyword);
            return users.Select(MapToProfileDto);
        }

        public async Task<UserProfileDto> CreateUserAsync(CreateUserDto dto)
        {
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                EmployeeId = dto.EmployeeId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                LocationId = dto.LocationId,
                DepartmentId = dto.DepartmentId,
                Title = dto.Title,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var createdUser = await _userRepository.AddAsync(user);
            
            // Send welcome email with credentials
            await SendWelcomeEmailAsync(createdUser, dto.Password);
            
            return MapToProfileDto(createdUser);
        }

        private async Task SendWelcomeEmailAsync(User user, string password)
        {
            var subject = "Welcome to Conference Room Booking System";
            var body = $@"Dear {user.FirstName} {user.LastName},

Welcome to the Conference Room Booking System!

Your login credentials:
Email: {user.Email}
Password: {password}

Please login and change your password for security.

Best regards,
Conference Room Booking Team";
            
            await _notificationService.SendNotificationAsync(new DTOs.UserNotification.SendNotificationDto
            {
                UserId = user.Id,
                Title = subject,
                Message = body,
                Type = Enum.NotificationType.Welcome
            });
        }

        public async Task UpdateUserAsync(int id, UpdateUserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new ArgumentException("User not found");

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.LocationId = dto.LocationId;
            user.DepartmentId = dto.DepartmentId;
            user.Title = dto.Title;
            user.IsActive = dto.IsActive;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        public async Task<UserProfileDto?> GetProfileAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return user == null ? null : MapToProfileDto(user);
        }

        public async Task UpdateProfileAsync(int userId, UpdateProfileDto dto)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) throw new ArgumentException("User not found");

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.PhoneNumber = dto.PhoneNumber;
            user.Title = dto.Title;
            user.ProfileImage = dto.ProfileImage;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> IsEmailAvailableAsync(string email)
        {
            return !await _userRepository.ExistsByEmailAsync(email);
        }

        public async Task<bool> IsEmployeeIdAvailableAsync(string employeeId)
        {
            return !await _userRepository.ExistsByEmployeeIdAsync(employeeId);
        }

        private static UserProfileDto MapToProfileDto(User user)
        {
            return new UserProfileDto
            {
                Id = user.Id,
                EmployeeId = user.EmployeeId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                LocationId = user.LocationId,
                DepartmentId = user.DepartmentId,
                Title = user.Title,
                Role= user.Role.ToString(),
                IsActive = user.IsActive,
                ProfileImage = user.ProfileImage,
                LastLoginAt = user.LastLoginAt,
                CreatedAt = user.CreatedAt
            };
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}