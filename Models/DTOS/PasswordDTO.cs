
namespace itinera_io_backend.Models.DTOS
{
    public class PasswordDTO
    {
        public string? Salt {get;set;}
        public string? Hash{get;set;}
        
    }
}