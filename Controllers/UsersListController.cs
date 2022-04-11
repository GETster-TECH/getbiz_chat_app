using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.User_profiles;
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
    public class UsersListController : ControllerBase
    {
        private readonly IUserProfilesRepository _userProfilesRepository;
        public UsersListController(IUserProfilesRepository userProfilesRepository)
        {
            _userProfilesRepository = userProfilesRepository;
        }


        [HttpGet]
        [Route("api/GetUserList")]
        public IActionResult GetUserList(string CustId, Int64 UserId)
        {
            try
            {
                var messages = _userProfilesRepository.GetUserList(CustId,UserId);
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
