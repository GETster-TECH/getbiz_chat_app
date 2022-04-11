using getbiz_chat_app.Models;
using System;

namespace getbiz_chat_app.Repository.Chat_Master_Dynamic_Db
{
    public interface IUserAppChatMasterRepository
    {
        Response AddUserAppChatMaster(userapp_chat_master Obj_chat_master);
        Response DeleteUserAppChatMasterById(string CustId, Int64 ChatId);
        Response GetAllUserAppChatMaster(string CustId, Int64 UserId
            );
      //  Response GetUserAppChatMasterById(string CustId, Int64 ChatId, Int64 UserId);
        Response UpdateUserAppChatMaster(userapp_chat_master Obj_chat_master);
        Response UpdateColumnUserAppChatMaster(userapp_chat_master Obj_chat_master);

        Response UpdateAssignChatUserListDetails(userapp_chat_master Obj_chat_master);
    }
}