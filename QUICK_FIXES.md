# Quick Model Fixes Required

The models need to be updated to match the service expectations. Here are the key fixes needed:

## Resource Model
- Change `ResourceId` to `Id`
- Add `Name` property
- Add `IsBlocked` property
- Add `UpdatedAt` property

## Location Model  
- Change `LocationId` to `Id`
- Change `PinCode` to `PostalCode`
- Add `Name` property
- Add `CreatedAt` and `UpdatedAt` properties

## Building Model
- Change `BuildingId` to `Id`
- Add `Name` property
- Add `Address` property
- Add `CreatedAt` and `UpdatedAt` properties

## Floor Model
- Change `FloorId` to `Id`
- Add `FloorName` property

## Room Model
- Add `Id` property
- Add all amenity properties (HasTV, HasWiFi, etc.)

## Desk Model
- Add `Id` property
- Add all equipment properties (HasMonitor, HasKeyboard, etc.)

## UserNotification Model
- Add missing properties (Title, Message, Type, IsRead, ReadAt)

## BookingCheckIn Model
- Add missing properties (Id, IsCheckedIn, IsCheckedOut)

## All DTO Models
- Need to be created or updated to match service expectations