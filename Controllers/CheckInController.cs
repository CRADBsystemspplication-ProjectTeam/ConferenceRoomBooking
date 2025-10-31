using ConferenceRoomBooking.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConferenceRoomBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CheckInController : ControllerBase
    {
        private readonly IBookingCheckInService _checkInService;

        public CheckInController(IBookingCheckInService checkInService)
        {
            _checkInService = checkInService;
        }

        [HttpPost("checkin/{bookingId}")]
        public async Task<IActionResult> CheckIn(int bookingId)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                var result = await _checkInService.CheckInAsync(bookingId, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("checkout/{bookingId}")]
        public async Task<IActionResult> CheckOut(int bookingId)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                var result = await _checkInService.CheckOutAsync(bookingId, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("can-checkin/{bookingId}")]
        public async Task<IActionResult> CanCheckIn(int bookingId)
        {
            var result = await _checkInService.CanCheckInAsync(bookingId);
            return Ok(new { canCheckIn = result });
        }

        [HttpGet("can-checkout/{bookingId}")]
        public async Task<IActionResult> CanCheckOut(int bookingId)
        {
            var result = await _checkInService.CanCheckOutAsync(bookingId);
            return Ok(new { canCheckOut = result });
        }

        [HttpGet("status/{bookingId}")]
        public async Task<IActionResult> GetCheckInStatus(int bookingId)
        {
            var result = await _checkInService.GetCheckInStatusAsync(bookingId);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetCheckInHistory()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var result = await _checkInService.GetUserCheckInHistoryAsync(userId);
            return Ok(result);
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var result = await _checkInService.GetCheckInStatisticsAsync(userId);
            return Ok(result);
        }
    }
}