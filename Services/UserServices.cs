using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itinera_io_backend.Context;

namespace itinera_io_backend.Services
{
    public class UserServices
    {
        private readonly DataContext _dataContext;

        public UserServices(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        
    }
}