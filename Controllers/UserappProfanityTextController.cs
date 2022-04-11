using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Userapp_Profanity_Text;
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
    public class UserappProfanityTextController : ControllerBase
    {
        private IUserappProfanityTextRepository _userappProfanityTextRepository;
        public UserappProfanityTextController(IUserappProfanityTextRepository userappProfanityTextRepository)
        {
            _userappProfanityTextRepository = userappProfanityTextRepository;
        }


        [HttpPost]
        [Route("api/AddUserappProfanityText")]
        public IActionResult AddUserappProfanityText(userapp_profanity_text obj_userapp_profanity_text)
        {
            try
            {
                var messages = _userappProfanityTextRepository.AddUserappProfanityText(obj_userapp_profanity_text);
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
        [Route("api/GetAllUserAppForProfanityText")]
        public IActionResult GetAllUserAppForProfanityText(string CustId,bool IsItUnblocked)
        {
            try
            {
                var messages = _userappProfanityTextRepository.GetAllUserAppForProfanityText(CustId, IsItUnblocked);
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


        [HttpPut]
        [Route("api/UpdateUserappProfanityText")]
        public IActionResult UpdateUserappProfanityText(userapp_profanity_text obj_userapp_profanity_text)
        {
            try
            {
                var messages = _userappProfanityTextRepository.UpdateUserappProfanityText(obj_userapp_profanity_text);
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
