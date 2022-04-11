using getbiz_chat_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Chat_Broadcast_App_Dynamic_Db
{
    public interface IChatAppDynamicDbRepository
    {

        Response AddChatAppDyanmicDb(chat_broadcast_app_dynamic_db obj_chat_broadcast_app_dynamic_db);
    }
}
