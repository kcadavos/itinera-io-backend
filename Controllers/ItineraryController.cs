using itinera_io_backend.Models.DTOS;
using itinera_io_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using itinera_io_backend.Models.Enums;

namespace itinera_io_backend.Controllers
{   
    [ApiController]
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

 
        [HttpGet("GetActivityVoteCount/{tripId}")]
        public async Task<IActionResult> GetActivityVoteCount(int tripId )
        {
            var activities = await _itineraryServices.GetActivityVoteCountByTripIdAsync(tripId);
            if (activities!=null)
            return Ok(activities);
            else 
            return BadRequest (new {Message = "Invalid Trip Id"});
        }

       [HttpPost("GenerateAndSaveItinerary")]
        public async Task<IActionResult> GenerateAndSaveItinerary([FromBody] ItineraryRequestDTO request )
        {
            var result = await _itineraryServices.GenerateAndSaveItineraryAsync(request); 
            switch(result)
            {

                case  ItineraryGenerationResultEnum.Success:
                    return Ok("Itinerary generated successfully."); // returns 200 OK

                case ItineraryGenerationResultEnum.NotEnoughActivities:
                    return BadRequest("Not enough activities to generate itinerary."); // returns 400  bad request
                
                case ItineraryGenerationResultEnum.SaveFailed:
                    return StatusCode(500, "Failed to save itinerary.");
                
                 case ItineraryGenerationResultEnum.VotingStatusUpdateFailed:
                    return  StatusCode(500, "Failed to update trip voting status.Voting Status is already closed.");

                default:  return StatusCode(500, "Unknown error.");

            }
        }
    
    }


}
