using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Userapp_Chat_List;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAppChatListController : ControllerBase
    {
        private IUserAppChatListRepository _UserAppChatListRepository;

        public UserAppChatListController(IUserAppChatListRepository UserAppChatListRepository)
        {
            _UserAppChatListRepository = UserAppChatListRepository;
        }



        //[HttpGet]
        //[Route("api/GetAllUserAppChatList")]
        //public IActionResult GetAllUserAppChatList(string CustId, Int64 UserId)
        //{
        //    try
        //    {

        //        var messages = _UserAppChatListRepository.GetAllUserAppChatList(CustId,  UserId);
        //        if (messages == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(messages);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}



        [HttpGet]
        [Route("api/GetAllUserAppChatList")]
        public Response GetAllUserAppChatList(string CustId, Int64 UserId)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase obj_GetSetDatabase = new GetSetDatabase();
                var messages = obj_GetSetDatabase.GetAllUserAppChatList(CustId, UserId);
                 string JSONresult;
                 JSONresult = JsonConvert.SerializeObject(messages);

                response.Data = JSONresult;
                response.Message = "Data Fetch successfully !!";
                response.Status = true;

                if (JSONresult == null)
                {
                    return response;
                }

                return response;  
                //return Ok(JSONresult);  
            }
            catch (Exception ex)
            {
                return response;
            }
        }




        [HttpPut]
        [Route("api/UpdateUserUserAppChatList")]
        public IActionResult UpdateUserUserAppChatList(userapp_chat_list obj_chat_list)
        {
            try
            {

                var messages = _UserAppChatListRepository.UpdateUserUserAppChatList(obj_chat_list);
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
