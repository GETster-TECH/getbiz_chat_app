using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Users_Userapp_Blocked_User_List;
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
    public class UsersUserAppBlockedUserListController : ControllerBase
    {
        private readonly IUsersUserAppBlockedUserListRepository _usersUserAppBlockedUserListRepository;
        public UsersUserAppBlockedUserListController(IUsersUserAppBlockedUserListRepository usersUserAppBlockedUserListRepository)
        {
            _usersUserAppBlockedUserListRepository = usersUserAppBlockedUserListRepository;
        }



        [HttpPut]
        [Route("api/UpdateUsersUserAppBlockedUserList")]
        public IActionResult UpdateUsersUserAppBlockedUserList(userapp_blocked_user_list obj_blocked_user_list)
        {
            try
            {
                var messages = _usersUserAppBlockedUserListRepository.UpdateUsersUserAppBlockedUserList(obj_blocked_user_list);
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
