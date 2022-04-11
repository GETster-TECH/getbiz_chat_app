using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Chat_Master_Dynamic_Db
{
    public class UserAppChatMasterRepository : IUserAppChatMasterRepository
    {
        public readonly ChatBroadCastAppDB_DbContext _DbContext;
        public UserAppChatMasterRepository(ChatBroadCastAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserAppChatMaster(userapp_chat_master Obj_chat_master)
        {
            Response response = new Response();
            try
            {
                if (!string.IsNullOrEmpty(Obj_chat_master.cust_id))
                {
                    GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                    var result = Obj_GetSetDatabase.AddUserAppChatMaster(Obj_chat_master);
                    response = result;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Customer Id Should be Null or Empty";
                }

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public Response UpdateUserAppChatMaster(userapp_chat_master Obj_chat_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateUserAppChatMaster(Obj_chat_master);
                response = result;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response DeleteUserAppChatMasterById(string CustId, Int64 ChatId)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.DeleteUserAppChatMasterById(CustId, ChatId);
                response = result;

                response.Message = "Data Deleted successfully !!";
                response.Status = true;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



        //public Response GetUserAppChatMasterById(string CustId, Int64 ChatId,Int64 UserId)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        DataTable dset = new DataTable();

        //        GetSetDatabase Obj_getsetdb = new GetSetDatabase();
        //        dset = Obj_getsetdb.GetUserAppChatMasterById(CustId, ChatId, UserId);
        //        string JSONresult;
        //        JSONresult = JsonConvert.SerializeObject(dset);



        //        //List<chat_master> obj_chat_master = new List<chat_master>();
        //        //obj_chat_master = ConvertDataTable<chat_master>(dset);

        //        response.Data = JSONresult;
        //        response.Message = "Data Fetch successfully !!";
        //        response.Status = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.Message = ex.Message;
        //    }
        //    return response;
        //}


        public Response GetAllUserAppChatMaster(string CustId, Int64 UserId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAllUserAppChatMaster(CustId, UserId);

                //List<userapp_chat_master> obj_chat_master = new List<userapp_chat_master>();
                //obj_chat_master = ConvertDataTable<userapp_chat_master>(dset);

                //response.Data = (obj_chat_master).ToList();
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);
                response.Data = JSONresult;

                response.Message = "Data Fetch successfully !";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;

        }



        public Response UpdateColumnUserAppChatMaster(userapp_chat_master Obj_chat_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateColumnUserAppChatMaster(Obj_chat_master);
                response = result;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }





        public Response UpdateAssignChatUserListDetails(userapp_chat_master Obj_chat_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateAssignChatUserListDetails(Obj_chat_master);
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
    }
}

