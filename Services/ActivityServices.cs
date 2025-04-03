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

        public async Task<bool> UpdateVoteAsync(int activityId,string email,string voteType)
        {
            var trip = await _dataContext.Activity.FindAsync(activityId);
           
            if (voteType.ToLower()=="yes") trip.VoteYes.Add(email);
            if (voteType.ToLower() =="no") trip.VoteNo.Add(email);
            return await _dataContext.SaveChangesAsync()!=0;
           
        }
    }
}