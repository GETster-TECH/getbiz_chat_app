using getbiz_chat_app.Models;

using System;

namespace getbiz_chat_app.Repository.Userapp_Chat_List
{
    public interface IUserAppChatListRepository
    {
      //  Response GetAllUserAppChatList(string CustId, long UserId);
        public Response UpdateUserUserAppChatList(userapp_chat_list obj_chat_list);
    }
}