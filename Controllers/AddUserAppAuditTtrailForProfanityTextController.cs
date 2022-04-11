using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Userapp_Audit_Trail_For_Profanity_Text;
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
    public class AddUserAppAuditTtrailForProfanityTextController : ControllerBase
    {
        private IUserAppAuditTtrailForProfanityTextRepository _Profanity;

        public AddUserAppAuditTtrailForProfanityTextController(IUserAppAuditTtrailForProfanityTextRepository Profanity)
        {
            _Profanity = Profanity;
        }




        [HttpPost]
        [Route("api/AddUserAppAuditTtrailForProfanityText")]
        public IActionResult AddUserAppAuditTtrailForProfanityText(user_app_audit_trail_for_profanity_text obj_profanity_text)
        {
            try
            {
                var messages = _Profanity.AddUserAppAuditTtrailForProfanityText(obj_profanity_text);
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
        [Route("api/GetAllUserAppAuditTrailForProfanityText")]
        public IActionResult GetAllUserAppAuditTrailForProfanityText(string CustId)
        {
            try
            {
                var messages = _Profanity.GetAllUserAppAuditTrailForProfanityText(CustId);
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
        [Route("api/UpdateUserAppAuditTrailForProfanityText")]
        public IActionResult UpdateUserAppAuditTrailForProfanityText(user_app_audit_trail_for_profanity_text obj_profanity_text)
        {
            try
            {
                var messages = _Profanity.UpdateUserAppAuditTrailForProfanityText(obj_profanity_text);
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
