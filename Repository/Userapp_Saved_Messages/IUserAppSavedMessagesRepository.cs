using getbiz_chat_app.Models;

namespace getbiz_chat_app.Repository.Userapp_Saved_Messages
{
    public interface IUserAppSavedMessagesRepository
    {
        Response AddUserAppSavedMessages(userapp_saved_messages obj_saved_messages);
    }
}