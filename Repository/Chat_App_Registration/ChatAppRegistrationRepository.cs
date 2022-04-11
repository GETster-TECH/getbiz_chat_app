using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Chat_App_Registration
{
    public class ChatAppRegistrationRepository : IChatAppRegistrationRepository
    {
        public readonly ChatBroadCastAppDB_DbContext _Context;
        public ChatAppRegistrationRepository(ChatBroadCastAppDB_DbContext Context)
        {
            _Context = Context;
        }




        //Create
        public Response AddChatAppRegistration(chat_app_registration obj_chat_app)
        {
            Response response = new Response();
            try
            {
                if (obj_chat_app.user_id != 0)
                {

                    var obj = _Context.chat_app_registrations.Add(obj_chat_app);
                    _Context.SaveChanges();
                    response.Message = "Data Saved successfully !!";
                    response.Status = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = "Data Saved to failed !!";
                response.Status = false;
            }
            return response;
        }


        public Response GetAllChatAppRegistration(string CustId,int UserId)
        {
            Response response = new Response();
            try
            {
                if (UserId == 0)
                {
                    response.Data = (from obj in _Context.chat_app_registrations.Where(x => x.cust_id == CustId)
                                     select new
                                     {
                                         user_id = obj.user_id,
                                         cust_id = obj.cust_id,
                                         user_name = obj.user_name,
                                         company_name = obj.company_name,
                                         designation = obj.designation,
                                         mobile_no = obj.mobile_no,
                                         country_code = obj.country_code,
                                         user_blogs = obj.user_blogs,
                                         email_id = obj.email_id,
                                         address = obj.address,
                                         about = obj.about,
                                         share_link = obj.share_link,
                                         photo_id = obj.photo_id,
                                     }).ToList();

                    response.Message = "Data Fetch successfully !!";
                    response.Status = true;
                }



                if (UserId != 0)
                {
                    response.Data = (from obj in _Context.chat_app_registrations.Where(x => x.cust_id == CustId && x.user_id==UserId)
                                     select new
                                     {
                                         user_id = obj.user_id,
                                         cust_id = obj.cust_id,
                                         user_name = obj.user_name,
                                         company_name = obj.company_name,
                                         designation = obj.designation,
                                         mobile_no = obj.mobile_no,
                                         country_code = obj.country_code,
                                         user_blogs = obj.user_blogs,
                                         email_id = obj.email_id,
                                         address = obj.address,
                                         about = obj.about,
                                         share_link = obj.share_link,
                                         photo_id = obj.photo_id,
                                     }).FirstOrDefault();

                    response.Message = "Data Fetch successfully !!";
                    response.Status = true;
                }

            }

            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }


    }
}
