using itinera_io_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace itinera_io_backend.Controllers
{   [ApiController]
    [Route("[controller]")]
    public class ItineraryController: ControllerBase
    {
        private readonly ItineraryServices _itineraryServices;

        public ItineraryController (ItineraryServices itineraryServices)
        {
            _itineraryServices = itineraryServices;
        }
    }
}