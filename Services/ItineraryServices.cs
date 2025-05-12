using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using itinera_io_backend.Context;
using itinera_io_backend.Models;
using itinera_io_backend.Models.DTOS;
using Microsoft.EntityFrameworkCore;
using itinera_io_backend.Models.Enums;

namespace itinera_io_backend.Services
{
    public class ItineraryServices
    {
        private readonly DataContext _dataContext;
        private readonly ActivityServices _activityService;
        private readonly TripServices _tripService;

        public ItineraryServices(DataContext dataContext, ActivityServices activityService,TripServices tripService)
        {
            _dataContext = dataContext;
            _activityService= activityService;
            _tripService = tripService;
        }

        public async Task<List<ItineraryModel>> GetItinerariesByTripIdAsync(int tripId)=> await _dataContext.Itinerary.Where(itinerary =>itinerary.TripId==tripId).ToListAsync();

        public async Task<bool> AddItineraryAsync(ItineraryModel itinerary)
        {
            await _dataContext.Itinerary.AddAsync(itinerary);
            return await _dataContext.SaveChangesAsync()!=0;

        }
        
        // for generating itinerary
           private async Task<int> GetTripDurationInDays(int tripId)
        {
           var trip=  await _dataContext.Trip.SingleOrDefaultAsync(trip=> trip.Id==tripId);
            return trip.EndDate.DayNumber - trip.StartDate.DayNumber + 1;
        }

        public async Task <List <ActivityVoteCountDTO>> GetActivityVoteCountByTripIdAsync(int tripId)
        {
          
            List <ActivityVoteCountDTO> ActivityVoteCountList = new();
            
            
            var activities= await _activityService.GetActivitiesByTripIdAsync(tripId);
            
         

            foreach (var activity in activities)
            {
                ActivityVoteCountDTO activityItem = new();
                activityItem.ActivityId =activity.Id;
                activityItem.TotalYes = activity.VoteYes.Count ; 
                ActivityVoteCountList.Add(activityItem);
            }

            Console.WriteLine("VOTE: "+ActivityVoteCountList.OrderByDescending(a=> a.TotalYes));
             return ActivityVoteCountList.OrderByDescending(a=> a.TotalYes).ToList(); // returns a sorted descending list by number of votes
        }

         public async Task <ItineraryGenerationResultEnum> GenerateAndSaveItineraryAsync (ItineraryRequestDTO request)
        {
   

            int tripDuration = await GetTripDurationInDays(request.TripId);
            int totalActivitiesNeeded = request.NumberOfActivitiesPerDay * tripDuration;
            
         
            
            
            List <ActivityVoteCountDTO> activities= await GetActivityVoteCountByTripIdAsync(request.TripId); // returned vote count sorted by top votes

            // if not enough activitiesLog or handle the issue
            if (activities.Count < totalActivitiesNeeded)
            {
             return ItineraryGenerationResultEnum.NotEnoughActivities;
            }

            List <ActivityVoteCountDTO> topActivities = activities.Take(totalActivitiesNeeded).ToList(); // limits to the total of activities needed to generate the itinerary based on the activity count per day

          
            //randomize the list so that it doesnt put all the Top most liked activities on day 1
            Random rng= new Random();
            topActivities= topActivities.OrderBy(a=>rng.Next()).ToList();

     
            
            List <ItineraryModel> itineraryList =new();
            for (int i =0;i<tripDuration; i++) //create itinerary based on how many days the trip duration is
            {
                  ItineraryModel itineraryItem= new();
                  itineraryItem.TripId =request.TripId;
                  itineraryItem.DayNumber= i+1;
                  itineraryItem.ActivityIds= new List<int>() ;
            
                  
                  for (int j =0;j<request.NumberOfActivitiesPerDay; j++) //push the amount activities needed per day
                    itineraryItem.ActivityIds.Add(topActivities[(i*request.NumberOfActivitiesPerDay)+j].ActivityId);
               
                
                itineraryList.Add(itineraryItem);

                  if (!await AddItineraryAsync(itineraryItem))
                    return ItineraryGenerationResultEnum.SaveFailed;

            }

            // close the voting once itinerary is generated
            if (!await _tripService.UpdateVotingStatusAsync(new TripStatusDTO 
            {TripId = request.TripId,
            IsVoteOpen=false}))
                return ItineraryGenerationResultEnum.VotingStatusUpdateFailed; // update voting failed

            return ItineraryGenerationResultEnum.Success;
           
        }
    
     

        
       
    }
}