using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using itinera_io_backend.Context;
using itinera_io_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace itinera_io_backend.Services
{
    public class TripServices
    {
        private readonly DataContext _dataContext;

        public TripServices (DataContext dataContext)
        {
            _dataContext= dataContext;
        }

        //get trips based on the user email
        public async Task<List <TripModel>> GetTripsByUserIdAsync (int id)
        {

           return await _dataContext.Trip.Where(trip => trip.ParticipantsId != null && trip.ParticipantsId.Contains(id) || trip.OwnerId== id)
                        .OrderBy(trip => trip.StartDate) // sort by soonest to latest
                        .ToListAsync();
            
       
        }
         //get trip based on the tripId
        public async Task <TripModel> GetTripDetailsAsync (int id)
        {
        
           return await _dataContext.Trip.SingleOrDefaultAsync(trip => trip.Id == id);
        
        }

        public async Task<bool> AddTripAsync (TripModel trip)
        {
            await _dataContext.Trip.AddAsync(trip);
            return await _dataContext.SaveChangesAsync()!=0;
        }

           public async Task<int> AddTripAsyncReturnTripId (TripModel trip)
        {
            await _dataContext.Trip.AddAsync(trip);
            var result = await _dataContext.SaveChangesAsync();
            return result!=0 ? trip.Id : 0;
        }

        public async Task<bool> EditTripAsync(TripModel trip){
            var tripToEdit = await GetTripInfo(trip.Id);
            if(tripToEdit== null) return false;

            tripToEdit.Destination= trip.Destination;
            tripToEdit.StartDate = trip.StartDate;
            tripToEdit.EndDate=trip.EndDate;
            tripToEdit.ParticipantsId= trip.ParticipantsId;

            _dataContext.Trip.Update(tripToEdit);
           return await _dataContext.SaveChangesAsync()!=0;
        }

        public async Task<bool> UpdateVotingStatusAsync (TripStatusDTO tripVoteStatus)
        {
            var trip =await _dataContext.Trip.FindAsync(tripVoteStatus.TripId);
            
            if (trip ==null ) 
            return false;
            else{
                trip.isVotingOpen = tripVoteStatus.IsVoteOpen;
                return await _dataContext.SaveChangesAsync()!=0;
                    
            }
        }

        public async Task<TripModel> GetTripInfo (int tripId)
        {
            return await _dataContext.Trip.FindAsync(tripId);
            
    
        }
     
        
    }
}