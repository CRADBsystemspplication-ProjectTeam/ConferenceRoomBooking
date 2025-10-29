# Conference Room Booking System - Startup Guide

## ✅ **Ready to Run in Visual Studio 2022**

### **Prerequisites:**
1. Visual Studio 2022 Community Edition
2. .NET 8.0 SDK
3. SQL Server (LocalDB or full instance)

### **Setup Steps:**

#### 1. **Open Project**
- Open `ConferenceRoomBooking.sln` in Visual Studio 2022
- Restore NuGet packages (should happen automatically)

#### 2. **Update Connection String**
- Open `appsettings.json`
- Update the connection string to match your SQL Server instance:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ConferenceRoomBookingDb;Trusted_Connection=true;TrustServerCertificate=true"
  }
}
```

#### 3. **Run Database Migrations**
- Open Package Manager Console in Visual Studio
- Run: `Update-Database`
- This will create the database and all tables

#### 4. **Update Email Settings (Optional)**
- In `appsettings.json`, update email settings with your SMTP credentials
- For Gmail, use app-specific password

#### 5. **Run the Application**
- Press F5 or click "Start Debugging"
- The API will start and Swagger UI will open automatically
- Default URL: `https://localhost:7xxx/swagger`

### **What's Included:**

#### **✅ Complete Implementation:**
- 13 Repositories with full CRUD operations
- 13 Services with business logic
- 11 Controllers with REST API endpoints
- Background service for email reminders
- JWT authentication and authorization
- SMTP email integration
- Comprehensive error handling and logging

#### **✅ API Endpoints Available:**
- `/api/auth` - Authentication (login, password reset)
- `/api/users` - User management
- `/api/bookings` - Booking management
- `/api/locations` - Location management
- `/api/buildings` - Building management
- `/api/floors` - Floor management
- `/api/resources` - Resource management
- `/api/rooms` - Room management
- `/api/desks` - Desk management
- `/api/bookingcheckin` - Check-in/check-out
- `/api/notifications` - Notification management

#### **✅ Features Working:**
- User registration and authentication
- Resource booking with availability checks
- Email notifications and reminders
- Check-in/check-out functionality
- Admin panel capabilities
- Real-time booking management
- Analytics and reporting

### **Testing the API:**
1. Use Swagger UI for interactive testing
2. Create a test user via `/api/users` (Admin role required)
3. Login via `/api/auth/login` to get JWT token
4. Use the token in Authorization header: `Bearer <your-token>`
5. Test booking creation and management

### **Troubleshooting:**
- If database connection fails, check connection string
- If email doesn't work, verify SMTP settings
- If JWT fails, check the secret key length (must be 32+ characters)
- Check Package Manager Console for any migration errors

The application is production-ready with professional error handling, logging, and security features!