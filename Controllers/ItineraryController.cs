using itinera_io_backend.Models.DTOS;
using itinera_io_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace itinera_io_backend.Controllers
{   [ApiController]
    [Route("[controller]")]
    [Authorize]
  
    public class ItineraryController: ControllerBase
    {
        private readonly ItineraryServices _itineraryServices;

        public ItineraryController (ItineraryServices itineraryServices, TripServices tripService)
        {
            _itineraryServices = itineraryServices;
     
        }

        [HttpGet("GetItinerariesByTripId/{tripId}")]
        public async Task<IActionResult> GetItinerariesByTripId(int tripId)
        {
            var itineraries = await _itineraryServices.GetItinerariesByTripIdAsync(tripId);
            if (itineraries!=null)
                return Ok(itineraries);
            else 
                return BadRequest(new {Message ="No itinerary found"});
        }

        [HttpPost("AddItinerary")]
        public async Task<IActionResult> AddItinerary(ItineraryModel itinerary)
        {
            bool success = await _itineraryServices.AddItineraryAsync(itinerary);
            if (success)
                return Ok(new {Success=true});
            else 
                return BadRequest (new {Message ="itinerary not added"});
        }

        [HttpPost("GenerateAndSaveItinerary")]
        public async Task<IActionResult> GenerateAndSaveItinerary([FromBody] ItineraryRequestDTO request )
        {
            var success = await _itineraryServices.GenerateAndSaveItineraryAsync(request); 
            if (success)
            return Ok(new {Success=true});
            else 
            return BadRequest (new {Message = "Invalid Trip Id"});
        }

        [HttpGet("GetActivityVoteCount/{tripId}")]
        public async Task<IActionResult> GetActivityVoteCount(int tripId )
        {
            var activities = await _itineraryServices.GetActivityVoteCountByTripIdAsync(tripId);
            if (activities!=null)
            return Ok(activities);
            else 
            return BadRequest (new {Message = "Invalid Trip Id"});
        }


 

        // [HttpGet("GetActivityDetailsFromItinerary/{tripId}")]
        // public async Task<IActionResult> GetActivityDetailsFromItinerary(int tripId)
        // {
        //     var itineraryDetails = await _itineraryServices.GetActivityDetailsFromItineraryAsync(tripId);
        //     if (itineraryDetails!=null && itineraryDetails.Any())
        //     return Ok(itineraryDetails);
        //     else 
        //         return BadRequest (new {Message ="intinerary details not retrieved"});
        // }
    }
}