
using itinera_io_backend.Models.Enums;

namespace itinera_io_backend.Models{
    public class NotificationModel{
        public int Id{get;set;}
        public int UserId{get;set;}
        public NotificationTypeEnum Type{get;set;}
        public int ReferenceId {get;set;}
        public string ReferenceTable{get;set;}
        public bool IsRead{get;set;} = false;
        public DateTime CreatedDate{get;set;}= DateTime.UtcNow;
    }

}