using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.User_Userapp_Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUserAppNotificationController : ControllerBase
    {

        private readonly IUserUserAppNotificationRepository _userUserappNotificationRepository;
        public UserUserAppNotificationController(IUserUserAppNotificationRepository userUserappNotificationRepository)
        {
            _userUserappNotificationRepository = userUserappNotificationRepository;
        }


        [HttpPut]
        [Route("api/UpdateUserUserAppNotifications")]
        public IActionResult UpdateUserUserAppNotifications(user_userapp_notification obj_userapp_notifications)
        {
            try
            {

                var messages = _userUserappNotificationRepository.UpdateUserUserAppNotifications(obj_userapp_notifications);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
