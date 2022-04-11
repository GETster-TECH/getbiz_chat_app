using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Users_Userapp_Blocked_User_List
{
    public class UsersUserAppBlockedUserListRepository : IUsersUserAppBlockedUserListRepository
    {
        public Response UpdateUsersUserAppBlockedUserList(userapp_blocked_user_list obj_blocked_user_list)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateUsersUserAppBlockedUserList(obj_blocked_user_list);
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
