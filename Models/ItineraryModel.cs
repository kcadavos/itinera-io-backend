
namespace itinera_io_backend.Models.DTOS
{
    public class ItineraryModel
    {
        public int Id{get;set;}
        public int TripId{get;set;} // connects to trip TripModel
        public int DayNumber{get;set;} 
        public int FirstActivityId{get;set;}  // connects to ActivityModel 
        public int SecondActivityId{get;set;} // connects to ActivityModel
        public int ThirdActivityId{get;set;}        // connects to ActivityModel
    }
}