using ConferenceRoomBooking.DTOs.Auth;
using ConferenceRoomBooking.Enum;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IServices
{
    public interface IAuthService
    {
        // 🔹 Authentication
        Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto);
        Task<bool> ValidateUserCredentialsAsync(string email, string password);

        // 🔹 Password Management
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
        Task<bool> ResetPasswordAsync(string email, string newPassword);

        // 🔹 OTP Handling (for Forgot Password only)
        Task GenerateAndSendOtpAsync(string email, OtpType type);
        Task<bool> VerifyOtpAsync(string email, string otp, OtpType type);

        // 🔹 Token Management
        Task<string> GenerateJwtTokenAsync(User user);
    }

}
