using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using itinera_io_backend.Context;
using itinera_io_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace itinera_io_backend.Services
{
    public class ActivityServices
    {
        private readonly DataContext _dataContext;

        public ActivityServices(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        
        public async Task<List <ActivityModel>> GetActivitiesByTripIdAsync (int tripId)=> await _dataContext.Activity.Where(activity => activity.TripId==tripId).ToListAsync();
        public async Task<bool> AddActivityAsync (ActivityModel activity)
        {
            await _dataContext.Activity.AddAsync(activity);
            return await _dataContext.SaveChangesAsync()!=0;
        }

        // adds the user  to Vote Yes Or No List
        public async Task<bool> AddVoteAsync(ActivityVoteDTO activityVote)
        {
            var trip = await _dataContext.Activity.FindAsync(activityVote.ActivityId);
            if (trip==null)
            return false;
            else{
            if (activityVote.VoteType.ToLower()=="yes" && !trip.VoteYes.Contains(activityVote.UserId))
                 trip.VoteYes.Add(activityVote.UserId);
            if (activityVote.VoteType.ToLower() =="no" && !trip.VoteNo.Contains(activityVote.UserId))
                 trip.VoteNo.Add(activityVote.UserId);
            return await _dataContext.SaveChangesAsync()!=0;
            }
           
        }

        // removes the user  to Vote Yes Or No List
        public async Task<bool> RemoveVoteAsync(ActivityVoteDTO activityVote)
        {
            var trip = await _dataContext.Activity.FindAsync(activityVote.ActivityId);
           
            if (activityVote.VoteType.ToLower()=="yes") trip.VoteYes.Remove(activityVote.UserId);
            if (activityVote.VoteType.ToLower() =="no") trip.VoteNo.Remove(activityVote.UserId);
            return await _dataContext.SaveChangesAsync()!=0;
           
        }
    }
}