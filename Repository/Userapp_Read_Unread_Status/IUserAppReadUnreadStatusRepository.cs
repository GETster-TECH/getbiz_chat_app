using getbiz_chat_app.Models;

namespace getbiz_chat_app.Repository.Userapp_Read_Unread_Status
{
    public interface IUserAppReadUnreadStatusRepository
    {
        Response GetAllUserAppChatIdReadUnreadStatusCount(string CustId, long ChatId, long UserId);
    }
}