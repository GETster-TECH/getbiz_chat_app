using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Userapp_Audit_Trail_For_Profanity_Text
{
    public class UserAppAuditTtrailForProfanityTextRepository : IUserAppAuditTtrailForProfanityTextRepository
    {
        public Response AddUserAppAuditTtrailForProfanityText(user_app_audit_trail_for_profanity_text obj_profanity_text)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddUserAppAuditTtrailForProfanityText(obj_profanity_text);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public Response GetAllUserAppAuditTrailForProfanityText(string CustId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAllUserAppAuditTrailForProfanityText(CustId);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);
                //List<user_app_audit_trail_for_profanity_text> obj_users_list = new List<user_app_audit_trail_for_profanity_text>();
                //obj_users_list = ConvertDataTable<user_app_audit_trail_for_profanity_text>(dset);

                //response.Data = (obj_users_list).ToList();
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


        public Response UpdateUserAppAuditTrailForProfanityText(user_app_audit_trail_for_profanity_text obj_profanity_text)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateUserAppAuditTrailForProfanityText(obj_profanity_text);
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
