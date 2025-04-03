using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itinera_io_backend.Context;
using itinera_io_backend.Models;
using itinera_io_backend.Models.DTOS;
using Microsoft.EntityFrameworkCore;

namespace itinera_io_backend.Services
{
    public class ItineraryServices
    {
        private readonly DataContext _dataContext;

        public ItineraryServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ItineraryModel>> GetItinerariesByTripIdAsync(int tripId)=> await _dataContext.Itinerary.Where(itinerary =>itinerary.TripId==tripId).ToListAsync();

        public async Task<bool> AddItineraryAsync(ItineraryModel itinerary)
        {
            await _dataContext.Itinerary.AddAsync(itinerary);
            return await _dataContext.SaveChangesAsync()!=0;

        }      
    }
}