using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Userapp_Group_Info;
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
    public class UserAppGroupMemberByIdController : ControllerBase
    {
        private IUserAppGroupMemberByIdRepository  _userAppGroupInfoRepository;

        public UserAppGroupMemberByIdController(IUserAppGroupMemberByIdRepository userAppGroupInfoRepository)
        {
            _userAppGroupInfoRepository = userAppGroupInfoRepository;
        }



        [HttpGet]
        [Route("api/GetUserAppGroupMemberById")]
        public IActionResult GetUserAppGroupMemberById(string CustId, Int64 ChatId)
        {
            try
            {
                var messages = _userAppGroupInfoRepository.GetUserAppGroupMemberById(CustId, ChatId);
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


        [HttpPost]
        [Route("api/AddUserAppGroupMemberById")]
        public IActionResult AddUserAppGroupMemberById(userapp_chat_master obj_chat_master)
        {
            try
            {
                var messages = _userAppGroupInfoRepository.AddUserAppGroupMemberById(obj_chat_master);
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
