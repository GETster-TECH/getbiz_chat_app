using getbiz_chat_app.Models;
using System;

namespace getbiz_chat_app.Repository.Userapp_Group_Info
{
    public interface IUserAppGroupMemberByIdRepository
    {
        Response GetUserAppGroupMemberById(string CustId, long ChatId);
        Response AddUserAppGroupMemberById(userapp_chat_master obj_chat_master);
    }
}