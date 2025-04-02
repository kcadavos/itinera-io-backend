using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List <TripModel>> GetTripsByEmailAsync (string email)=> await _dataContext.Trip.Where(trip => trip.Participants.Contains(email)).ToListAsync();

        public async Task<bool> AddTripAsync (TripModel trip)
        {
            await _dataContext.Trip.AddAsync(trip);
            return await _dataContext.SaveChangesAsync()!=0;
        }
        
    }
}