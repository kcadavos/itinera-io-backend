
using Microsoft.AspNetCore.Mvc;
using itinera_io_backend.Models;
using itinera_io_backend.Models.DTOS;
using itinera_io_backend.Services;
using Microsoft.AspNetCore.Authorization;

namespace itinera_io_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class NotificationController : ControllerBase
    {
        private readonly NotificationServices _notificationServices;

        public NotificationController (NotificationServices notificationServices)
        {
            _notificationServices = notificationServices;
     
        }

        [HttpPost("AddNotification")]
        public async Task<IActionResult> AddNotification(AddNotificationDTO notification)
        {
            var success = await _notificationServices.AddNotificationAsync(notification);
            if (success) return Ok(new { Success = true });
            else
                return BadRequest(new { Message = "Notification  not added." });
        }

        [HttpPost("AddGroupNotification")]
        public async Task<IActionResult> AddNotification(AddGroupNotificationDTO notification)
        {
            var success = await _notificationServices.AddGroupNotificationAsync(notification);
            if (success) return Ok(new { Success = true });
            else
                return BadRequest(new { Message = "Group Notification  not added." });
        }

        [HttpGet("GetUnreadNotificationsByUserId")]
        public async Task<IActionResult> GetUnreadNotificationsByUserId(int userId)
        {
            var notificationList = await _notificationServices.GetUnreadNotificationsByUserIdAsync(userId);
            if (notificationList != null && notificationList.Any()) // checks if the list contains anything
                return Ok(notificationList);
            else
               return BadRequest(new{ Message = "No unread notifications" });
            
        }

        [HttpPatch("MarkNotificationAsRead")]
        public async Task<IActionResult> MarkNotificationAsRead(int notificationId)
        {
            var success = await _notificationServices.MarkNotificationAsReadAsync(notificationId);
            if (success) return Ok(new { Success = "Notification is mark as read" });
            else
                return BadRequest(new { Message = "Failed update. Notification is not marked as read" });
        }

    }
}