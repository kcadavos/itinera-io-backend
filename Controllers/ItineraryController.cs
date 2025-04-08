using itinera_io_backend.Models.DTOS;
using itinera_io_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace itinera_io_backend.Controllers
{   [ApiController]
    [Route("[controller]")]
    public class ItineraryController: ControllerBase
    {
        private readonly ItineraryServices _itineraryServices;

        public ItineraryController (ItineraryServices itineraryServices)
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
    }
}