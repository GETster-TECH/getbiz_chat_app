using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Userapp_Chat_List
{
    public class UserAppChatListRepository : IUserAppChatListRepository
    {
        //public Response GetAllUserAppChatList(string CustId, Int64 UserId)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        List<DataSet> dset = new List<DataSet>();

        //        GetSetDatabase Obj_getsetdb = new GetSetDatabase();
        //        dset = Obj_getsetdb.GetAllUserAppChatList(CustId, UserId);

        //        //List<userapp_chat_list> obj_users_list = new List<userapp_chat_list>();
        //        //obj_users_list = ConvertDataTable<userapp_chat_list>(dset);

        //        //response.Data = (obj_users_list).ToList();
        //        string JSONresult;
        //        JSONresult = JsonConvert.SerializeObject(dset);
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

        public Response UpdateUserUserAppChatList(
             userapp_chat_list obj_chat_list
            //string CustId,
            //Int64 UserId,
            //Int64 ChatId,
            //Int64 PinToTopOfListNo,
            //string NumberOfUnreadMessages,
            //string MuteNotificationsFromThisChat
            )
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateUserUserAppChatList(obj_chat_list);
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
