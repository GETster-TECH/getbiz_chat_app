using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Userapp_Chat_Id_Users_List;
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
    public class UserAppChatIdUsersListController : ControllerBase
    {
        private IUserAppChatIdUsersListRepository _UserAppChatIdUsersListRepository;

        public UserAppChatIdUsersListController(IUserAppChatIdUsersListRepository UserAppChatIdUsersListRepository)
        {
            _UserAppChatIdUsersListRepository = UserAppChatIdUsersListRepository;
        }

        [HttpPut]
        [Route("api/UpdateUserAppChatIdUsersList")]
        public IActionResult UpdateUserAppChatIdUsersList(userapp_chat_id_users_list chat_id_users_list)
        {
            try
            {

                var messages = _UserAppChatIdUsersListRepository.UpdateUserAppChatIdUsersList(chat_id_users_list);
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
        [Route("api/GetAllUserAppChatIdUsersList")]
        public IActionResult GetAllUserAppChatIdUsersList(string CustId, Int64 ChatId)
        {
            try
            {

                var messages = _UserAppChatIdUsersListRepository.GetAllUserAppChatIdUsersList(CustId, ChatId);
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



        [HttpDelete]
        [Route("api/DeleteUserAppGroupMemberById")]
        public IActionResult DeleteUserAppGroupMemberById(Int64 ChatId, string CustId, Int64 UserId)
        {
            try
            {
                var messages = _UserAppChatIdUsersListRepository.DeleteUserAppGroupMemberById(ChatId, CustId, UserId);
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
