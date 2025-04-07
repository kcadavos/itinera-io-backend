using itinera_io_backend.Models;
using itinera_io_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace itinera_io_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // [Authorize]
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
            if (trips != null) return Ok(trips);
            else
                return BadRequest(new { Message = "No trips" }); // does not display , it always display an empty List
        }

        [HttpPost("AddTrip")]
        public async Task<IActionResult> AddTrip(TripModel trip)
        {
            var success = await _tripServices.AddTripAsync(trip);
            if (success) return Ok(new { Success = true });
            else
                return BadRequest(new { Message = "Trip  not added." });
        }

        [HttpPatch("UpdateVotingStatus")]
        public async Task<IActionResult> UpdateVotingOpen([FromBody] TripStatusDTO tripVoteStatus)
        {
            var success = await _tripServices.UpdateVotingStatusAsync(tripVoteStatus);
            if (success) return Ok(new { Success = "Trip vote open is updated" });
            else
                return BadRequest(new { Message = "Trip does not exist  trip vote open is not updated" });
        }

    }
}