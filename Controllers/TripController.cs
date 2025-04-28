using itinera_io_backend.Models;
using itinera_io_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace itinera_io_backend.Controllers
{  
    [ApiController]
    [Route("[controller]")]
    [Authorize]
   
    public class TripController : ControllerBase
    {
        private readonly TripServices _tripServices;

        public TripController(TripServices tripServices)
        {
            _tripServices = tripServices;
        }

        [HttpGet("GetTripsByUserId/{userId}")]
        public async Task<IActionResult> GetTripsByUserId(int userId)
        {
            var trips = await _tripServices.GetTripsByUserIdAsync(userId);
            if (trips != null && trips.Any()) // checks if the list contains anything
                return Ok(trips);
            else
               return BadRequest(new{ Message = "No trips available" });
            
        }

        [HttpPost("AddTrip")]
        public async Task<IActionResult> AddTrip(TripModel trip)
        {
            var success = await _tripServices.AddTripAsync(trip);
            if (success) return Ok(new { Success = true });
            else
                return BadRequest(new { Message = "Trip  not added." });
        }

        [HttpPost("AddTripReturnTripId")]
        public async Task<IActionResult> AddTripReturnTripId(TripModel trip)
        {
            var tripId = await _tripServices.AddTripAsyncReturnTripId(trip);
            if (tripId>0) return Ok(tripId);
            else
                return BadRequest(new { Message = "Trip  not added." });
        }

        [HttpPatch("UpdateVotingStatus")]
        public async Task<IActionResult> UpdateVotingOpen([FromBody] TripStatusDTO tripVoteStatus)
        {
            var success = await _tripServices.UpdateVotingStatusAsync(tripVoteStatus);
            if (success) return Ok(new { Success = "Trip vote open is updated" });
            else
                return BadRequest(new { Message = "Trip does not exist   or trip vote open is not updated" });
        }

        [HttpPut("EditTrip")]
        public async Task<IActionResult> EditTrip([FromBody] TripModel trip)
        {
            var success = await _tripServices.EditTripAsync(trip);

            if (success) return Ok(new { Success = true });

            return BadRequest(new { Message = "No trip was edited" });
        }

    }
}