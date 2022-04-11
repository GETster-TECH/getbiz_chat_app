using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Userapp_Saved_Messages
{
    public class UserAppSavedMessagesRepository : IUserAppSavedMessagesRepository
    {
        public Response AddUserAppSavedMessages(userapp_saved_messages obj_saved_messages)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddUserAppSavedMessages(obj_saved_messages);
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
