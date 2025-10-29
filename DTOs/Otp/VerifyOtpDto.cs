using ConferenceRoomBooking.Enum;

namespace ConferenceRoomBooking.DTOs.Otp
{
    public class VerifyOtpDto
    {
        public int UserId { get; set; }
        public string Otp { get; set; }
        public OtpType Type { get; set; }
    }
}
