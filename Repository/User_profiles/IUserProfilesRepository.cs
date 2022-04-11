using getbiz_chat_app.Models;
using System;

namespace getbiz_chat_app.Repository.User_profiles
{
    public interface IUserProfilesRepository
    {
        Response GetUserList(string CustId, Int64 UserId);
    }
}