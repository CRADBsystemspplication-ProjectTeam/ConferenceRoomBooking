using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Enum;
using ConferenceRoomBooking.Interfaces.IRepositories;
using ConferenceRoomBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Repositories
{
    public class UserOtpVerificationRepository : BaseRepository<UserOtpVerification>, IUserOtpVerificationRepository
    {
        public UserOtpVerificationRepository(ConferenceRoomBookingDbContext context) : base(context) { }

        public async Task<UserOtpVerification?> GetLatestOtpAsync(int userId, OtpType type)
        {
            return await _context.UserOtpVerifications
                .Where(o => o.UserId == userId && o.Type == type && !o.IsUsed)
                .OrderByDescending(o => o.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task MarkAsUsedAsync(int otpId)
        {
            var otp = await _context.UserOtpVerifications.FindAsync(otpId);
            if (otp != null)
            {
                otp.IsUsed = true;
                otp.UsedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task IncrementAttemptsAsync(int otpId)
        {
            var otp = await _context.UserOtpVerifications.FindAsync(otpId);
            if (otp != null)
            {
                otp.AttemptCount++;
                await _context.SaveChangesAsync();
            }
        }
    }
}