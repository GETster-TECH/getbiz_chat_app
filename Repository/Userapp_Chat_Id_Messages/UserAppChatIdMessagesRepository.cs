using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Chat_Messages
{
    public class UserAppChatIdMessagesRepository : IUserAppChatIdMessagesRepository
    {
        public Response AddUserAppChatIdMessages(userapp_chat_Id_messages obj_chat_messages, userapp_chat_Id_messages mainobj)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddUserAppChatIdMessages(obj_chat_messages,  mainobj);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        //public Response GetAllUserAppChatIdMessages(string CustId, Int64 ChatId, Int64 UserId, Int64 PageNo, Int64 PageSize)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        DataTable dset = new DataTable();

        //        GetSetDatabase Obj_getsetdb = new GetSetDatabase();
        //        dset = Obj_getsetdb.GetAllUserAppChatIdMessages(CustId, ChatId, UserId, PageNo, PageSize);

        //        //List<userapp_chat_Id_messages> obj_chat_master = new List<userapp_chat_Id_messages>();
        //        //obj_chat_master = ConvertDataTable<userapp_chat_Id_messages>(dset);

        //        //response.Data = (obj_chat_master).ToList();

        //        string JSONresult;
        //        JSONresult = JsonConvert.SerializeObject(dset);
        //        response.Data = JSONresult;
        //            response.Message = "Data Fetch successfully !!";
        //        response.Status = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.Message = ex.Message;
        //    }
        //    return response;

        //}



        public Response GetSearchChatMessages(string SearchMessage, string CustId, Int64 ChatId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetSearchChatMessages( SearchMessage, CustId, ChatId);

                //List<userapp_chat_Id_messages> obj_chat_master = new List<userapp_chat_Id_messages>();
                //obj_chat_master = ConvertDataTable<userapp_chat_Id_messages>(dset);

                //response.Data = (obj_chat_master).ToList();

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);
                response.Data = JSONresult;
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;

        }


        public Response AddUserAppChatIdReplayMessages(userapp_chat_Id_messages obj_chat_messages, userapp_chat_Id_messages mainobj)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddUserAppChatIdReplayMessages(obj_chat_messages, mainobj);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }


        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public Response DeleteMessages(string Cust_Id, long Chat_Id, string Message_Timestamp, long Id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.DeleteMessages( Cust_Id,  Chat_Id,  Message_Timestamp,  Id);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response EditMessages(userapp_chat_Id_messages obj_userapp_chat_Id_messages)
        {
           Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.EditMessages(obj_userapp_chat_Id_messages);
                 response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
        return response;
        }



        public Response MarkUnReadMessage(mark_unread_message obj_mark_unread_message)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.MarkUnReadMessage(obj_mark_unread_message);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public Response HideMessage(userapp_chat_Id_messages obj_userapp_chat_Id_messages)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.HideMessage( obj_userapp_chat_Id_messages);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }







    }




}
