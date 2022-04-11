using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Group_Member_Users_Permissions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Controllers
{
    [ApiController]
    public class GroupMemberUsersPermissionsController : ControllerBase
    {
        private IGroupMemberUsersPermissionsRepository _groupMemberUsersPermissionsRepository;

        public GroupMemberUsersPermissionsController(IGroupMemberUsersPermissionsRepository groupMemberUsersPermissionsRepository)
        {
            _groupMemberUsersPermissionsRepository = groupMemberUsersPermissionsRepository;
        }


        [HttpPut]
        [Route("api/UpdateGroupMemberUsersPermissions")]
        public IActionResult UpdateGroupMemberUsersPermissions(group_member_users_permissions obj_group_member_users_permissions)
        {
            try
            {
                var messages = _groupMemberUsersPermissionsRepository.UpdateGroupMemberUsersPermissions(obj_group_member_users_permissions);
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
        [Route("api/GetChatIdGroupMemberUserPermission")]
        public IActionResult GetChatIdAdminUsersPermissions(string CustId, Int64 ChatId, Int64 UserId)
        {
            try
            {
                var messages = _groupMemberUsersPermissionsRepository.GetChatIdGroupMemberUserPermission(CustId, ChatId, UserId);
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
