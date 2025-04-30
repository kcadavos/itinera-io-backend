

namespace itinera_io_backend.Models.DTOS
{
    public class ItineraryActivityDetailDTO
    {
      
        public DateOnly ItineraryDate {get;set;}
        public string? Activity{get;set;}

        public string? Category{get;set;}

        public string? Address {get;set;}

        public string? Details{get;set;}


    }
}