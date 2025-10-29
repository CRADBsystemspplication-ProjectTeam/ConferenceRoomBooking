using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Enum;
using ConferenceRoomBooking.Models;
using System.Security.Cryptography;
using System.Text;

namespace ConferenceRoomBooking.Services
{
    public class DataSeeder
    {
        private readonly ConferenceRoomBookingDbContext _context;

        public DataSeeder(ConferenceRoomBookingDbContext context)
        {
            _context = context;
        }

        public async Task SeedAdminAsync()
        {
            if (!_context.Users.Any(u => u.Role == UserRole.Admin))
            {
                CreatePasswordHash("Admin@123", out byte[] passwordHash, out byte[] passwordSalt);

                var admin = new User
                {
                    EmployeeId = "ADMIN001",
                    FirstName = "System",
                    LastName = "Administrator",
                    Email = "admin@company.com",
                    PhoneNumber = "1234567890",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Role = UserRole.Admin,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.Users.Add(admin);
                await _context.SaveChangesAsync();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}