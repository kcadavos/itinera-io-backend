
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

        [HttpPatch("AddVote")]
        public async Task<IActionResult> AddVote(int activityId,string email,string voteType)
        {
            var success = await _activityServices.AddVoteAsync(activityId, email,voteType);
            if (success)
            return Ok(new {Success="Vote added"});
            else
            return BadRequest(new {Message ="Error adding a vote.Activity Id doesn't exist or Invalid VoteType, use only yes or no values"});
        }
       
        [HttpPatch("RemoveVote")]
        public async Task<IActionResult> RemoveVote(int activityId,string email,string voteType)
        {
            var success = await _activityServices.RemoveVoteAsync(activityId, email,voteType);
            if (success)
            return Ok(new {Success="Vote removed"});
            else
            return BadRequest(new {Message ="Error removing a vote.Activity Id doesn't exist or Invalid VoteType, use only yes or no values"});
        }
    }
}