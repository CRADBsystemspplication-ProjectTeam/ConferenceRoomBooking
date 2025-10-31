using ConferenceRoomBooking.DTOs.Resource;
using ConferenceRoomBooking.Interfaces.IRepositories;
using ConferenceRoomBooking.Interfaces.IServices;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task<ResourceResponseDto> CreateResourceAsync(CreateResourceDto createResourceDto)
        {
            var resource = new Resource
            {
                Name = createResourceDto.Name,
                ResourceType = createResourceDto.ResourceType,
                LocationId = createResourceDto.LocationId,
                BuildingId = createResourceDto.BuildingId,
                FloorId = createResourceDto.FloorId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var createdResource = await _resourceRepository.AddAsync(resource);
            return MapToResponseDto(createdResource);
        }

        public async Task<ResourceResponseDto?> GetResourceByIdAsync(int resourceId)
        {
            var resource = await _resourceRepository.GetByIdAsync(resourceId);
            return resource == null ? null : MapToResponseDto(resource);
        }

        public async Task<ResourceDetailResponseDto?> GetResourceWithDetailsAsync(int resourceId)
        {
            var resource = await _resourceRepository.GetResourceWithDetailsAsync(resourceId);
            return resource == null ? null : MapToDetailResponseDto(resource);
        }

        public async Task<IEnumerable<ResourceResponseDto>> GetAllResourcesAsync()
        {
            var resources = await _resourceRepository.GetAllAsync();
            return resources.Select(MapToResponseDto);
        }

        public async Task<IEnumerable<ResourceResponseDto>> GetResourcesByTypeAsync(ResourceTypeDto typeDto)
        {
            var resources = await _resourceRepository.GetResourcesByTypeAsync(typeDto.ResourceType);
            return resources.Select(MapToResponseDto);
        }

        public async Task<IEnumerable<ResourceResponseDto>> GetResourcesByLocationAsync(int locationId)
        {
            var resources = await _resourceRepository.GetResourcesByLocationAsync(locationId);
            return resources.Select(MapToResponseDto);
        }

        public async Task<IEnumerable<ResourceResponseDto>> GetResourcesByBuildingAsync(int buildingId)
        {
            var resources = await _resourceRepository.GetResourcesByBuildingAsync(buildingId);
            return resources.Select(MapToResponseDto);
        }

        public async Task<IEnumerable<ResourceResponseDto>> GetResourcesByFloorAsync(int floorId)
        {
            var resources = await _resourceRepository.GetResourcesByFloorAsync(floorId);
            return resources.Select(MapToResponseDto);
        }

        public async Task<IEnumerable<ResourceResponseDto>> GetAvailableResourcesAsync(ResourceAvailabilityRequestDto requestDto)
        {
            var resources = await _resourceRepository.GetAvailableResourcesAsync(
                requestDto.ResourceType, requestDto.LocationId, requestDto.Date, requestDto.StartTime, requestDto.EndTime);
            return resources.Select(MapToResponseDto);
        }

        public async Task<IEnumerable<ResourceResponseDto>> GetResourcesUnderMaintenanceAsync()
        {
            var resources = await _resourceRepository.GetResourcesUnderMaintenanceAsync();
            return resources.Select(MapToResponseDto);
        }

        public async Task<IEnumerable<ResourceResponseDto>> GetBlockedResourcesAsync()
        {
            var resources = await _resourceRepository.GetBlockedResourcesAsync();
            return resources.Select(MapToResponseDto);
        }

        public async Task<bool> IsResourceAvailableAsync(ResourceAvailabilityCheckDto checkDto)
        {
            return await _resourceRepository.IsResourceAvailableAsync(
                checkDto.ResourceId, checkDto.Date, checkDto.StartTime, checkDto.EndTime, checkDto.ExcludeBookingId);
        }

        public async Task<ResourceResponseDto> UpdateResourceAsync(int resourceId, UpdateResourceDto updateResourceDto)
        {
            var resource = await _resourceRepository.GetByIdAsync(resourceId);
            if (resource == null) throw new ArgumentException("Resource not found");

            // Only update properties if they are provided (not null)
            if (updateResourceDto.Name != null)
                resource.Name = updateResourceDto.Name;

            if (updateResourceDto.LocationId.HasValue)
                resource.LocationId = updateResourceDto.LocationId.Value;

            if (updateResourceDto.BuildingId.HasValue)
                resource.BuildingId = updateResourceDto.BuildingId.Value;

            if (updateResourceDto.FloorId.HasValue)
                resource.FloorId = updateResourceDto.FloorId.Value;

            if (updateResourceDto.IsUnderMaintenance.HasValue)
                resource.IsUnderMaintenance = updateResourceDto.IsUnderMaintenance.Value;

            if (updateResourceDto.BlockedFrom.HasValue)
                resource.BlockedFrom = updateResourceDto.BlockedFrom;

            if (updateResourceDto.BlockedUntil.HasValue)
                resource.BlockedUntil = updateResourceDto.BlockedUntil;

            if (updateResourceDto.BlockReason != null)
                resource.BlockReason = updateResourceDto.BlockReason;

            resource.UpdatedAt = DateTime.UtcNow;

            await _resourceRepository.UpdateAsync(resource);
            return MapToResponseDto(resource);
        }

        public async Task<bool> UpdateMaintenanceStatusAsync(int resourceId, MaintenanceStatusDto statusDto)
        {
            return await _resourceRepository.UpdateMaintenanceStatusAsync(resourceId, statusDto.IsUnderMaintenance);
        }

        public async Task<bool> BlockResourceAsync(int resourceId, BlockResourceDto blockDto)
        {
            return await _resourceRepository.BlockResourceAsync(resourceId, blockDto.BlockedFrom, blockDto.BlockedUntil, blockDto.BlockReason);
        }

        public async Task<bool> UnblockResourceAsync(int resourceId)
        {
            return await _resourceRepository.UnblockResourceAsync(resourceId);
        }

        public async Task<bool> DeleteResourceAsync(int resourceId)
        {
            await _resourceRepository.DeleteAsync(resourceId);
            return true;
        }

        private static ResourceResponseDto MapToResponseDto(Resource resource)
        {
            return new ResourceResponseDto
            {
                Id = resource.Id,
                Name = resource.Name,
                ResourceType = resource.ResourceType,
                LocationId = resource.LocationId,
                LocationAddress = resource.Location?.Address,  // Add this
                City = resource.Location?.City,                // Add this
                State = resource.Location?.State,              // Add this
                Country = resource.Location?.Country,
                LocationName = resource.Location?.Name,
                BuildingId = resource.BuildingId,
                BuildingName = resource.Building?.Name,
                FloorId = resource.FloorId,
                FloorName = resource.Floor?.FloorName,
                IsUnderMaintenance = resource.IsUnderMaintenance,
                IsBlocked = resource.IsBlocked,
                CreatedAt = resource.CreatedAt,
                UpdatedAt = resource.UpdatedAt
            };
        }

        private static ResourceDetailResponseDto MapToDetailResponseDto(Resource resource)
        {
            return new ResourceDetailResponseDto
            {
                Id = resource.Id,
                Name = resource.Name,
                ResourceType = resource.ResourceType,
                LocationId = resource.LocationId,
                LocationName = resource.Location?.Name,
                BuildingId = resource.BuildingId,
                BuildingName = resource.Building?.Name,
                FloorId = resource.FloorId,
                FloorName = resource.Floor?.FloorName,
                IsUnderMaintenance = resource.IsUnderMaintenance,
                IsBlocked = resource.IsBlocked,
                BlockedFrom = resource.BlockedFrom,
                BlockedUntil = resource.BlockedUntil,
                BlockReason = resource.BlockReason,
                CreatedAt = resource.CreatedAt,
                UpdatedAt = resource.UpdatedAt
            };
        }
    }
}