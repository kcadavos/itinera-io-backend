using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itinera_io_backend.Context;

namespace itinera_io_backend.Services
{
    public class TripServices
    {
        private readonly DataContext _dataContext;

        public TripServices (DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        
    }
}