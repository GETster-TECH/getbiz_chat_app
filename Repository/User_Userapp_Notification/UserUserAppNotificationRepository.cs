using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.User_Userapp_Notification
{
    public class UserUserAppNotificationRepository : IUserUserAppNotificationRepository
    {
        public Response UpdateUserUserAppNotifications(user_userapp_notification obj_userapp_notifications)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateUserUserAppNotifications(obj_userapp_notifications);
                response = result;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



    }
}
