using getbiz_chat_app.Repository.Userapp_Audit_Trail_For_App_Administrators;
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
    public class UserAppAuditTrailForAppAdministratorsController : ControllerBase
    {
        public readonly IUserAppAuditTrailForAppAdministratorsRepository _userAppAuditTrailForAppAdministrators;
        public UserAppAuditTrailForAppAdministratorsController(IUserAppAuditTrailForAppAdministratorsRepository userAppAuditTrailForAppAdministrators)
        {
            _userAppAuditTrailForAppAdministrators = userAppAuditTrailForAppAdministrators;

        }

    
        [HttpGet]
        [Route("api/GetAuditTrailForAppAdministrators")]
        public IActionResult GetAuditTrailForAppAdministrators(string CustId)
        {
            try
            {
                var messages = _userAppAuditTrailForAppAdministrators.GetAuditTrailForAppAdministrators(CustId);
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
