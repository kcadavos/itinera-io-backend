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
        public async Task<List <TripModel>> GetTripsByUserIdAsync (int id)=> await _dataContext.Trip.Where(trip => trip.ParticipantsId != null && trip.ParticipantsId.Contains(id) || trip.OwnerId== id).ToListAsync();

        public async Task<bool> AddTripAsync (TripModel trip)
        {
            await _dataContext.Trip.AddAsync(trip);
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

        
        
    }
}