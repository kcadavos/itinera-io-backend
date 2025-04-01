
using itinera_io_backend.Models;
using itinera_io_backend.Models.DTOS;
using Microsoft.EntityFrameworkCore;

namespace itinera_io_backend.Context
{
    public class DataContext: DbContext
    {
        public DataContext (DbContextOptions options):base(options)
        {

        }

        // tables
        public DbSet<UserModel> User{get;set;}
        public DbSet<TripModel> Trip {get;set;}
        public DbSet<ActivityModel> Activity {get;set;}
        public DbSet<ItineraryModel> Itinerary {get;set;}
        
    }
}