using itinera_io_backend.Models.DTOS;
using itinera_io_backend.Models;
using itinera_io_backend.Context;
using Microsoft.EntityFrameworkCore;



namespace itinera_io_backend.Services
{
    public class NotificationServices
    {
        private readonly DataContext _dataContext;

        public NotificationServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddNotificationAsync(AddNotificationDTO notification)
        {
             var notificationToAdd = new NotificationModel
                {
                    UserId = notification.UserId,
                    Type = notification.Type,
                    ReferenceId = notification.ReferenceId,
                    ReferenceTable = notification.ReferenceTable
                  
                };
            await _dataContext.Notification.AddAsync(notificationToAdd );
            return await _dataContext.SaveChangesAsync() != 0;
        }
        

        public async Task<bool> AddGroupNotificationAsync(AddGroupNotificationDTO groupNotification)
        {
            foreach (int userId in groupNotification.UserId)
            {
                var notificationToAdd = new NotificationModel
                {
                    UserId = userId,
                    Type = groupNotification.Type,
                    ReferenceId = groupNotification.ReferenceId,
                    ReferenceTable = groupNotification.ReferenceTable
                };

                await _dataContext.Notification.AddAsync(notificationToAdd);
            }

            return await _dataContext.SaveChangesAsync() != 0;
        }

        public async Task<List<NotificationModel>> GetUnreadNotificationsByUserIdAsync(int userId)
        {
            return await _dataContext.Notification
                .Where(notification => notification.UserId == userId && !notification.IsRead)
                .OrderByDescending(notification => notification.CreatedDate)
                .ToListAsync();
        }
    
          public async Task<bool> MarkNotificationAsReadAsync ( int notificationId)
        {
            var notification =await _dataContext.Notification.FindAsync(notificationId);
            
            if (notification ==null ) 
            return false;
            else{
                notification.IsRead=true;
                return await _dataContext.SaveChangesAsync()!=0;
                    
            }
        }
        
        
    }
}
