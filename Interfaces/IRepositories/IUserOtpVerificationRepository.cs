using ConferenceRoomBooking.Enum;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IRepositories
{
    public interface IUserOtpVerificationRepository : IBaseRepository<UserOtpVerification>
    {
        Task<UserOtpVerification?> GetLatestOtpAsync(int userId, OtpType type);
        Task MarkAsUsedAsync(int otpId);
        Task IncrementAttemptsAsync(int otpId);
    }
}
