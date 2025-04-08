using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using itinera_io_backend.Context;
using itinera_io_backend.Models;
using itinera_io_backend.Models.DTOS;
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


        // for generating itinerary

           private async Task<int> GetTripDurationInDays(int tripId)
        {
           var trip=  await _dataContext.Trip.SingleOrDefaultAsync(trip=> trip.Id==tripId);
            return trip.EndDate.DayNumber - trip.StartDate.DayNumber + 1;
        }
        public async Task <List <ActivityVoteCountDTO>> GetTotalVotesByTripId(int tripId)
        {
            List <ActivityVoteCountDTO> ActivityVoteCountList = new();
            
            var activities= await GetActivitiesByTripIdAsync(tripId);

            foreach (var activity in activities)
            {
                ActivityVoteCountDTO activityItem = new();
                activityItem.ActivityId =activity.Id;
                activityItem.TotalYes = activity.VoteYes.Count; 
                ActivityVoteCountList.Add(activityItem);
            }

            return ActivityVoteCountList;

        }

        public async Task <List<ActivityModel>> GetTopActivitiesBasedOnTripDuration (int tripId){
           
            int tripDuration = await GetTripDurationInDays(tripId);
            int totalActivityCountForItinerary = tripDuration * 3; //3 is the total count of activities per day


            return [];
        }
       
    }
}