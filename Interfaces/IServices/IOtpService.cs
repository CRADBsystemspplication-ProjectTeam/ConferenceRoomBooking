using ConferenceRoomBooking.DTOs.Otp;

namespace ConferenceRoomBooking.Interfaces.IServices
{

    public interface IOtpService
    {
        Task<bool> SendOtpAsync(SendOtpDto dto);
        Task<bool> VerifyOtpAsync(VerifyOtpDto dto);
    }
}
