using getbiz_chat_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Group_Member_Users_Permissions
{
    public interface IGroupMemberUsersPermissionsRepository
    {
        Response UpdateGroupMemberUsersPermissions(group_member_users_permissions obj_group_member_users_permissions);
        Response GetChatIdGroupMemberUserPermission(string CustId, Int64 ChatId, Int64 UserId);
    }
}
