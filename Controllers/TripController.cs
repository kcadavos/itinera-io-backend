using itinera_io_backend.Models;
using itinera_io_backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace itinera_io_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpPut("CloseVoting")]
        public async Task<IActionResult> CloseVoting(int tripId)
        {
            var success = await _tripServices.CloseVotingAsync(tripId);
            if (success) return Ok(new { Success = "Trip voting closed" });
            else
                return BadRequest(new { Message = "Trip does not exist" });
        }

    }
}