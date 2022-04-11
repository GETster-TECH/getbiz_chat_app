using getbiz_chat_app.Models;

namespace getbiz_chat_app.Repository.Userapp_Audit_Trail_For_Profanity_Text
{
    public interface IUserAppAuditTtrailForProfanityTextRepository
    {
        Response AddUserAppAuditTtrailForProfanityText(user_app_audit_trail_for_profanity_text obj_profanity_text);
        Response GetAllUserAppAuditTrailForProfanityText(string CustId);
        Response UpdateUserAppAuditTrailForProfanityText(user_app_audit_trail_for_profanity_text obj_profanity_text);
    }
}