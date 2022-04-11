using getbiz_chat_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Custom_Member_Permissions_For_User_Id
{
   public  interface ICustomMemberPermissionsForUserIdRepository
    {
        Response UpdateCustomMemberPermissionsForUserId(custom_member_permissions_for_user_id obj_custom_member_permissions_for_user_id);
        Response GetChatIdCustomMemberPermissionsForUserId(string CustId, Int64 ChatId, Int64 UserId);
    }
}
