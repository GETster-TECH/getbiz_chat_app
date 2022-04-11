using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Chat_App_Registration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatAppRegistrationController : ControllerBase
    {
        private IChatAppRegistrationRepository _ChatAppRegistrationRepository;

        public ChatAppRegistrationController(IChatAppRegistrationRepository ChatAppRegistrationRepository)
        {
            _ChatAppRegistrationRepository = ChatAppRegistrationRepository;
        }



        [HttpPost]
        [Route("api/AddChatAppRegistration")]
        public IActionResult AddChatAppRegistration(chat_app_registration obj_chat_app)
        {
            try
            {
                var messages = _ChatAppRegistrationRepository.AddChatAppRegistration(obj_chat_app);
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



        [HttpGet]
        [Route("api/GetAllChatAppRegistration")]
        public IActionResult GetAllChatAppRegistration(string CustId, int UserId)
        {
            try
            {
                var messages = _ChatAppRegistrationRepository.GetAllChatAppRegistration(CustId, UserId);
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
