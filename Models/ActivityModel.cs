
namespace itinera_io_backend.Models
{
    public class ActivityModel
    {
        public int Id{get;set;}
        public int TripId{get;set;}

        public string? Activity{get;set;}

        public string? Category{get;set;}

        public string? Address {get;set;}

        public string? Details{get;set;}

        public List<string>? VoteYes{get;set;}

        public List<string>? VoteNo{get;set;}

    }
}