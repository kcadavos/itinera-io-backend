
using System.Diagnostics;
using itinera_io_backend.Context;
using itinera_io_backend.Models;
using itinera_io_backend.Models.DTOS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace itinera_io_backend.Services
{
    public class ActivityServices
    {
        private readonly DataContext _dataContext;
        private readonly TripServices _tripService;
        public ActivityServices(DataContext dataContext,TripServices tripService)
        {
            _dataContext= dataContext;
            _tripService= tripService;
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
            return ((trip.EndDate.DayNumber - trip.StartDate.DayNumber) + 1);
        }
        public async Task <List <ActivityVoteCountDTO>> GetActivityVoteCountByTripIdAsync(int tripId)
        {
          
            List <ActivityVoteCountDTO> ActivityVoteCountList = new();
            
            
            var activities= await GetActivitiesByTripIdAsync(tripId);
            
         

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

        public async Task <List<ItineraryModel>> GenerateItineraryAsync (int tripId){
   
            const int numberOfActivitiesPerDay =3;  //3 is the total count of activities per day
            int tripDuration = await GetTripDurationInDays(tripId);
            int totalActivitiesNeeded = numberOfActivitiesPerDay * tripDuration;
            
            
            List <ActivityVoteCountDTO> activities= await GetActivityVoteCountByTripIdAsync(tripId); // returned vote count sorted by top votes

            List <ActivityVoteCountDTO> topActivities = activities.Take(totalActivitiesNeeded).ToList();

            //randomize the list so that it doesnt put all the Top most liked activities on day 1
            Random rng= new Random();
            topActivities= topActivities.OrderBy(a=>rng.Next()).ToList();

     
            
            List <ItineraryModel> itineraryList =new();
            for (int i =0;i<tripDuration; i++) //create itinerary based on how many days the trip duration is
            {
                  ItineraryModel itineraryItem= new();
                  itineraryItem.TripId =tripId;
                  itineraryItem.DayNumber= i+1;
                  itineraryItem.FirstActivityId = topActivities[i*numberOfActivitiesPerDay].ActivityId;
                  itineraryItem.SecondActivityId = topActivities[i*numberOfActivitiesPerDay+1].ActivityId;
                  itineraryItem.ThirdActivityId = topActivities[i*numberOfActivitiesPerDay+2].ActivityId;
                  itineraryList.Add(itineraryItem);
            }

            return itineraryList;
           
        }

        public async Task<List<ItineraryActivityDetailDTO>> GetActivityDetailsFromItineraryAsync(int tripId)
        {
            List <ItineraryModel> generatedItinerary = await GenerateItineraryAsync(tripId);
            TripModel tripDetail = await _tripService.GetTripInfo(tripId);

            // List <ActivityModel> itineraryActivityDetailList = new ();
            List <ItineraryActivityDetailDTO> intineraryActivityDetailList = new ();
            int dayCount = 0;

            foreach(var itineraryItem in generatedItinerary) // per day
            {   
                // retrieve - First Activity
                ActivityModel activityDetailItem1 = await _dataContext.Activity.SingleOrDefaultAsync(activity => activity.Id == itineraryItem.FirstActivityId);
                // only extract info needed
                ItineraryActivityDetailDTO itineraryActivityDetailitem1 = new();
                itineraryActivityDetailitem1.itineraryDate =tripDetail.StartDate.AddDays(dayCount);
                itineraryActivityDetailitem1.Activity = activityDetailItem1.Activity;
                itineraryActivityDetailitem1.Address = activityDetailItem1.Address;
                itineraryActivityDetailitem1.Category = activityDetailItem1.Category;
                itineraryActivityDetailitem1.Details = activityDetailItem1.Details;
                
                intineraryActivityDetailList.Add(itineraryActivityDetailitem1);// add filtered data to list to be returned


                // retrive - second activity
                 ActivityModel activityDetailItem2 = await _dataContext.Activity.SingleOrDefaultAsync(activity => activity.Id == itineraryItem.SecondActivityId);
                // only extract info needed
                ItineraryActivityDetailDTO itineraryActivityDetailitem2 = new();
                itineraryActivityDetailitem2.itineraryDate =tripDetail.StartDate.AddDays(dayCount);
                itineraryActivityDetailitem2.Activity = activityDetailItem2.Activity;
                itineraryActivityDetailitem2.Address = activityDetailItem2.Address;
                itineraryActivityDetailitem2.Category = activityDetailItem2.Category;
                itineraryActivityDetailitem2.Details = activityDetailItem2.Details;

                intineraryActivityDetailList.Add(itineraryActivityDetailitem2); // add filtered data to list to be returned

                 // retrive - third activity
                   ActivityModel activityDetailItem3 = await _dataContext.Activity.SingleOrDefaultAsync(activity => activity.Id == itineraryItem.SecondActivityId);
                
                // only extract info needed
                ItineraryActivityDetailDTO itineraryActivityDetailitem3 = new();
                itineraryActivityDetailitem3.itineraryDate =tripDetail.StartDate.AddDays(dayCount);
                itineraryActivityDetailitem3.Activity = activityDetailItem3.Activity;
                itineraryActivityDetailitem3.Address = activityDetailItem3.Address;
                itineraryActivityDetailitem3.Category = activityDetailItem3.Category;
                itineraryActivityDetailitem3.Details = activityDetailItem3.Details;

                intineraryActivityDetailList.Add(itineraryActivityDetailitem3); // add filtered data to list to be returned

                dayCount++;
            }

            return intineraryActivityDetailList;
        }

        
       
    }
}