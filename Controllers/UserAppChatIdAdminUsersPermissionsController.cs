using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Admin_Users_Permissions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Controllers
{
    [ApiController]
    public class UserAppChatIdAdminUsersPermissionsController : ControllerBase
    {
        private IChatIdAdminUsersPermissionsRepository _AdminUsersPermissionsRepository;

        public UserAppChatIdAdminUsersPermissionsController(IChatIdAdminUsersPermissionsRepository AdminUsersPermissionsRepository)
        {
            _AdminUsersPermissionsRepository = AdminUsersPermissionsRepository;
        }


        [HttpPut]
        [Route("api/UpdateChatIdAdminUsersPermissions")]
        public IActionResult UpdateChatIdAdminUsersPermissions(chat_id_admin_users_permissions obj_admin_users_permissions)
        {
            try
            {
                var messages = _AdminUsersPermissionsRepository.UpdateChatIdAdminUsersPermissions(obj_admin_users_permissions);
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
        [Route("api/GetChatIdAdminUsersPermissions")]
        public IActionResult GetChatIdAdminUsersPermissions(string CustId, Int64 ChatId, Int64 UserId)
        {
            try
            {
                var messages = _AdminUsersPermissionsRepository.GetChatIdAdminUsersPermissions(CustId, ChatId, UserId);
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
