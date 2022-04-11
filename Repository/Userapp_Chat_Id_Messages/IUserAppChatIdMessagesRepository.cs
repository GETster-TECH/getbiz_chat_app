using getbiz_chat_app.Models;
using System;

namespace getbiz_chat_app.Repository.Chat_Messages
{
    public interface IUserAppChatIdMessagesRepository
    {
        Response AddUserAppChatIdMessages(userapp_chat_Id_messages obj_chat_messages, userapp_chat_Id_messages mainobj);
      //  Response GetAllUserAppChatIdMessages(string CustId, Int64 ChatId, Int64 UserId, Int64 PageNo, Int64 PageSize);
        Response GetSearchChatMessages(string SearchMessage, string CustId, Int64 ChatId);
        Response DeleteMessages(string Cust_Id, Int64 Chat_Id, string Message_Timestamp,Int64 Id);

        Response EditMessages(userapp_chat_Id_messages obj_userapp_chat_Id_messages);
        Response MarkUnReadMessage(mark_unread_message obj_mark_unread_message);
        Response HideMessage(userapp_chat_Id_messages obj_userapp_chat_Id_messages);
        Response AddUserAppChatIdReplayMessages(userapp_chat_Id_messages obj_chat_messages, userapp_chat_Id_messages mainobj);
    }
}