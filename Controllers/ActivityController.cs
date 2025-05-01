
using itinera_io_backend.Models;
using itinera_io_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace itinera_io_backend.Controllers
{   

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ActivityController: ControllerBase
    {
        private readonly ActivityServices _activityServices;

        public ActivityController (ActivityServices activityServices)
        {
            _activityServices = activityServices;
        }

        [HttpGet("GetActivities/{tripId}")]
        public async Task<IActionResult> GetActivities(int tripId)
        {
            var activities = await _activityServices.GetActivitiesByTripIdAsync(tripId);
            if (activities !=null && activities.Any())
                return Ok(activities);
            else
                return BadRequest (new {Message="no activities found"});

        }

        [HttpGet("GetUndecidedActivities/{userId}/{tripId}")]
        public async Task<IActionResult> GetUndecidedActivitiesByTripIdAndUserId(int tripId, int userId)
        {
            var activities = await _activityServices.GetUndecidedActivitiesByTripIdAndUserIdAsync(tripId,userId);

            if (activities !=null && activities.Any())
                return Ok (activities);
            else
                return BadRequest (new {Message="no undecided activities found"}); 
        }

        [HttpGet("GetLikedActivities/{userId}/{tripId}")]
        public async Task<IActionResult> GetLikedActivitiesByTripIdAndUserId(int tripId, int userId)
        {
            var activities = await _activityServices.GetLikedActivitiesByTripIdAndUserIdAsync(tripId,userId);

            if (activities !=null && activities.Any())
                return Ok (activities);
            else
                return BadRequest (new {Message="no liked activities found"}); 
        }

        [HttpGet("GetDislikedActivities/{userId}/{tripId}")]
        public async Task<IActionResult> GetDislikedActivitiesByTripIdAndUserId(int tripId, int userId)
        {
            var activities = await _activityServices.GetDisLikedActivitiesByTripIdAndUserIdAsync(tripId,userId);

            if (activities !=null && activities.Any())
                return Ok (activities);
            else
                return BadRequest (new {Message="no disliked activities found"}); 
        }

        [HttpPost("AddActivity")]
        public async Task<IActionResult> AddActivity(ActivityModel activity)
        {
           var success = await _activityServices.AddActivityAsync(activity);
           if(success) return Ok(new {Success=true});
           return BadRequest (new {Message ="activity not added"});

        }

        [HttpPatch("AddVote")]
        public async Task<IActionResult> AddVote([FromBody] ActivityVoteDTO activityVote)
        {
            var success = await _activityServices.AddVoteAsync(activityVote);
            if (success)
            return Ok(new {Success="Vote added"});
            else
            return BadRequest(new {Message ="Error adding a vote.Activity Id doesn't exist or Invalid VoteType, use only yes or no values"});
        }
       
        [HttpPatch("RemoveVote")]
        public async Task<IActionResult> RemoveVote([FromBody] ActivityVoteDTO activityVote)
        {
            var success = await _activityServices.RemoveVoteAsync(activityVote);
            if (success)
            return Ok(new {Success="Vote removed"});
            else
            return BadRequest(new {Message ="Error removing a vote.Activity Id doesn't exist or Invalid VoteType, use only yes or no values"});
        }

      
    }
}