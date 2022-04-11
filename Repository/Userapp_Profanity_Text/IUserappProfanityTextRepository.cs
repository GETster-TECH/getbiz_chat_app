using getbiz_chat_app.Models;

namespace getbiz_chat_app.Repository.Userapp_Profanity_Text
{
    public interface IUserappProfanityTextRepository
    {
        Response AddUserappProfanityText(userapp_profanity_text obj_userapp_profanity_text);
        Response GetAllUserAppForProfanityText(string CustId, bool IsItUnblocked);
        Response UpdateUserappProfanityText(userapp_profanity_text obj_userapp_profanity_text);
    }
}