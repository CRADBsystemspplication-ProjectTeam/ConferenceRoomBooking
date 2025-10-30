using ConferenceRoomBooking.DTOs.Location;
using ConferenceRoomBooking.Interfaces.IRepositories;
using ConferenceRoomBooking.Interfaces.IServices;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<LocationResponseDto> CreateLocationAsync(LocationCreateDto locationCreateDto)
        {
            var location = new Location
            {
                Name = locationCreateDto.Name,
                Address = locationCreateDto.Address,
                City = locationCreateDto.City,
                State = locationCreateDto.State,
                Country = locationCreateDto.Country,
                PostalCode = locationCreateDto.PostalCode,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var createdLocation = await _locationRepository.AddAsync(location);
            return MapToResponseDto(createdLocation);
        }

        public async Task<LocationResponseDto> UpdateLocationAsync(int locationId, LocationUpdateDto locationUpdateDto)
        {
            var location = await _locationRepository.GetByIdAsync(locationId);
            if (location == null) throw new ArgumentException("Location not found");

            location.Name = locationUpdateDto.Name;
            location.Address = locationUpdateDto.Address;
            location.City = locationUpdateDto.City;
            location.State = locationUpdateDto.State;
            location.Country = locationUpdateDto.Country;
            location.PostalCode = locationUpdateDto.PostalCode;
            location.UpdatedAt = DateTime.UtcNow;

            await _locationRepository.UpdateAsync(location);
            return MapToResponseDto(location);
        }

        public async Task<LocationResponseDto?> GetLocationByIdAsync(int locationId)
        {
            var location = await _locationRepository.GetByIdAsync(locationId);
            return location == null ? null : MapToResponseDto(location);
        }

        public async Task<IEnumerable<LocationResponseDto>> GetAllLocationsAsync()
        {
            var locations = await _locationRepository.GetAllAsync();
            return locations.Select(MapToResponseDto);
        }

        public async Task DeleteLocationAsync(int locationId)
        {
            await _locationRepository.DeleteAsync(locationId);
        }

        public async Task<IEnumerable<LocationResponseDto>> SearchLocationsAsync(string searchTerm)
        {
            var locations = await _locationRepository.SearchLocationsAsync(searchTerm);
            return locations.Select(MapToResponseDto);
        }

        public async Task<IEnumerable<LocationResponseDto>> GetLocationsSortedAsync(string sortBy, bool ascending)
        {
            var locations = await _locationRepository.GetLocationsSortedAsync(sortBy, ascending);
            return locations.Select(MapToResponseDto);
        }

        public async Task<int> GetBuildingCountAsync(int locationId)
        {
            return await _locationRepository.GetBuildingCountAsync(locationId);
        }

        private static LocationResponseDto MapToResponseDto(Location location)
        {
            return new LocationResponseDto
            {
                LocationId = location.LocationId,
                Name = location.Name,
                Address = location.Address,
                City = location.City,
                State = location.State,
                Country = location.Country,
                PostalCode = location.PostalCode,
                CreatedAt = location.CreatedAt,
                UpdatedAt = location.UpdatedAt
            };
        }
    }
}