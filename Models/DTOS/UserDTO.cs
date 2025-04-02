namespace itinera_io_backend.Models.DTOS
{
    //for logging in since we only need email and password
    public class UserDTO
    { public string? Email {get;set;}
        public string?  Password {get;set;}
        public string? Name{get;set;}
      
    }
}