using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Chat_Master_Dynamic_Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Controllers
{
    [ApiController]
    public class UserAppChatMasterController : ControllerBase
    {
        private IUserAppChatMasterRepository _chatMasterRepository;

        public UserAppChatMasterController(IUserAppChatMasterRepository chatMasterRepository)
        {
            _chatMasterRepository = chatMasterRepository;
        }


       
        [HttpPost]
        [Route("api/AddUserAppChatMaster")]
        public IActionResult AddUserAppChatMaster(userapp_chat_master obj_chat_master)
        {
            try
            {
                //obj_chat_master.Message = Message;
                var messages = _chatMasterRepository.AddUserAppChatMaster(obj_chat_master);
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
        [Route("api/UpdateUserAppChatMaster")]
        public IActionResult UpdateChatMaster(userapp_chat_master obj_chat_master)
        {
            try
            {
                var messages = _chatMasterRepository.UpdateUserAppChatMaster(obj_chat_master);
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

        [HttpDelete]
        [Route("api/DeleteUserAppChatMasterById")]
        public IActionResult DeleteChatMasterById(string CustId, Int64 ChatId)
        {
            try
            {
                var messages = _chatMasterRepository.DeleteUserAppChatMasterById(CustId, ChatId);
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
        [Route("api/GetUserAppChatMasterById")]
        public Response GetChatMasterById(string CustId, Int64 ChatId,Int64 UserId)               
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();

                var result = Obj_getsetdb.GetUserAppChatMasterById(CustId, ChatId, UserId);

                response.Message = "Get successfully !!";            
                response.Status = true;            
                response.Data = result;            
            }

            catch (Exception ex)
            {
              
            }
            return response;
        }

        [HttpGet]
        [Route("api/GetAllUserAppChatMaster")]
        public IActionResult GetAllChatMaster(string CustId, Int64 UserId)
        {
            try
            {
                var messages = _chatMasterRepository.GetAllUserAppChatMaster(CustId, UserId);
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
        [Route("api/UpdateColumnUserAppChatMaster")]
        public IActionResult UpdateColumnUserAppChatMaster(userapp_chat_master obj_chat_master)
        {
            try
            {
                var messages = _chatMasterRepository.UpdateColumnUserAppChatMaster(obj_chat_master);
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
