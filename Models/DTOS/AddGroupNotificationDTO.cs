using itinera_io_backend.Models.Enums;

namespace itinera_io_backend.Models.DTOS
{
    public class AddGroupNotificationDTO
    {
        public List <int> UserId{get;set;}
        public NotificationTypeEnum Type{get;set;}
        public int ReferenceId {get;set;}
        public string ReferenceTable{get;set;}
        
    }
}