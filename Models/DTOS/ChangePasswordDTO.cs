
namespace itinera_io_backend.Models.DTOS
{
    public class ChangePasswordDTO
    {
        public int UserId{get; set;}
        public string? OldPassword {get;set;}
        public string? NewPassword{get;set;}
        
    }
}