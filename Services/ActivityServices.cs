
using System.Diagnostics;
using itinera_io_backend.Context;
using itinera_io_backend.Models;
using itinera_io_backend.Models.DTOS;
using Microsoft.EntityFrameworkCore;

namespace itinera_io_backend.Services
{
    public class ActivityServices
    {
        private readonly DataContext _dataContext;
       

        public ActivityServices(DataContext dataContext,TripServices tripService)
        {
            _dataContext= dataContext;
            
          
        }
        
        public async Task<List <ActivityModel>> GetActivitiesByTripIdAsync (int tripId)=> await _dataContext.Activity.Where(activity => activity.TripId==tripId).ToListAsync();
        
        public async Task<List <ActivityModel>> GetUndecidedActivitiesByTripIdAndUserIdAsync (int tripId,int userId)
        {

          return await _dataContext.Activity.Where(activity => activity.TripId ==tripId &&  !activity.VoteNo.Contains(userId) && !activity.VoteYes.Contains(userId)).ToListAsync();

        }

        public async Task<List <ActivityModel>> GetLikedActivitiesByTripIdAndUserIdAsync (int tripId,int userId)
        {

          return await _dataContext.Activity.Where(activity => activity.TripId ==tripId && activity.VoteYes.Contains(userId)).ToListAsync();

        }
        public async Task<List <ActivityModel>> GetDisLikedActivitiesByTripIdAndUserIdAsync (int tripId,int userId)
        {

          return await _dataContext.Activity.Where(activity => activity.TripId ==tripId && activity.VoteNo.Contains(userId)).ToListAsync();

        }

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