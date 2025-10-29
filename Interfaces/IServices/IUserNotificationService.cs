﻿using ConferenceRoomBooking.DTOs.UserNotification;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Interfaces.IServices
{
    public interface IUserNotificationService
    {
        Task SendNotificationAsync(SendNotificationDto dto);
        Task<IEnumerable<UserNotification>> GetUserNotificationsAsync(int userId);
        Task MarkAsReadAsync(int notificationId);

        // Consider adding date range query for consistency with repository
        Task<IEnumerable<UserNotification>> GetByDateRangeAsync(DateTime from, DateTime to);
    }
}
