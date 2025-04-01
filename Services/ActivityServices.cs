using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itinera_io_backend.Context;

namespace itinera_io_backend.Services
{
    public class ActivityServices
    {
        private readonly DataContext _dataContext;

        public ActivityServices(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        
    }
}