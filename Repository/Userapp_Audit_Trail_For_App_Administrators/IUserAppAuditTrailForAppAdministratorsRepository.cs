using getbiz_chat_app.Models;

namespace getbiz_chat_app.Repository.Userapp_Audit_Trail_For_App_Administrators
{
    public interface IUserAppAuditTrailForAppAdministratorsRepository
    {
        Response GetAuditTrailForAppAdministrators(string CustId);
    }
}