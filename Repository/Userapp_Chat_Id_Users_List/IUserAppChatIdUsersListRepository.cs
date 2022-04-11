using getbiz_chat_app.Models;
using System;

namespace getbiz_chat_app.Repository.Userapp_Chat_Id_Users_List
{
    public interface IUserAppChatIdUsersListRepository
    {
        Response GetAllUserAppChatIdUsersList(string CustId, long ChatId);
        Response UpdateUserAppChatIdUsersList(userapp_chat_id_users_list Obj_chat_id_users_list);
        Response DeleteUserAppGroupMemberById(Int64 ChatId, string CustId, Int64 UserId);

    }
}