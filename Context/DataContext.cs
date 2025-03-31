
using itinera_io_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace itinera_io_backend.Context
{
    public class DataContext: DbContext
    {
        public DataContext (DbContextOptions options):base(options)
        {

        }

        public DbSet<UserModel> User{get;set;}
        public DbSet<TripModel> Trip {get;set;}
        
    }
}