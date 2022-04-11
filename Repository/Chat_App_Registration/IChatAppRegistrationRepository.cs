using getbiz_chat_app.Models;

namespace getbiz_chat_app.Repository.Chat_App_Registration
{
    public interface IChatAppRegistrationRepository
    {
        Response AddChatAppRegistration(chat_app_registration obj_chat_app);
        Response GetAllChatAppRegistration(string CustId, int UserId);
    }
}