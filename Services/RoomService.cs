using ConferenceRoomBooking.DTOs.Room;
using ConferenceRoomBooking.Interfaces.IRepositories;
using ConferenceRoomBooking.Interfaces.IServices;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IResourceRepository _resourceRepository;

        public RoomService(IRoomRepository roomRepository, IResourceRepository resourceRepository)
        {
            _roomRepository = roomRepository;
            _resourceRepository = resourceRepository;
        }

        public async Task<RoomResponseDto> CreateRoomAsync(CreateRoomDto createRoomDto)
        {
            var room = new Room
            {
                ResourceId = createRoomDto.ResourceId,
                RoomName = createRoomDto.RoomName,
                Capacity = createRoomDto.Capacity,
                HasTV = createRoomDto.HasTV,
                HasWhiteboard = createRoomDto.HasWhiteboard,
                HasWiFi = createRoomDto.HasWiFi,
                HasProjector = createRoomDto.HasProjector,
                HasVideoConference = createRoomDto.HasVideoConference,
                HasAirConditioning = createRoomDto.HasAirConditioning
            };

            var createdRoom = await _roomRepository.AddAsync(room);
            return await MapToResponseDto(createdRoom);
        }

        public async Task<RoomResponseDto?> GetRoomByIdAsync(int roomId)
        {
            var room = await _roomRepository.GetByIdAsync(roomId);
            return room == null ? null : await MapToResponseDto(room);
        }

        public async Task<RoomResponseDto?> GetRoomByResourceIdAsync(int resourceId)
        {
            var room = await _roomRepository.GetRoomByResourceIdAsync(resourceId);
            return room == null ? null : await MapToResponseDto(room);
        }

        public async Task<IEnumerable<RoomResponseDto>> GetAllRoomsAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            var tasks = rooms.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<RoomResponseDto>> GetRoomsByLocationAsync(int locationId)
        {
            var rooms = await _roomRepository.GetRoomsByLocationAsync(locationId);
            var tasks = rooms.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<RoomResponseDto>> GetRoomsByBuildingAsync(int buildingId)
        {
            var rooms = await _roomRepository.GetRoomsByBuildingAsync(buildingId);
            var tasks = rooms.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<RoomResponseDto>> GetRoomsByFloorAsync(int floorId)
        {
            var rooms = await _roomRepository.GetRoomsByFloorAsync(floorId);
            var tasks = rooms.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<RoomResponseDto>> GetRoomsByCapacityAsync(int minCapacity)
        {
            var rooms = await _roomRepository.GetRoomsByCapacityAsync(minCapacity);
            var tasks = rooms.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<RoomResponseDto>> SearchRoomsWithAmenitiesAsync(RoomAmenityFilterDto filterDto)
        {
            var rooms = await _roomRepository.GetRoomsWithAmenitiesAsync(
                filterDto.HasTV ?? false,
                filterDto.HasWhiteboard ?? false,
                filterDto.HasWiFi ?? false,
                filterDto.HasProjector ?? false,
                filterDto.HasVideoConference ?? false,
                filterDto.HasAirConditioning ?? false);
            var tasks = rooms.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<RoomResponseDto>> GetAvailableRoomsAsync(RoomAvailabilityRequestDto requestDto)
        {
            var rooms = await _roomRepository.GetAvailableRoomsAsync(
                requestDto.LocationId, requestDto.Date, requestDto.StartTime, requestDto.EndTime);
            var tasks = rooms.Select(MapToResponseDto);
            return await Task.WhenAll(tasks);
        }

        public async Task<RoomResponseDto> UpdateRoomAsync(int roomId, UpdateRoomDto updateRoomDto)
        {
            var room = await _roomRepository.GetByIdAsync(roomId);
            if (room == null) throw new ArgumentException("Room not found");

            if (updateRoomDto.RoomName != null)
                room.RoomName = updateRoomDto.RoomName;

            if (updateRoomDto.Capacity.HasValue)
                room.Capacity = updateRoomDto.Capacity.Value;

            if (updateRoomDto.HasTV.HasValue)
                room.HasTV = updateRoomDto.HasTV.Value;

            if (updateRoomDto.HasWhiteboard.HasValue)
                room.HasWhiteboard = updateRoomDto.HasWhiteboard.Value;

            if (updateRoomDto.HasWiFi.HasValue)
                room.HasWiFi = updateRoomDto.HasWiFi.Value;

            if (updateRoomDto.HasProjector.HasValue)
                room.HasProjector = updateRoomDto.HasProjector.Value;

            if (updateRoomDto.HasVideoConference.HasValue)
                room.HasVideoConference = updateRoomDto.HasVideoConference.Value;

            if (updateRoomDto.HasAirConditioning.HasValue)
                room.HasAirConditioning = updateRoomDto.HasAirConditioning.Value;

            await _roomRepository.UpdateAsync(room);
            return await MapToResponseDto(room);
        }

        public async Task<bool> DeleteRoomAsync(int roomId)
        {
            await _roomRepository.DeleteAsync(roomId);
            return true;
        }

        private async Task<RoomResponseDto> MapToResponseDto(Room room)
        {
            var resource = await _resourceRepository.GetResourceWithDetailsAsync(room.ResourceId);

            return new RoomResponseDto
            {
                Id = room.Id,
                ResourceId = room.ResourceId,
                RoomName = room.RoomName,
                Capacity = room.Capacity,
                HasTV = room.HasTV,
                HasWhiteboard = room.HasWhiteboard,
                HasWiFi = room.HasWiFi,
                HasProjector = room.HasProjector,
                HasVideoConference = room.HasVideoConference,
                HasAirConditioning = room.HasAirConditioning,
                LocationName = resource?.Location?.Name,
                BuildingName = resource?.Building?.Name,
                FloorName = resource?.Floor?.FloorName,
                IsUnderMaintenance = resource?.IsUnderMaintenance ?? false,
                IsBlocked = resource?.IsBlocked ?? false
            };
        }
    }
}