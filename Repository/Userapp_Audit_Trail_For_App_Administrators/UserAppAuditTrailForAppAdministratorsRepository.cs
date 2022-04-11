using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_chat_app.Repository.Userapp_Audit_Trail_For_App_Administrators
{
    public class UserAppAuditTrailForAppAdministratorsRepository : IUserAppAuditTrailForAppAdministratorsRepository
    {
        public Response GetAuditTrailForAppAdministrators(string CustId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAuditTrailForAppAdministrators(CustId);

                List<userapp_audit_trail_for_app_administrators> obj_users_list = new List<userapp_audit_trail_for_app_administrators>();
                obj_users_list = ConvertDataTable<userapp_audit_trail_for_app_administrators>(dset);

                response.Data = (obj_users_list).ToList();
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
