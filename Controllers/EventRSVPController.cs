using ConferenceRoomBooking.Interfaces.IServices;
using ConferenceRoomBooking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceRoomBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EventRSVPController : ControllerBase
    {
        private readonly IEventRSVPService _eventRSVPService;

        public EventRSVPController(IEventRSVPService eventRSVPService)
        {
            _eventRSVPService = eventRSVPService;
        }

        [HttpPost("rsvp")]
        public async Task<IActionResult> AddUserRsvp([FromQuery] int eventId, [FromQuery] int userId, [FromQuery] string status)
        {
            try
            {
                if (eventId <= 0 || userId <= 0)
                    return BadRequest(new { message = "Invalid event ID or user ID" });

                if (string.IsNullOrWhiteSpace(status))
                    return BadRequest(new { message = "Status is required" });

                var result = await _eventRSVPService.AddUserRsvpAsync(eventId, userId, status);
                return result ? Ok(new { message = "RSVP added successfully" }) : BadRequest(new { message = "Failed to add RSVP" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding RSVP", error = ex.Message });
            }
        }

        [HttpPut("rsvp")]
        public async Task<IActionResult> UpdateUserRsvp([FromQuery] int eventId, [FromQuery] int userId, [FromQuery] string status)
        {
            try
            {
                if (eventId <= 0 || userId <= 0)
                    return BadRequest(new { message = "Invalid event ID or user ID" });

                if (string.IsNullOrWhiteSpace(status))
                    return BadRequest(new { message = "Status is required" });

                var result = await _eventRSVPService.UpdateUserRsvpAsync(eventId, userId, status);
                return result ? Ok(new { message = "RSVP updated successfully" }) : BadRequest(new { message = "Failed to update RSVP" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating RSVP", error = ex.Message });
            }
        }

        [HttpGet("user-rsvp")]
        public async Task<IActionResult> GetUserRsvp([FromQuery] int eventId, [FromQuery] int userId)
        {
            try
            {
                if (eventId <= 0 || userId <= 0)
                    return BadRequest(new { message = "Invalid event ID or user ID" });

                var rsvp = await _eventRSVPService.GetUserRsvpAsync(eventId, userId);
                return rsvp == null ? NotFound(new { message = "RSVP not found" }) : Ok(rsvp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving user RSVP", error = ex.Message });
            }
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetRsvpsByEvent(int eventId)
        {
            try
            {
                if (eventId <= 0)
                    return BadRequest(new { message = "Invalid event ID" });

                var rsvps = await _eventRSVPService.GetRsvpsByEventAsync(eventId);
                return Ok(rsvps);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving RSVPs by event", error = ex.Message });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetRsvpsByUser(int userId)
        {
            try
            {
                if (userId <= 0)
                    return BadRequest(new { message = "Invalid user ID" });

                var rsvps = await _eventRSVPService.GetRsvpsByUserAsync(userId);
                return Ok(rsvps);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving RSVPs by user", error = ex.Message });
            }
        }

        [HttpGet("event/{eventId}/interested/count")]
        public async Task<IActionResult> GetInterestedCount(int eventId)
        {
            try
            {
                if (eventId <= 0)
                    return BadRequest(new { message = "Invalid event ID" });

                var count = await _eventRSVPService.GetInterestedCountAsync(eventId);
                return Ok(new { eventId = eventId, interestedCount = count });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving interested count", error = ex.Message });
            }
        }

        [HttpGet("event/{eventId}/not-interested/count")]
        public async Task<IActionResult> GetNotInterestedCount(int eventId)
        {
            try
            {
                if (eventId <= 0)
                    return BadRequest(new { message = "Invalid event ID" });

                var count = await _eventRSVPService.GetNotInterestedCountAsync(eventId);
                return Ok(new { eventId = eventId, notInterestedCount = count });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving not interested count", error = ex.Message });
            }
        }

        [HttpGet("event/{eventId}/maybe/count")]
        public async Task<IActionResult> GetMaybeCount(int eventId)
        {
            try
            {
                if (eventId <= 0)
                    return BadRequest(new { message = "Invalid event ID" });

                var count = await _eventRSVPService.GetMaybeCountAsync(eventId);
                return Ok(new { eventId = eventId, maybeCount = count });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving maybe count", error = ex.Message });
            }
        }
    }
}