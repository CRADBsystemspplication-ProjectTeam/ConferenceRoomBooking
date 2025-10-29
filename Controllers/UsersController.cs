using ConferenceRoomBooking.DTOs.User;
using ConferenceRoomBooking.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceRoomBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            var user = await _userService.CreateUserAsync(dto);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto dto)
        {
            await _userService.UpdateUserAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpGet("search")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SearchUsers([FromQuery] string keyword)
        {
            var users = await _userService.SearchUsersAsync(keyword);
            return Ok(users);
        }

        [HttpGet("location/{locationId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsersByLocation(int locationId)
        {
            var users = await _userService.GetUsersByLocationAsync(locationId);
            return Ok(users);
        }

        [HttpGet("department/{departmentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsersByDepartment(int departmentId)
        {
            var users = await _userService.GetUsersByDepartmentAsync(departmentId);
            return Ok(users);
        }

        [HttpGet("profile/{userId}")]
        public async Task<IActionResult> GetProfile(int userId)
        {
            var profile = await _userService.GetProfileAsync(userId);
            return profile == null ? NotFound() : Ok(profile);
        }

        [HttpPut("profile/{userId}")]
        public async Task<IActionResult> UpdateProfile(int userId, [FromBody] UpdateProfileDto dto)
        {
            await _userService.UpdateProfileAsync(userId, dto);
            return NoContent();
        }
    }
}