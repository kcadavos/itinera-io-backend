using itinera_io_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace itinera_io_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
        private readonly TripServices _tripServices;

        public  TripController (TripServices tripServices)
        {
            _tripServices= tripServices;
        }
    }
}