using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Interfaces.IRepositories;
using ConferenceRoomBooking.Interfaces.IServices;
using ConferenceRoomBooking.Repositories;
using ConferenceRoomBooking.Services;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomBooking.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Database Context
            services.AddDbContext<ConferenceRoomBookingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Email Settings
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            // Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IFloorRepository, FloorRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IDeskRepository, DeskRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventRSVPRepository, EventRSVPRepository>();
            services.AddScoped<IBookingCheckInRepository, BookingCheckInRepository>();
            services.AddScoped<IUserNotificationRepository, UserNotificationRepository>();
            services.AddScoped<IUserOtpVerificationRepository, UserOtpVerificationRepository>();
            services.AddScoped<IBroadcastNotificationRepository, BroadcastNotificationRepository>();

            // Services
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IFloorService, FloorService>();
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IUserNotificationService, UserNotificationService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingCheckInService, BookingCheckInService>();

            // Background Services
            services.AddHostedService<NotificationBackgroundService>();

            return services;
        }
    }
}