namespace itinera_io_backend.Models
{
    public class UserModel
    {
        public int Id{get;set;}
        public string? Email {get;set;}

        public string? Name {get;set;}
        public string? Salt {get;set;}
        public string? Hash {get;set;}

    }
}