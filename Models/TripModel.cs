
namespace itinera_io_backend.Models
{
    public class TripModel
    {
        public int Id{get;set;}
        
        public string? Destination{get;set;}

        public DateOnly StartDate{get;set;}

        public DateOnly EndDate{get;set;}

        public List<string>? Participants{get;set;}

        public bool isVotingOpen{get;set;}
    }
}