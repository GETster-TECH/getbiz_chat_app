using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Chat_Broadcast_App_Dynamic_Db
{
    public class ChatAppDynamicDbRepository : IChatAppDynamicDbRepository
    {

        public readonly ChatBroadCastAppDB_DbContext _DbContext;
        public ChatAppDynamicDbRepository(ChatBroadCastAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }




        public Response AddChatAppDyanmicDb(chat_broadcast_app_dynamic_db obj_chat_broadcast_app_dynamic_db)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.AddChatAppDyanmicDb(obj_chat_broadcast_app_dynamic_db);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error! While Creting Dynamic Database !!";
            }
            return response;
        }
    }
}
