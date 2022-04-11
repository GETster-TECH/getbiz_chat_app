using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Custom_Member_Permissions_For_User_Id;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Controllers
{
    [ApiController]
    public class CustomMemberPermissionsForUserIdController : ControllerBase
    {
        private ICustomMemberPermissionsForUserIdRepository _customMemberPermissionsForUserIdRepository;

        public CustomMemberPermissionsForUserIdController(ICustomMemberPermissionsForUserIdRepository customMemberPermissionsForUserIdRepository)
        {
            _customMemberPermissionsForUserIdRepository = customMemberPermissionsForUserIdRepository;
        }


        [HttpPut]
        [Route("api/UpdateCustomMemberPermissionsForUserId")]
        public IActionResult UpdateGroupMemberUsersPermissions(custom_member_permissions_for_user_id obj_custom_member_permissions_for_user_id)
        {
            try
            {
                var messages = _customMemberPermissionsForUserIdRepository.UpdateCustomMemberPermissionsForUserId(obj_custom_member_permissions_for_user_id);
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
        [Route("api/GetChatIdCustomMemberPermissionsForUserId")]
        public IActionResult GetChatIdCustomMemberPermissionsForUserId(string CustId, Int64 ChatId, Int64 UserId)
        {
            try
            {
                var messages = _customMemberPermissionsForUserIdRepository.GetChatIdCustomMemberPermissionsForUserId(CustId, ChatId, UserId);
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
