using getbiz_chat_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Admin_Users_Permissions
{
    public interface IChatIdAdminUsersPermissionsRepository
    {
        Response UpdateChatIdAdminUsersPermissions(chat_id_admin_users_permissions obj_admin_users_permissions);
        Response GetChatIdAdminUsersPermissions(string CustId, Int64 ChatId, Int64 UserId);
    }
}
