using ConferenceRoomBooking.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceRoomBooking.Models
{
    public class UserOtpVerification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "OTP must be 4-6 digits.")]
        [RegularExpression(@"^\d{4,6}$", ErrorMessage = "OTP must contain only digits.")]
        public string Otp { get; set; }

        [Required]
        public OtpType Type { get; set; }

        [Required]
        public DateTime ExpiryAt { get; set; }

        public bool IsUsed { get; set; } = false;

        public int Attempts { get; set; } = 0;

        // Navigation property
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
