using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Chat_Broadcast_App_Dynamic_Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Controllers
{
    [ApiController]
    public class ChatAppDynamicDbController : ControllerBase
    {

        private IChatAppDynamicDbRepository chatBroadcastAppDynamicDbRepository;
        public ChatAppDynamicDbController(IChatAppDynamicDbRepository _chatBroadcastAppDynamicDbRepository)
        {
            chatBroadcastAppDynamicDbRepository = _chatBroadcastAppDynamicDbRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddChatAppDyanmicDb")]  
        public IActionResult AddChatAppDyanmicDb(chat_broadcast_app_dynamic_db obj_chat_broadcast_app_dynamic_db)
        {
            try
            {
                var messages = chatBroadcastAppDynamicDbRepository.AddChatAppDyanmicDb(obj_chat_broadcast_app_dynamic_db);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
