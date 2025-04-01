using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// for returning full user info
namespace itinera_io_backend.Models.DTOS
{
    public class UserInfoDTO
    {
        public int Id{get;set;}
        public string? Email{get; set;}
        public string? Name{get;set;}
        
    }
}