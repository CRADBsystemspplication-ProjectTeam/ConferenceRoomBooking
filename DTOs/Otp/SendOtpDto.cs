using ConferenceRoomBooking.Enum;

namespace ConferenceRoomBooking.DTOs.Otp
{
    public class SendOtpDto
    {
        public string Email { get; set; } = string.Empty;
        public OtpType Type { get; set; }
    }
}
