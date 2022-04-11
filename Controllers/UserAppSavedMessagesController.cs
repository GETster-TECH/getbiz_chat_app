using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Userapp_Saved_Messages;
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
    public class UserAppSavedMessagesController : ControllerBase
    {
        private readonly IUserAppSavedMessagesRepository _userAppSavedMessagesRepository;
        public UserAppSavedMessagesController(IUserAppSavedMessagesRepository userAppSavedMessagesRepository)
        {
            _userAppSavedMessagesRepository = userAppSavedMessagesRepository;
        }


   
        [HttpPost]
        [Route("api/AddUserAppSavedMessages")]
        public IActionResult AddUserAppSavedMessages(userapp_saved_messages obj_saved_messages)
        {
            try
            {
              

                var messages = _userAppSavedMessagesRepository.AddUserAppSavedMessages(obj_saved_messages);
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
