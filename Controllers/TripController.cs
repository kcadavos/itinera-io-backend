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

        [HttpGet("GetTripsByEmail/{email}")]

        public async Task<IActionResult> GetTripsByEmail(string email)
        {
            var trips = await _tripServices.GetTripsByEmailAsync(email);
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

        [HttpPut("UpdateVotingOpen")]
        public async Task<IActionResult> UpdateVotingOpen(int tripId, bool voteOpen)
        {
            var success = await _tripServices.UpdateVotingOpenAsync(tripId, voteOpen);
            if (success) return Ok(new { Success = "Trip vote open is updated" });
            else
                return BadRequest(new { Message = "Trip does not exist or trip vote open is not updated" });
        }

    }
}