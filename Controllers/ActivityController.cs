
using itinera_io_backend.Models;
using itinera_io_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace itinera_io_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController: ControllerBase
    {
        private readonly ActivityServices _activityServices;

        public ActivityController (ActivityServices activityServices)
        {
            _activityServices = activityServices;
        }

        [HttpGet("GetActivitiesByTripId/{id}")]
        public async Task<IActionResult> GetActivitiesByTripId(int id)
        {
            var activities = await _activityServices.GetActivitiesByTripIdAsync(id);
            if (activities !=null)
                return Ok(activities);
               
                return BadRequest (new {Message="no activities found"});

        }

        [HttpPost("AddActivity")]
        public async Task<IActionResult> AddActivity(ActivityModel activity)
        {
           var success = await _activityServices.AddActivityAsync(activity);
           if(success) return Ok(new {Success=true});
           return BadRequest (new {Message ="activity not added"});

        }

        [HttpPatch("UpdateVote")]
        public async Task<IActionResult> UpdateVoteYes(int activityId,string email,string voteType)
        {
            var success = await _activityServices.UpdateVoteAsync(activityId, email,voteType);
            if (success)
            return Ok(new {Success="Vote updated"});
            else
            return BadRequest(new {Message ="Error updating Votes.Activity Id doesn't exist or Invalid VoteType, use only yes or no values"});
        }
       
    }
}