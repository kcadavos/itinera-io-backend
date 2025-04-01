using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itinera_io_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace itinera_io_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController
    {
        private readonly ActivityServices _activityServices;

        public ActivityController (ActivityServices activityServices)
        {
            _activityServices = activityServices;
        }
    }
}