using ConferenceRoomBooking.Enum;

namespace ConferenceRoomBooking.DTOs.Otp
{
    public class SendOtpDto
    {
        public int UserId { get; set; }
        public OtpType Type { get; set; }
    }
}
