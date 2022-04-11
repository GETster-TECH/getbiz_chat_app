using getbiz_chat_app.Repository.Userapp_Read_Unread_Status;
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
    public class UserAppReadUnreadStatusController : ControllerBase
    {


        private IUserAppReadUnreadStatusRepository _UserAppReadUnreadStatusRepository;

        public UserAppReadUnreadStatusController(IUserAppReadUnreadStatusRepository UserAppReadUnreadStatusRepository)
        {
            _UserAppReadUnreadStatusRepository = UserAppReadUnreadStatusRepository;
        }



        [HttpGet]
        [Route("api/GetAllUserAppChatIdReadUnreadStatusCount")]
        public IActionResult GetAllUserAppChatIdReadUnreadStatusCount(string CustId, Int64 ChatId, Int64 UserId)
        {
            try

            {
             
                var messages = _UserAppReadUnreadStatusRepository.GetAllUserAppChatIdReadUnreadStatusCount(CustId, ChatId, UserId);
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
