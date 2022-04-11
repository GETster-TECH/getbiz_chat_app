using getbiz_chat_app.Models;
using getbiz_chat_app.V_Models;
using MySqlConnector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace getbiz_chat_app.Getbiz_DbContext
{
    public class GetSetDatabase
    {
        string connection = "Server=185.252.235.20;User ID=root;Password=GetBizMysqlDatabasePwd2021@;Database=chatbroadcastappdb; Allow User Variables=true";
       // string connection = "Server=localhost;User ID=root;Password=mysql;Database=chatbroadcastappdb; Allow User Variables=true";
        public Response AddChatAppDyanmicDb(chat_broadcast_app_dynamic_db obj_chat_broadcast_app_dynamic_db)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[2];

            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                param[0].Value = obj_chat_broadcast_app_dynamic_db.cust_id;

                param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                param[1].Value = obj_chat_broadcast_app_dynamic_db.user_id;

                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateChatAppDyanmicDb", param);
            }
            catch (Exception ex)
            {

            }
            if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
            {
                response.Data = "";
                response.Message = "Database Created successfully";
                response.Status = true;
            }
            else
            {
                response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
            }
            return response;
        }


        public Response AddUserAppChatMaster(userapp_chat_master obj_chat_Master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet dsetmaxid = new DataSet();
            DataSet dsetcm = new DataSet();
            DataSet dsetuserlist = new DataSet();
            //JObject json = JObject.Parse(getster_App_About_Demo.getster_app_time_stamp_description);
            try
            {
                MySqlParameter[] param = new MySqlParameter[14];

                //JObject json = JObject.Parse(getster_App_About_Demo.getster_app_time_stamp_description);
                //getster_App_About_Demo.getster_app_time_stamp_description = json.ToString();

                using MySqlConnection con = new MySqlConnection(connection);

                param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int32);
                param[0].Value = obj_chat_Master.chat_id;

                param[1] = new MySqlParameter("p_group_chat_name", MySqlDbType.VarChar);
                param[1].Value = obj_chat_Master.group_chat_name;

                param[2] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int32);
                param[2].Value = obj_chat_Master.created_by_user_id;

                param[3] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                param[3].Value = obj_chat_Master.created_timestamp;

                param[4] = new MySqlParameter("p_auto_delete_old_messages_no_of_days", MySqlDbType.Int64);
                param[4].Value = obj_chat_Master.auto_delete_old_messages_no_of_days;

                param[5] = new MySqlParameter("P_about_the_chat", MySqlDbType.LongText);
                param[5].Value = obj_chat_Master.about_the_chat;

                param[6] = new MySqlParameter("p_pin_chat_to_the_top_of_chat_list", MySqlDbType.VarChar);
                param[6].Value = obj_chat_Master.pin_chat_to_the_top_of_chat_list;

                param[7] = new MySqlParameter("p_pin_message_timestamp", MySqlDbType.VarChar);
                param[7].Value = obj_chat_Master.pin_message_timestamp;

                param[8] = new MySqlParameter("p_user_profile", MySqlDbType.VarChar);
                param[8].Value = obj_chat_Master.user_profile;

                param[9] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                param[9].Value = "Insert";

                param[10] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                param[10].Value = obj_chat_Master.cust_id;

                param[11] = new MySqlParameter("p_chat_type", MySqlDbType.Int64);
                param[11].Value = obj_chat_Master.chat_type;

                param[12] = new MySqlParameter("p_auto_delete_old_messages", MySqlDbType.Bool);
                param[12].Value = Convert.ToBoolean(obj_chat_Master.auto_delete_old_messages); ;

                param[13] = new MySqlParameter("p_businesses_associated_with_this_group", MySqlDbType.VarChar);
                param[13].Value = obj_chat_Master.businesses_associated_with_this_group;

                dsetcm = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserAppChatMaster", param);
            }
            catch (Exception ex)
            {

            }
            if (dsetcm.Tables.Count > 0)
            {
                try
                {
                    if (dsetcm.Tables[0].Rows.Count > 0)
                    {
                        MySqlParameter[] param1 = new MySqlParameter[6];
                        //JObject json1 = JObject.Parse(obj_chat_Master.Message);

                        string GetMaxId = dsetcm.Tables[0].Rows[0]["MaxId"].ToString();

                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {
                            param1[0] = new MySqlParameter("p_Maxid", MySqlDbType.Int64);
                            param1[0].Value = GetMaxId;

                            param1[1] = new MySqlParameter("p_chat_type", MySqlDbType.Int64);
                            param1[1].Value = obj_chat_Master.chat_type;

                            param1[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param1[2].Value = obj_chat_Master.cust_id;

                            param1[3] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                            param1[3].Value = obj_chat_Master.created_by_user_id;

                            param1[4] = new MySqlParameter("p_Message", MySqlDbType.LongText);
                            param1[4].Value = obj_chat_Master.Message;

                            param1[5] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                            param1[5].Value = obj_chat_Master.created_timestamp;

                            dsetmaxid = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_CreateDynamicTablesBasedOnChatId", param1);
                        }

                        string getuserlistid = obj_chat_Master.UserList_Ids.ToString();
                        string[] getuserlistids = getuserlistid.Split(",");

                        if (dsetmaxid.Tables[0].Rows.Count > 0)
                        {
                            foreach (string UserList_Ids in getuserlistids)
                            {
                                MySqlParameter[] paramAssginuserlist = new MySqlParameter[7];
                                using MySqlConnection con2 = new MySqlConnection(connection);
                                {
                                    paramAssginuserlist[0] = new MySqlParameter("p_Maxid", MySqlDbType.Int64);
                                    paramAssginuserlist[0].Value = GetMaxId;

                                    paramAssginuserlist[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                    paramAssginuserlist[1].Value = obj_chat_Master.cust_id;

                                    paramAssginuserlist[2] = new MySqlParameter("p_UserList_Ids", MySqlDbType.LongText);
                                    paramAssginuserlist[2].Value = UserList_Ids;

                                    paramAssginuserlist[3] = new MySqlParameter("p_Message", MySqlDbType.LongText);
                                    paramAssginuserlist[3].Value = obj_chat_Master.Message;

                                    paramAssginuserlist[4] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                                    paramAssginuserlist[4].Value = obj_chat_Master.created_by_user_id;

                                    paramAssginuserlist[5] = new MySqlParameter("p_chat_type", MySqlDbType.Int64);
                                    paramAssginuserlist[5].Value = obj_chat_Master.chat_type;

                                    paramAssginuserlist[6] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                                    paramAssginuserlist[6].Value = obj_chat_Master.created_timestamp;

                                    dsetuserlist = SqlHelpher.ExecuteDataset(con2, CommandType.StoredProcedure, "SP_AssignChatUserListDetails", paramAssginuserlist);

                                }
                            }

                        }
                        string getuserlistid1 = obj_chat_Master.UserList_Ids.ToString();
                        string[] getuserlistids1 = getuserlistid1.Split(",");

                        if (dsetmaxid.Tables[0].Rows.Count > 0)
                        {
                            foreach (string UserList_Ids in getuserlistids)
                            {

                                MySqlParameter[] paramAssginuserlist = new MySqlParameter[6];
                                string GetMaxId1 = dsetcm.Tables[0].Rows[0]["MaxId"].ToString();


                                using MySqlConnection con2 = new MySqlConnection(connection);
                                {
                                    paramAssginuserlist[0] = new MySqlParameter("p_Maxid", MySqlDbType.Int64);
                                    paramAssginuserlist[0].Value = GetMaxId1;

                                    paramAssginuserlist[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                    paramAssginuserlist[1].Value = obj_chat_Master.cust_id;

                                    paramAssginuserlist[2] = new MySqlParameter("p_UserList_Ids", MySqlDbType.LongText);
                                    paramAssginuserlist[2].Value = UserList_Ids;

                                    paramAssginuserlist[3] = new MySqlParameter("p_Message", MySqlDbType.LongText);
                                    paramAssginuserlist[3].Value = obj_chat_Master.Message;

                                    paramAssginuserlist[4] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                                    paramAssginuserlist[4].Value = obj_chat_Master.created_timestamp;

                                    paramAssginuserlist[5] = new MySqlParameter("p_chat_type", MySqlDbType.Int64);
                                    paramAssginuserlist[5].Value = obj_chat_Master.chat_type;

                                    dsetuserlist = SqlHelpher.ExecuteDataset(con2, CommandType.StoredProcedure, "SP_LoopUserAppChatlist", paramAssginuserlist);
                                }
                            }
                        }
                        if (Convert.ToString(dsetuserlist.Tables[0].Rows[0]["Message"]) == "200")
                        {
                            response.Data = "";
                            response.Message = "Insert successfully";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(dsetuserlist.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(dsetuserlist.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }

                        return response;


                    }
                }
                catch (Exception ex)
                {

                }
            }
            return response;
        }






        public Response UpdateUserAppChatMaster(userapp_chat_master obj_chat_master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            try
            {

                MySqlParameter[] param = new MySqlParameter[13];
                {


                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[0].Value = obj_chat_master.chat_id;

                    param[1] = new MySqlParameter("p_group_chat_name", MySqlDbType.VarChar);
                    param[1].Value = obj_chat_master.group_chat_name;

                    param[2] = new MySqlParameter("p_chat_type", MySqlDbType.Int64);
                    param[2].Value = obj_chat_master.chat_type;

                    param[3] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                    param[3].Value = obj_chat_master.created_by_user_id;

                    param[4] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                    param[4].Value = obj_chat_master.created_timestamp;

                    param[5] = new MySqlParameter("p_auto_delete_old_messages_no_of_days", MySqlDbType.Int64);
                    param[5].Value = obj_chat_master.auto_delete_old_messages_no_of_days;

                    param[6] = new MySqlParameter("p_about_the_chat", MySqlDbType.VarChar);
                    param[6].Value = obj_chat_master.about_the_chat;

                    param[7] = new MySqlParameter("p_pin_chat_to_the_top_of_chat_list", MySqlDbType.VarChar);
                    param[7].Value = obj_chat_master.pin_chat_to_the_top_of_chat_list;

                    param[8] = new MySqlParameter("p_pin_message_timestamp", MySqlDbType.VarChar);
                    param[8].Value = obj_chat_master.pin_message_timestamp;


                    param[9] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[9].Value = obj_chat_master.cust_id;


                    param[10] = new MySqlParameter("p_user_profile", MySqlDbType.VarChar);
                    param[10].Value = obj_chat_master.user_profile;

                    param[11] = new MySqlParameter("p_auto_delete_old_messages", MySqlDbType.Bool);
                    param[11].Value = Convert.ToBoolean(obj_chat_master.auto_delete_old_messages);

                    param[12] = new MySqlParameter("p_businesses_associated_with_this_group", MySqlDbType.VarChar);
                    param[12].Value = obj_chat_master.businesses_associated_with_this_group;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserAppChatMaster", param);

                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Update ChatMaster successfully";
                    response.Status = true;


                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }

            }
            catch (Exception ex)
            {

            }
            return response;

        }

        public Response AddUserAppChatIdMessages(userapp_chat_Id_messages obj_chat_messages, userapp_chat_Id_messages mainobj)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            string attach = "[" + mainobj.attachment_file + "]";
            //string attach = '{' + "files"  + ':' + mainobj.attachment_file + '}';
            //// var json_attach = Newtonsoft.Json.JsonConvert.SerializeObject(attach);
            //JObject json_attach = new JObject(attach);    
            try
            {
                if (mainobj.attachment_file != "")
                {

                    MySqlParameter[] param = new MySqlParameter[6];

                    using MySqlConnection con = new MySqlConnection(connection);
                    {
                        param[0] = new MySqlParameter("p_message", MySqlDbType.LongText);
                        param[0].Value = obj_chat_messages.message;

                        param[1] = new MySqlParameter("p_sent_by_user_id", MySqlDbType.Int64);
                        param[1].Value = obj_chat_messages.sent_by_user_id;

                        param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param[2].Value = obj_chat_messages.cust_id;

                        param[3] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                        param[3].Value = obj_chat_messages.chat_id;

                        param[4] = new MySqlParameter("p_message_timestamp", MySqlDbType.VarChar);
                        param[4].Value = obj_chat_messages.message_timestamp;

                        param[5] = new MySqlParameter("p_attachment_file", MySqlDbType.VarChar);
                        //param[5].Value = mainobj.attachment_file;
                        param[5].Value = attach;

                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserAppChatIdAttachmentMessages", param);
                    }
                }

                if (mainobj.attachment_file == "")
                {

                    MySqlParameter[] param = new MySqlParameter[6];

                    using MySqlConnection con = new MySqlConnection(connection);
                    {
                        param[0] = new MySqlParameter("p_message", MySqlDbType.LongText);
                        param[0].Value = obj_chat_messages.message;

                        param[1] = new MySqlParameter("p_sent_by_user_id", MySqlDbType.Int64);
                        param[1].Value = obj_chat_messages.sent_by_user_id;

                        param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param[2].Value = obj_chat_messages.cust_id;

                        param[3] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                        param[3].Value = obj_chat_messages.chat_id;

                        param[4] = new MySqlParameter("p_message_timestamp", MySqlDbType.VarChar);
                        param[4].Value = obj_chat_messages.message_timestamp;

                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserAppChatIdMessages", param);
                    }
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Message Send successfully !!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;

                }

            }
            catch (Exception ex)
            {

            }
            return response;
        }


        public Response UpdateChatIdAdminUsersPermissions(chat_id_admin_users_permissions obj_admin_users_permissions)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            try
            {
                MySqlParameter[] param = new MySqlParameter[21];
                {


                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_set_permissions_to_group_members", MySqlDbType.Bool);
                    param[0].Value = obj_admin_users_permissions.set_permissions_to_group_members;

                    param[1] = new MySqlParameter("p_add_group_members", MySqlDbType.Bool);
                    param[1].Value = obj_admin_users_permissions.add_group_members;

                    param[2] = new MySqlParameter("p_delete_group_members", MySqlDbType.Bool);
                    param[2].Value = obj_admin_users_permissions.delete_group_members;

                    param[3] = new MySqlParameter("p_send_messages_reply_to_messages", MySqlDbType.Bool);
                    param[3].Value = obj_admin_users_permissions.send_messages_reply_to_messages;



                    param[4] = new MySqlParameter("p_edit_messages_sent_by_himself_herself_within_minutes", MySqlDbType.Int64);
                    param[4].Value = obj_admin_users_permissions.edit_messages_sent_by_himself_herself_within_minutes;

                    param[5] = new MySqlParameter("P_delete_messages_sent_by_himself_herself_within_minutes", MySqlDbType.Int64);
                    param[5].Value = obj_admin_users_permissions.delete_messages_sent_by_himself_herself_within_minutes;

                    param[6] = new MySqlParameter("p_hide_messages_sent_by_himself_herself_within_minutes", MySqlDbType.Int64);
                    param[6].Value = obj_admin_users_permissions.hide_messages_sent_by_himself_herself_within_minutes;


                    param[7] = new MySqlParameter("p_hide_messages_of_other_users", MySqlDbType.Bool);
                    param[7].Value = obj_admin_users_permissions.hide_messages_of_other_users;

                    param[8] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[8].Value = "Update";

                    param[9] = new MySqlParameter("p_pin_messages_to_the_top_of_chat_window", MySqlDbType.Bool);
                    param[9].Value = obj_admin_users_permissions.pin_messages_to_the_top_of_chat_window;

                    param[10] = new MySqlParameter("p_ping_messages", MySqlDbType.Bool);
                    param[10].Value = obj_admin_users_permissions.ping_messages;

                    param[11] = new MySqlParameter("p_forward_share_messages", MySqlDbType.Bool);
                    param[11].Value = obj_admin_users_permissions.forward_share_messages;

                    param[12] = new MySqlParameter("p_export_chat", MySqlDbType.Bool);
                    param[12].Value = obj_admin_users_permissions.export_chat;

                    param[13] = new MySqlParameter("p_limit_access_to_chat_messages_from_last_no_of_days", MySqlDbType.Int64);
                    param[13].Value = obj_admin_users_permissions.limit_access_to_chat_messages_from_last_no_of_days;



                    param[14] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[14].Value = obj_admin_users_permissions.chat_id;


                    param[15] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[15].Value = obj_admin_users_permissions.cust_id;


                    param[16] = new MySqlParameter("p_edit_messages_sent_by_himself_herself", MySqlDbType.Bool);
                    param[16].Value = obj_admin_users_permissions.edit_messages_sent_by_himself_herself;


                    param[17] = new MySqlParameter("P_delete_messages_sent_by_himself_herself", MySqlDbType.Bool);
                    param[17].Value = obj_admin_users_permissions.delete_messages_sent_by_himself_herself;

                    param[18] = new MySqlParameter("p_hide_messages_sent_by_himself_herself", MySqlDbType.Bool);
                    param[18].Value = obj_admin_users_permissions.hide_messages_sent_by_himself_herself;

                    param[19] = new MySqlParameter("p_limit_access_to_chat_messages_from", MySqlDbType.Bool);
                    param[19].Value = obj_admin_users_permissions.limit_access_to_chat_messages_from;

                    param[20] = new MySqlParameter("p_user_list_id", MySqlDbType.Bool);
                    param[20].Value = obj_admin_users_permissions.user_list_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateChatIdAdminUsersPermissions", param);

                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Update  successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }


            }

            catch (Exception ex)
            {

            }
            return response;

        }


        public Response UpdateGroupMemberUsersPermissions(group_member_users_permissions obj_group_member_users_permissions)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[22];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_add_group_members", MySqlDbType.Bool);
                    param[0].Value = obj_group_member_users_permissions.add_group_members;

                    param[1] = new MySqlParameter("p_delete_group_members", MySqlDbType.Bool);
                    param[1].Value = obj_group_member_users_permissions.delete_group_members;

                    param[2] = new MySqlParameter("p_send_messages", MySqlDbType.Bool);
                    param[2].Value = obj_group_member_users_permissions.send_messages;

                    param[3] = new MySqlParameter("p_reply_to_messages", MySqlDbType.Bool);
                    param[3].Value = obj_group_member_users_permissions.reply_to_messages;

                    param[4] = new MySqlParameter("p_edit_messages_sent_by_himself_herself_within_minutes", MySqlDbType.Int32);
                    param[4].Value = obj_group_member_users_permissions.edit_messages_sent_by_himself_herself_within_minutes;

                    param[5] = new MySqlParameter("p_delete_messages_sent_by_himself_herself_within_minutes", MySqlDbType.Int64);
                    param[5].Value = obj_group_member_users_permissions.delete_messages_sent_by_himself_herself_within_minutes;

                    param[6] = new MySqlParameter("p_hide_messages_sent_by_himself_herself_within_minutes", MySqlDbType.Int64);
                    param[6].Value = obj_group_member_users_permissions.hide_messages_sent_by_himself_herself_within_minutes;

                    param[7] = new MySqlParameter("p_hide_messages_of_other_users", MySqlDbType.Bool);
                    param[7].Value = obj_group_member_users_permissions.hide_messages_of_other_users;

                    param[8] = new MySqlParameter("p_pin_messages_to_the_top_of_chat_window", MySqlDbType.Bool);
                    param[8].Value = obj_group_member_users_permissions.pin_messages_to_the_top_of_chat_window;

                    param[9] = new MySqlParameter("p_ping_messages", MySqlDbType.Bool);
                    param[9].Value = obj_group_member_users_permissions.ping_messages;

                    param[10] = new MySqlParameter("p_forward_share_messages", MySqlDbType.Bool);
                    param[10].Value = obj_group_member_users_permissions.forward_share_messages;

                    param[11] = new MySqlParameter("p_export_chat", MySqlDbType.Bool);
                    param[11].Value = obj_group_member_users_permissions.export_chat;

                    param[12] = new MySqlParameter("p_copy_message_text", MySqlDbType.Bool);
                    param[12].Value = obj_group_member_users_permissions.copy_message_text;

                    param[13] = new MySqlParameter("p_limit_access_to_chat_messages_from_last_no_of_days", MySqlDbType.Int64);
                    param[13].Value = obj_group_member_users_permissions.limit_access_to_chat_messages_from_last_no_of_days;

                    param[14] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[14].Value = "Update";

                    param[15] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[15].Value = obj_group_member_users_permissions.cust_id;

                    param[16] = new MySqlParameter("p_MaxId", MySqlDbType.Int64);
                    param[16].Value = obj_group_member_users_permissions.chat_id;

                    param[17] = new MySqlParameter("p_edit_messages_sent_by_himself_herself", MySqlDbType.Bool);
                    param[17].Value = obj_group_member_users_permissions.edit_messages_sent_by_himself_herself;

                    param[18] = new MySqlParameter("P_delete_messages_sent_by_himself_herself", MySqlDbType.Bool);
                    param[18].Value = obj_group_member_users_permissions.delete_messages_sent_by_himself_herself;

                    param[19] = new MySqlParameter("p_hide_messages_sent_by_himself_herself", MySqlDbType.Bool);
                    param[19].Value = obj_group_member_users_permissions.hide_messages_sent_by_himself_herself;

                    param[20] = new MySqlParameter("p_limit_access_to_chat_messages_from", MySqlDbType.Bool);
                    param[20].Value = obj_group_member_users_permissions.limit_access_to_chat_messages_from;

                    param[21] = new MySqlParameter("p_user_list_id", MySqlDbType.Int64);
                    param[21].Value = obj_group_member_users_permissions.user_list_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateGroupMemberUsersPermissions", param);

                }
                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Update  successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }




        public Response UpdateCustomMemberPermissionsForUserId(custom_member_permissions_for_user_id obj_custom_member_permissions_for_user_id)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[23];
                {

                    using MySqlConnection con = new MySqlConnection(connection);


                    param[0] = new MySqlParameter("p_add_Invite_group_members", MySqlDbType.Bool);
                    param[0].Value = obj_custom_member_permissions_for_user_id.add_Invite_group_members;

                    param[1] = new MySqlParameter("p_delete_group_members", MySqlDbType.Bool);
                    param[1].Value = obj_custom_member_permissions_for_user_id.delete_group_members;

                    param[2] = new MySqlParameter("p_send_messages", MySqlDbType.Bool);
                    param[2].Value = obj_custom_member_permissions_for_user_id.send_messages;

                    param[3] = new MySqlParameter("p_reply_to_messages", MySqlDbType.Bool);
                    param[3].Value = obj_custom_member_permissions_for_user_id.reply_to_messages;

                    param[4] = new MySqlParameter("p_edit_messages_sent_by_himself_herself_within_minutes", MySqlDbType.Int64);
                    param[4].Value = obj_custom_member_permissions_for_user_id.edit_messages_sent_by_himself_herself_within_minutes;

                    param[5] = new MySqlParameter("p_delete_messages_sent_by_himself_herself_within_minutes", MySqlDbType.Int64);
                    param[5].Value = obj_custom_member_permissions_for_user_id.delete_messages_sent_by_himself_herself_within_minutes;

                    param[6] = new MySqlParameter("p_hide_messages_sent_by_himself_herself_within_minutes", MySqlDbType.Int64);
                    param[6].Value = obj_custom_member_permissions_for_user_id.hide_messages_sent_by_himself_herself_within_minutes;

                    param[7] = new MySqlParameter("p_hide_messages_of_other_users", MySqlDbType.Bool);
                    param[7].Value = obj_custom_member_permissions_for_user_id.hide_messages_of_other_users;

                    param[8] = new MySqlParameter("p_pin_messages_to_the_top_of_chat_window", MySqlDbType.Bool);
                    param[8].Value = obj_custom_member_permissions_for_user_id.pin_messages_to_the_top_of_chat_window;

                    param[9] = new MySqlParameter("p_ping_messages", MySqlDbType.Bool);
                    param[9].Value = obj_custom_member_permissions_for_user_id.ping_messages;

                    param[10] = new MySqlParameter("p_forward_share_messages", MySqlDbType.Bool);
                    param[10].Value = obj_custom_member_permissions_for_user_id.forward_share_messages;

                    param[11] = new MySqlParameter("p_export_chat", MySqlDbType.Bool);
                    param[11].Value = obj_custom_member_permissions_for_user_id.export_chat;

                    param[12] = new MySqlParameter("p_copy_message_text", MySqlDbType.Bool);
                    param[12].Value = obj_custom_member_permissions_for_user_id.copy_message_text;

                    param[13] = new MySqlParameter("p_limit_access_to_chat_messages_from_last_no_of_days", MySqlDbType.Int64);
                    param[13].Value = obj_custom_member_permissions_for_user_id.limit_access_to_chat_messages_from_last_no_of_days;

                    param[14] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[14].Value = "Update";

                    param[15] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[15].Value = obj_custom_member_permissions_for_user_id.cust_id;

                    param[16] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[16].Value = obj_custom_member_permissions_for_user_id.chat_id;

                    param[17] = new MySqlParameter("p_edit_messages_sent_by_himself_herself", MySqlDbType.Bool);
                    param[17].Value = obj_custom_member_permissions_for_user_id.edit_messages_sent_by_himself_herself;

                    param[18] = new MySqlParameter("P_delete_messages_sent_by_himself_herself", MySqlDbType.Bool);
                    param[18].Value = obj_custom_member_permissions_for_user_id.delete_messages_sent_by_himself_herself;

                    param[19] = new MySqlParameter("p_hide_messages_sent_by_himself_herself", MySqlDbType.Bool);
                    param[19].Value = obj_custom_member_permissions_for_user_id.hide_messages_sent_by_himself_herself;

                    param[20] = new MySqlParameter("p_limit_access_to_chat_messages_from", MySqlDbType.Bool);
                    param[20].Value = obj_custom_member_permissions_for_user_id.limit_access_to_chat_messages_from;

                    param[21] = new MySqlParameter("p_user_list_id", MySqlDbType.Bool);
                    param[21].Value = obj_custom_member_permissions_for_user_id.user_list_id;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateChatIdCustomMemberPermissionsForUserId", param);

                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "update successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }




        public Response DeleteUserAppChatMasterById(string CustId, Int64 ChatId)
        {
            Response response = new Response();
            DataSet dsetcm = new DataSet();

            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[0].Value = ChatId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    dsetcm = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "DeleteUserAppChatMasterById", param);

                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }


        public List<users_and_groups_profiles_common_class> GetUserAppChatMasterById(string CustId, Int64 ChatId, Int64 UserId)
        {

            List<users_and_groups_profiles_common_class> List_obj_users_and_groups_profiles_common_class = new List<users_and_groups_profiles_common_class>();
            users_and_groups_profiles_common_class obj_users_and_groups_profiles_common_class = new users_and_groups_profiles_common_class();


            user_permissions_common_class obj_user_permissions_common_class = new user_permissions_common_class();


            Response response = new Response();
            DataTable dsetcm = new DataTable();
            DataTable ds = new DataTable();
            DataTable ds1 = new DataTable();
            DataTable ds2 = new DataTable();
            DataTable ds3 = new DataTable();
            DataTable ds4 = new DataTable();
            DataTable ds5 = new DataTable();
            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[1].Value = ChatId;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[2].Value = UserId;

                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetByIdUserAppChatMaster", param);


                    var chat_id = Convert.ToInt32(dsetcm.Rows[0]["chat_id"].ToString());
                    var group_chat_name = Convert.ToString(dsetcm.Rows[0]["group_chat_name"].ToString());
                    var chat_type = Convert.ToInt32(dsetcm.Rows[0]["chat_type"].ToString());
                    var created_by_user_id = Convert.ToInt32(dsetcm.Rows[0]["created_by_user_id"].ToString());
                    var created_timestamp = Convert.ToString(dsetcm.Rows[0]["created_timestamp"].ToString());
                    var auto_delete_old_messages_no_of_days = Convert.ToInt32(dsetcm.Rows[0]["auto_delete_old_messages_no_of_days"].ToString());

                    var auto_delete_old_messages = Convert.ToInt32(dsetcm.Rows[0]["auto_delete_old_messages"]);
                    var about_the_chat = Convert.ToString(dsetcm.Rows[0]["about_the_chat"].ToString());
                    var businesses_associated_with_this_group = Convert.ToString(dsetcm.Rows[0]["businesses_associated_with_this_group"].ToString());
                    var pin_chat_to_the_top_of_chat_list = Convert.ToString(dsetcm.Rows[0]["pin_chat_to_the_top_of_chat_list"].ToString());
                    var pin_message_timestamp = Convert.ToString(dsetcm.Rows[0]["pin_message_timestamp"].ToString());
                    var user_profile = Convert.ToString(dsetcm.Rows[0]["user_profile"].ToString());

                    obj_users_and_groups_profiles_common_class.chat_id = chat_id;
                    obj_users_and_groups_profiles_common_class.group_chat_name = group_chat_name;
                    obj_users_and_groups_profiles_common_class.chat_type = chat_type;
                    obj_users_and_groups_profiles_common_class.created_by_user_id = created_by_user_id;
                    obj_users_and_groups_profiles_common_class.created_timestamp = created_timestamp;
                    obj_users_and_groups_profiles_common_class.auto_delete_old_messages_no_of_days = auto_delete_old_messages_no_of_days;
                    obj_users_and_groups_profiles_common_class.auto_delete_old_messages = auto_delete_old_messages;
                    obj_users_and_groups_profiles_common_class.about_the_chat = about_the_chat;
                    obj_users_and_groups_profiles_common_class.businesses_associated_with_this_group = businesses_associated_with_this_group;
                    obj_users_and_groups_profiles_common_class.pin_chat_to_the_top_of_chat_list = pin_chat_to_the_top_of_chat_list;
                    obj_users_and_groups_profiles_common_class.pin_message_timestamp = pin_message_timestamp;
                    obj_users_and_groups_profiles_common_class.user_profile = user_profile;

                   if (chat_type == 1)
                    {

                        MySqlParameter[] param3 = new MySqlParameter[4];
                        try
                        {
                            using MySqlConnection con3 = new MySqlConnection(connection);
                            {
                                param3[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param3[0].Value = CustId;

                                param3[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                param3[1].Value = ChatId;

                                param3[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                param3[2].Value = UserId;

                                param3[3] = new MySqlParameter("p_Action", MySqlDbType.Int64);
                                param3[3].Value = "One_To_One_Chat";

                                ds3 = SqlHelpher.ExecuteDataTable(con3, CommandType.StoredProcedure, "SP_GetReceiverUserIdAndUserPermissionsCategoryBaseOnUserId", param3);   // here make some alteration important
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        // one t one and group logig start here 
                        var receiver_user_id = Convert.ToInt32(ds3.Rows[0]["user_id"].ToString());
                        var chat_members = Convert.ToInt32(ds3.Rows[0]["members"].ToString());

                        obj_users_and_groups_profiles_common_class.receiver_user_id = receiver_user_id;
                        obj_users_and_groups_profiles_common_class.chat_members = chat_members;

                        MySqlParameter[] param1 = new MySqlParameter[5];
                        try
                        {
                            using MySqlConnection con1 = new MySqlConnection(connection);
                            {
                                param1[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param1[0].Value = CustId;

                                param1[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                param1[1].Value = ChatId;

                                param1[2] = new MySqlParameter("p_receiver_user_id", MySqlDbType.Int64);
                                param1[2].Value = receiver_user_id;

                                param1[3] = new MySqlParameter("p_sender_user_id", MySqlDbType.Int64);
                                param1[3].Value = UserId;

                                param1[4] = new MySqlParameter("p_Action", MySqlDbType.Int64);
                                param1[4].Value = "Get_Receiver_User_Blocked_Status";

                                ds1 = SqlHelpher.ExecuteDataTable(con1, CommandType.StoredProcedure, "SP_GetReceiverUserBlockedStatusAndSenderUserBlockedStatus", param1);

                                var receiver_pin_to_top_of_list_no = Convert.ToInt32(ds1.Rows[0]["pin_to_top_of_list_no"].ToString());
                                var receiver_number_of_unread_messages = Convert.ToBoolean(ds1.Rows[0]["number_of_unread_messages"].ToString());
                                var receiver_mute_notifications_from_this_chat = Convert.ToBoolean(ds1.Rows[0]["mute_notifications_from_this_chat"].ToString());
                                var receiver_user_blocked_status = Convert.ToBoolean(ds1.Rows[0]["user_blocked_status"].ToString());
                                var receiver_user_name = Convert.ToString(ds1.Rows[0]["receiver_user_name"].ToString());

                                obj_users_and_groups_profiles_common_class.receiver_pin_to_top_of_list_no = receiver_pin_to_top_of_list_no;
                                obj_users_and_groups_profiles_common_class.receiver_number_of_unread_messages = receiver_number_of_unread_messages;
                                obj_users_and_groups_profiles_common_class.receiver_mute_notifications_from_this_chat = receiver_mute_notifications_from_this_chat;
                                obj_users_and_groups_profiles_common_class.receiver_user_blocked_status = receiver_user_blocked_status;
                                obj_users_and_groups_profiles_common_class.receiver_user_name = receiver_user_name;

                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        MySqlParameter[] param2 = new MySqlParameter[5];
                        try
                        {
                            using MySqlConnection con2 = new MySqlConnection(connection);
                            {
                                param2[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param2[0].Value = CustId;

                                param2[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                param2[1].Value = ChatId;

                                param2[2] = new MySqlParameter("p_receiver_user_id", MySqlDbType.Int64);
                                param2[2].Value = receiver_user_id;

                                param2[3] = new MySqlParameter("p_sender_user_id", MySqlDbType.Int64);
                                param2[3].Value = UserId;

                                param2[4] = new MySqlParameter("p_Action", MySqlDbType.Int64);
                                param2[4].Value = "Get_Sender_User_Blocked_Status";

                                ds2 = SqlHelpher.ExecuteDataTable(con2, CommandType.StoredProcedure, "SP_GetReceiverUserBlockedStatusAndSenderUserBlockedStatus", param2);

                                var Sender_pin_to_top_of_list_no = Convert.ToInt32(ds2.Rows[0]["pin_to_top_of_list_no"].ToString());
                                var Sender_number_of_unread_messages = Convert.ToBoolean(ds2.Rows[0]["number_of_unread_messages"].ToString());
                                var Sender_mute_notifications_from_this_chat = Convert.ToBoolean(ds2.Rows[0]["mute_notifications_from_this_chat"].ToString());
                                var Sender_user_blocked_status = Convert.ToBoolean(ds2.Rows[0]["user_blocked_status"].ToString());
                                var sender_user_name = Convert.ToString(ds2.Rows[0]["sender_user_name"].ToString());

                                obj_users_and_groups_profiles_common_class.pin_to_top_of_list_no = Sender_pin_to_top_of_list_no;
                                obj_users_and_groups_profiles_common_class.number_of_unread_messages = Sender_number_of_unread_messages;
                                obj_users_and_groups_profiles_common_class.mute_notifications_from_this_chat = Sender_mute_notifications_from_this_chat;
                                obj_users_and_groups_profiles_common_class.user_blocked_status = Sender_user_blocked_status;
                                obj_users_and_groups_profiles_common_class.user_name = sender_user_name;


                                List_obj_users_and_groups_profiles_common_class.Add(obj_users_and_groups_profiles_common_class);
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                   else if(chat_type == 0)
                    {

                        MySqlParameter[] param4 = new MySqlParameter[4];
                        try
                        {
                            using MySqlConnection con4 = new MySqlConnection(connection);
                            {
                                param4[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param4[0].Value = CustId;

                                param4[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                param4[1].Value = ChatId;

                                param4[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                param4[2].Value = UserId;

                                param4[3] = new MySqlParameter("p_Action", MySqlDbType.Int64);
                                param4[3].Value = "GetGroupMemberCount";

                                ds4 = SqlHelpher.ExecuteDataTable(con4, CommandType.StoredProcedure, "SP_GetReceiverUserIdAndUserPermissionsCategoryBaseOnUserId", param4);   // here make some alteration important
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        var chat_members = Convert.ToInt32(ds4.Rows[0]["members"]);
                        obj_users_and_groups_profiles_common_class.chat_members = chat_members;

                        MySqlParameter[] param3 = new MySqlParameter[4];
                        try
                        {
                            using MySqlConnection con3 = new MySqlConnection(connection);
                            {
                                param3[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param3[0].Value = CustId;

                                param3[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                param3[1].Value = ChatId;

                                param3[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                param3[2].Value = UserId;

                                param3[3] = new MySqlParameter("p_Action", MySqlDbType.Int64);
                                param3[3].Value = "GetUserPermissionsCategoryBaseOnUserId";

                                ds3 = SqlHelpher.ExecuteDataTable(con3, CommandType.StoredProcedure, "SP_GetReceiverUserIdAndUserPermissionsCategoryBaseOnUserId", param3);   // here make some alteration important
                            }
                        }
                        catch (Exception ex)
                        {

                        }     
                        var sender_user_permissions_category = Convert.ToInt32(ds3.Rows[0]["user_permissions_category"].ToString());          
                        obj_users_and_groups_profiles_common_class.sender_user_permissions_category = sender_user_permissions_category;         

                        MySqlParameter[] param2 = new MySqlParameter[5];
                        try
                        {
                            using MySqlConnection con2 = new MySqlConnection(connection);
                            {
                                param2[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param2[0].Value = CustId;

                                param2[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                param2[1].Value = ChatId;

                                param2[2] = new MySqlParameter("p_receiver_user_id", MySqlDbType.Int64);
                                param2[2].Value = 0 ;

                                param2[3] = new MySqlParameter("p_sender_user_id", MySqlDbType.Int64);
                                param2[3].Value = UserId;

                                param2[4] = new MySqlParameter("p_Action", MySqlDbType.Int64);
                                param2[4].Value = "Get_Sender_User_Blocked_Status";

                                ds2 = SqlHelpher.ExecuteDataTable(con2, CommandType.StoredProcedure, "SP_GetReceiverUserBlockedStatusAndSenderUserBlockedStatus", param2);

                                var Sender_pin_to_top_of_list_no = Convert.ToInt32(ds2.Rows[0]["pin_to_top_of_list_no"].ToString());
                                var Sender_number_of_unread_messages = Convert.ToBoolean(ds2.Rows[0]["number_of_unread_messages"].ToString());
                                var Sender_mute_notifications_from_this_chat = Convert.ToBoolean(ds2.Rows[0]["mute_notifications_from_this_chat"].ToString());
                                var Sender_user_blocked_status = Convert.ToBoolean(ds2.Rows[0]["user_blocked_status"].ToString());
                                var sender_user_name = Convert.ToString(ds2.Rows[0]["sender_user_name"].ToString());

                                obj_users_and_groups_profiles_common_class.pin_to_top_of_list_no = Sender_pin_to_top_of_list_no;
                                obj_users_and_groups_profiles_common_class.number_of_unread_messages = Sender_number_of_unread_messages;
                                obj_users_and_groups_profiles_common_class.mute_notifications_from_this_chat = Sender_mute_notifications_from_this_chat;
                                obj_users_and_groups_profiles_common_class.user_blocked_status = Sender_user_blocked_status;
                                obj_users_and_groups_profiles_common_class.user_name = sender_user_name;


                               // List_obj_users_and_groups_profiles_common_class.Add(obj_users_and_groups_profiles_common_class);
                            }
                        }
                        catch (Exception ex)
                        {

                        }


                        // user all premissions

                        MySqlParameter[] param5 = new MySqlParameter[4];
                        try
                        {
                            using MySqlConnection con5 = new MySqlConnection(connection);
                            {
                                param5[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param5[0].Value = CustId;

                                param5[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                param5[1].Value = ChatId;      

                                param5[2] = new MySqlParameter("p_sender_user_id", MySqlDbType.Int64); 
                                param5[2].Value = UserId;

                                param5[3] = new MySqlParameter("p_sender_user_permissions_category", MySqlDbType.Int64); 
                                param5[3].Value = sender_user_permissions_category;

                                ds5 = SqlHelpher.ExecuteDataTable(con5, CommandType.StoredProcedure, "SP_GetUserPermissionsCategoryDetailsBasedOnUserId", param5);

                                if(sender_user_permissions_category == 1)
                                {
                                    var chat_id1 = Convert.ToInt32(ds5.Rows[0]["chat_id"].ToString());
                                    var set_permissions_to_group_members = Convert.ToBoolean(ds5.Rows[0]["set_permissions_to_group_members"].ToString());
                                    var add_group_members = Convert.ToBoolean(ds5.Rows[0]["add_group_members"].ToString());
                                    var delete_group_members = Convert.ToBoolean(ds5.Rows[0]["delete_group_members"].ToString());
                                    var send_messages_reply_to_messages = Convert.ToBoolean(ds5.Rows[0]["send_messages_reply_to_messages"].ToString());
                                    var edit_messages_sent_by_himself_herself_within_minutes = Convert.ToInt32(ds5.Rows[0]["edit_messages_sent_by_himself_herself_within_minutes"].ToString());
                                    var delete_messages_sent_by_himself_herself_within_minutes = Convert.ToInt32(ds5.Rows[0]["delete_messages_sent_by_himself_herself_within_minutes"].ToString());
                                    var hide_messages_sent_by_himself_herself_within_minutes = Convert.ToInt32(ds5.Rows[0]["hide_messages_sent_by_himself_herself_within_minutes"].ToString());
                                    var hide_messages_of_other_users = Convert.ToBoolean(ds5.Rows[0]["hide_messages_of_other_users"].ToString());
                                    var pin_messages_to_the_top_of_chat_window = Convert.ToBoolean(ds5.Rows[0]["pin_messages_to_the_top_of_chat_window"].ToString());
                                    var ping_messages = Convert.ToBoolean(ds5.Rows[0]["ping_messages"].ToString());
                                    var forward_share_messages = Convert.ToBoolean(ds5.Rows[0]["forward_share_messages"].ToString());
                                    var export_chat = Convert.ToBoolean(ds5.Rows[0]["export_chat"].ToString());
                                    var limit_access_to_chat_messages_from_last_no_of_days = Convert.ToInt32(ds5.Rows[0]["limit_access_to_chat_messages_from_last_no_of_days"].ToString());
                                    var limit_access_to_chat_messages_from = Convert.ToBoolean(ds5.Rows[0]["limit_access_to_chat_messages_from"].ToString());

                                    obj_user_permissions_common_class.chat_id = chat_id1;
                                    obj_user_permissions_common_class.set_permissions_to_group_members = set_permissions_to_group_members;
                                    obj_user_permissions_common_class.add_group_members = add_group_members;
                                    obj_user_permissions_common_class.delete_group_members = delete_group_members;
                                    obj_user_permissions_common_class.send_messages_reply_to_messages = send_messages_reply_to_messages;
                                    obj_user_permissions_common_class.edit_messages_sent_by_himself_herself_within_minutes = edit_messages_sent_by_himself_herself_within_minutes;
                                    obj_user_permissions_common_class.delete_messages_sent_by_himself_herself_within_minutes = delete_messages_sent_by_himself_herself_within_minutes;
                                    obj_user_permissions_common_class.hide_messages_sent_by_himself_herself_within_minutes = hide_messages_sent_by_himself_herself_within_minutes;
                                    obj_user_permissions_common_class.hide_messages_of_other_users = hide_messages_of_other_users;
                                    obj_user_permissions_common_class.pin_messages_to_the_top_of_chat_window = pin_messages_to_the_top_of_chat_window;
                                    obj_user_permissions_common_class.ping_messages = ping_messages;
                                    obj_user_permissions_common_class.forward_share_messages = forward_share_messages;
                                    obj_user_permissions_common_class.export_chat = export_chat;
                                    obj_user_permissions_common_class.limit_access_to_chat_messages_from_last_no_of_days = limit_access_to_chat_messages_from_last_no_of_days;
                                    obj_user_permissions_common_class.limit_access_to_chat_messages_from = limit_access_to_chat_messages_from;

                                    obj_users_and_groups_profiles_common_class.user_permissions = (obj_user_permissions_common_class);  // json inside json formate
                                }

                                else if (sender_user_permissions_category == 2)
                                {


                                    var chat_id2 = Convert.ToInt32(ds5.Rows[0]["chat_id"].ToString());
                                    var add_group_members = Convert.ToBoolean(ds5.Rows[0]["add_group_members"].ToString());
                                    var delete_group_members = Convert.ToBoolean(ds5.Rows[0]["delete_group_members"].ToString());
                                    var send_messages = Convert.ToBoolean(ds5.Rows[0]["send_messages"].ToString());

                                    var reply_to_messages = Convert.ToBoolean(ds5.Rows[0]["reply_to_messages"].ToString());

                                    var edit_messages_sent_by_himself_herself_within_minutes = Convert.ToInt32(ds5.Rows[0]["edit_messages_sent_by_himself_herself_within_minutes"].ToString());
                                    var delete_messages_sent_by_himself_herself_within_minutes = Convert.ToInt32(ds5.Rows[0]["delete_messages_sent_by_himself_herself_within_minutes"].ToString());
                                    var hide_messages_sent_by_himself_herself = Convert.ToBoolean(ds5.Rows[0]["hide_messages_sent_by_himself_herself"].ToString());
                                    var hide_messages_of_other_users = Convert.ToBoolean(ds5.Rows[0]["hide_messages_of_other_users"].ToString());
                                    var pin_messages_to_the_top_of_chat_window = Convert.ToBoolean(ds5.Rows[0]["pin_messages_to_the_top_of_chat_window"].ToString());
                                    var ping_messages = Convert.ToBoolean(ds5.Rows[0]["ping_messages"].ToString());
                                    var forward_share_messages = Convert.ToBoolean(ds5.Rows[0]["forward_share_messages"].ToString());
                                    var export_chat = Convert.ToBoolean(ds5.Rows[0]["export_chat"].ToString());
                                    var copy_message_text = Convert.ToBoolean(ds5.Rows[0]["copy_message_text"].ToString());
                                    var limit_access_to_chat_messages_from_last_no_of_days = Convert.ToInt32(ds5.Rows[0]["limit_access_to_chat_messages_from_last_no_of_days"].ToString());
                                    var limit_access_to_chat_messages_from = Convert.ToBoolean(ds5.Rows[0]["limit_access_to_chat_messages_from"].ToString());

                                    obj_user_permissions_common_class.chat_id = chat_id2;
                                    obj_user_permissions_common_class.add_group_members = add_group_members;
                                    obj_user_permissions_common_class.delete_group_members = delete_group_members;
                                    obj_user_permissions_common_class.send_messages = send_messages;
                                    obj_user_permissions_common_class.reply_to_messages = reply_to_messages;
                                    obj_user_permissions_common_class.edit_messages_sent_by_himself_herself_within_minutes = edit_messages_sent_by_himself_herself_within_minutes;
                                    obj_user_permissions_common_class.delete_messages_sent_by_himself_herself_within_minutes = delete_messages_sent_by_himself_herself_within_minutes;
                                    obj_user_permissions_common_class.hide_messages_sent_by_himself_herself = hide_messages_sent_by_himself_herself;
                                    obj_user_permissions_common_class.hide_messages_of_other_users = hide_messages_of_other_users;
                                    obj_user_permissions_common_class.pin_messages_to_the_top_of_chat_window = pin_messages_to_the_top_of_chat_window;
                                    obj_user_permissions_common_class.ping_messages = ping_messages;
                                    obj_user_permissions_common_class.export_chat = export_chat;
                                    obj_user_permissions_common_class.copy_message_text = copy_message_text;
                                    obj_user_permissions_common_class.limit_access_to_chat_messages_from_last_no_of_days = limit_access_to_chat_messages_from_last_no_of_days;
                                    obj_user_permissions_common_class.limit_access_to_chat_messages_from = limit_access_to_chat_messages_from;


                                    obj_users_and_groups_profiles_common_class.user_permissions = (obj_user_permissions_common_class);  // json inside json formate
                                }



                                else if (sender_user_permissions_category == 3)
                                {


                                   var chat_id3 = Convert.ToInt32(ds5.Rows[0]["chat_id"].ToString());
                                    var add_Invite_group_members = Convert.ToBoolean(ds5.Rows[0]["add_Invite_group_members"].ToString());
                                    var delete_group_members = Convert.ToBoolean(ds5.Rows[0]["delete_group_members"].ToString());
                                    var send_messages = Convert.ToBoolean(ds5.Rows[0]["send_messages"].ToString());
                                    var reply_to_messages = Convert.ToBoolean(ds5.Rows[0]["reply_to_messages"].ToString());
                                    var edit_messages_sent_by_himself_herself_within_minutes = Convert.ToInt32(ds5.Rows[0]["edit_messages_sent_by_himself_herself_within_minutes"].ToString());
                                    var delete_messages_sent_by_himself_herself_within_minutes = Convert.ToInt32(ds5.Rows[0]["delete_messages_sent_by_himself_herself_within_minutes"].ToString());
                                    var hide_messages_sent_by_himself_herself_within_minutes = Convert.ToInt32(ds5.Rows[0]["hide_messages_sent_by_himself_herself_within_minutes"].ToString());


                                    var delete_messages_sent_by_himself_herself = Convert.ToBoolean(ds5.Rows[0]["delete_messages_sent_by_himself_herself"].ToString());
                                    var hide_messages_sent_by_himself_herself = Convert.ToBoolean(ds5.Rows[0]["hide_messages_sent_by_himself_herself"].ToString());
                                    var pin_messages_to_the_top_of_chat_window = Convert.ToBoolean(ds5.Rows[0]["pin_messages_to_the_top_of_chat_window"].ToString());
                                    var ping_messages = Convert.ToBoolean(ds5.Rows[0]["ping_messages"].ToString());
                                    var forward_share_messages = Convert.ToBoolean(ds5.Rows[0]["forward_share_messages"].ToString());
                                    var export_chat = Convert.ToBoolean(ds5.Rows[0]["export_chat"].ToString());
                                    var copy_message_text = Convert.ToBoolean(ds5.Rows[0]["copy_message_text"].ToString());
                                    var limit_access_to_chat_messages_from_last_no_of_days = Convert.ToInt32(ds5.Rows[0]["limit_access_to_chat_messages_from_last_no_of_days"].ToString());
                                    var limit_access_to_chat_messages_from = Convert.ToBoolean(ds5.Rows[0]["limit_access_to_chat_messages_from"].ToString());


                                      obj_user_permissions_common_class.chat_id = chat_id3;
                                    obj_user_permissions_common_class.add_Invite_group_members = add_Invite_group_members;
                                    obj_user_permissions_common_class.delete_group_members = delete_group_members;
                                    obj_user_permissions_common_class.send_messages = send_messages;
                                    obj_user_permissions_common_class.reply_to_messages = reply_to_messages;
                                    obj_user_permissions_common_class.edit_messages_sent_by_himself_herself_within_minutes = edit_messages_sent_by_himself_herself_within_minutes;
                                    obj_user_permissions_common_class.delete_messages_sent_by_himself_herself_within_minutes = delete_messages_sent_by_himself_herself_within_minutes;
                                    obj_user_permissions_common_class.hide_messages_sent_by_himself_herself_within_minutes = hide_messages_sent_by_himself_herself_within_minutes;
                                    obj_user_permissions_common_class.delete_messages_sent_by_himself_herself = delete_messages_sent_by_himself_herself;
                                    obj_user_permissions_common_class.hide_messages_sent_by_himself_herself = hide_messages_sent_by_himself_herself;
                                    obj_user_permissions_common_class.pin_messages_to_the_top_of_chat_window = pin_messages_to_the_top_of_chat_window;
                                    obj_user_permissions_common_class.ping_messages = ping_messages;
                                    obj_user_permissions_common_class.forward_share_messages = forward_share_messages;
                                    obj_user_permissions_common_class.export_chat = export_chat;
                                    obj_user_permissions_common_class.copy_message_text = copy_message_text;
                                    obj_user_permissions_common_class.limit_access_to_chat_messages_from_last_no_of_days = limit_access_to_chat_messages_from_last_no_of_days;
                                    obj_user_permissions_common_class.limit_access_to_chat_messages_from = limit_access_to_chat_messages_from;
                              
                              
                                    obj_users_and_groups_profiles_common_class.user_permissions = (obj_user_permissions_common_class);  // json inside json formate
                                }





                                List_obj_users_and_groups_profiles_common_class.Add(obj_users_and_groups_profiles_common_class);  
                            }
                        }
                        catch (Exception ex)
                        {

                        }


                    }

                  
                }

            }

            catch (Exception ex)
            {

            }
            return List_obj_users_and_groups_profiles_common_class;
        }












        public DataTable GetAllUserAppChatMaster(string CustId, Int64 UserId)
        {
            Response response = new Response();
            DataTable dsetcm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[1].Value = UserId;



                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllUserAppChatMaster", param);

                    return dsetcm;

                }
            }

            catch (Exception ex)
            {

            }
            return dsetcm;
        }

        //get-user-chats-list

        public List<users_chat_list_common_class> GetAllUserAppChatList(string CustId, Int64 UserId)
        {

           // List<userapp_chats_list_main> list_obj_userapp_chats_list_main = new List<userapp_chats_list_main>();
          //  List<user_chat_master_main> list_obj_user_chat_list_main = new List<user_chat_master_main>();
           // List<chat_id_users_list_main> list_obj_chat_id_users_list_main = new List<chat_id_users_list_main>();
           // List<chat_id_messages> list_obj_chat_id_messages = new List<chat_id_messages>();

             List<users_chat_list_common_class> list_obj_users_chat_list_common_class = new List<users_chat_list_common_class>();

            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();
            DataSet ds4 = new DataSet();
            DataSet ds6 = new DataSet();

            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                MySqlParameter[] param = new MySqlParameter[3];
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[1].Value = UserId;

                    param[2] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[2].Value = "Get_User_List";

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetAllUserAppChatsList", param);
                }
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var chat_id = Convert.ToInt32(row["chat_id"].ToString());
                    var pin_to_top_of_list_no = Convert.ToInt32(row["pin_to_top_of_list_no"].ToString());
                    var number_of_unread_messages = Convert.ToBoolean(row["number_of_unread_messages"].ToString());
                    var mute_notifications_from_this_chat = Convert.ToBoolean(row["mute_notifications_from_this_chat"].ToString());
                    var user_blocked_status = Convert.ToBoolean(row["user_blocked_status"].ToString());

                     users_chat_list_common_class _obj_users_chat_list_common_class = new users_chat_list_common_class();
                    // userapp_chats_list_main _obj_userapp_chats_list_main = new userapp_chats_list_main();

                    _obj_users_chat_list_common_class.chat_id = chat_id;
                    _obj_users_chat_list_common_class.pin_to_top_of_list_no = pin_to_top_of_list_no;
                    _obj_users_chat_list_common_class.number_of_unread_messages = number_of_unread_messages;
                    _obj_users_chat_list_common_class.mute_notifications_from_this_chat = mute_notifications_from_this_chat;
                    _obj_users_chat_list_common_class.user_blocked_status = user_blocked_status;

                    // list_obj_users_chat_list_common_class.Add(_obj_users_chat_list_common_class5);
                   // list_obj_userapp_chats_list_main.Add(_obj_userapp_chats_list_main);

                    // ###################################
                    using MySqlConnection con1 = new MySqlConnection(connection);
                    try
                    {
                        MySqlParameter[] param1 = new MySqlParameter[3];
                        {
                            param1[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param1[0].Value = CustId;

                            param1[1] = new MySqlParameter("p_Get_User_Chat_List", MySqlDbType.Int64);
                            param1[1].Value = row["chat_id"].ToString();

                            param1[2] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                            param1[2].Value = "Get_User_Chat_List_With_Profile";

                            ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_GetAllUserappChatMasters", param1);

                            // /////////////////////
                            var chat_id1 = Convert.ToInt32(ds1.Tables[0].Rows[0]["chat_id"]);
                            var group_chat_name = Convert.ToString(ds1.Tables[0].Rows[0]["group_chat_name"]);
                            var chat_type = Convert.ToInt32(ds1.Tables[0].Rows[0]["chat_type"]);
                            var created_by_user_id = Convert.ToInt32(ds1.Tables[0].Rows[0]["created_by_user_id"]);
                            var created_timestamp = Convert.ToString(ds1.Tables[0].Rows[0]["created_timestamp"]);
                            var auto_delete_old_messages_no_of_days = Convert.ToInt32(ds1.Tables[0].Rows[0]["auto_delete_old_messages_no_of_days"]);
                            var auto_delete_old_messages = Convert.ToString(ds1.Tables[0].Rows[0]["auto_delete_old_messages"]);
                            var about_the_chat = Convert.ToString(ds1.Tables[0].Rows[0]["about_the_chat"]);
                            var businesses_associated_with_this_group = Convert.ToString(ds1.Tables[0].Rows[0]["businesses_associated_with_this_group"]);
                            var pin_chat_to_the_top_of_chat_list = Convert.ToString(ds1.Tables[0].Rows[0]["pin_chat_to_the_top_of_chat_list"]);
                            var pin_message_timestamp = Convert.ToString(ds1.Tables[0].Rows[0]["pin_message_timestamp"]);
                            var user_profile = Convert.ToString(ds1.Tables[0].Rows[0]["user_profile"]);

                            // user_chat_master_main _obj_user_chat_list_main = new user_chat_master_main();

                            //  users_chat_list_common_class _obj_users_chat_list_common_class = new users_chat_list_common_class();

                            _obj_users_chat_list_common_class.chat_id = chat_id1;
                            _obj_users_chat_list_common_class.group_chat_name = group_chat_name;
                            _obj_users_chat_list_common_class.chat_type = chat_type;
                            _obj_users_chat_list_common_class.created_by_user_id = created_by_user_id;
                            _obj_users_chat_list_common_class.created_timestamp = created_timestamp;
                            _obj_users_chat_list_common_class.auto_delete_old_messages_no_of_days = auto_delete_old_messages_no_of_days;
                            _obj_users_chat_list_common_class.auto_delete_old_messages = auto_delete_old_messages;
                            _obj_users_chat_list_common_class.about_the_chat = about_the_chat;
                            _obj_users_chat_list_common_class.businesses_associated_with_this_group = businesses_associated_with_this_group;
                            _obj_users_chat_list_common_class.pin_chat_to_the_top_of_chat_list = pin_chat_to_the_top_of_chat_list;
                            _obj_users_chat_list_common_class.pin_message_timestamp = pin_message_timestamp;
                            _obj_users_chat_list_common_class.user_profile = user_profile;


                           // list_obj_user_chat_list_main.Add(_obj_user_chat_list_main);
                            //  list_obj_users_chat_list_common_class.Add(_obj_users_chat_list_common_class);

                            // ###################################

                            if (chat_type==1)
                            {
                                using MySqlConnection con2 = new MySqlConnection(connection);
                                try
                                {
                                    MySqlParameter[] param2 = new MySqlParameter[5];
                                    {
                                        param2[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                        param2[0].Value = CustId;

                                        param2[1] = new MySqlParameter("p_Get_User_Chat_List", MySqlDbType.Int64);
                                        param2[1].Value = row["chat_id"].ToString();

                                        param2[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                        param2[2].Value = UserId;

                                        param2[3] = new MySqlParameter("p_chat_type", MySqlDbType.Bool);
                                        param2[3].Value = chat_type;   //

                                        param2[4] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                        param2[4].Value = "Get_User_Chat_List_With_Details";

                                        // SP_GetAlluserappChatIdUsersListWithName

                                        ds2 = SqlHelpher.ExecuteDataset(con2, CommandType.StoredProcedure, "SP_GetAlluserappChatIdUsersListUserIds", param2);
                                      
                                           var received_user_id = Convert.ToInt32(ds2.Tables[0].Rows[0]["user_id"]);
                                    
                                            //  chat_id_users_list_main _obj_chat_id_users_list_main = new chat_id_users_list_main();

                                            users_chat_list_common_class _obj_users_chat_list_common_class_1 = new users_chat_list_common_class();

                                            _obj_users_chat_list_common_class.received_user_id = received_user_id;
                              
                                            // list_obj_chat_id_users_list_main.Add(_obj_chat_id_users_list_main);
                                            // list_obj_users_chat_list_common_class.Add(_obj_users_chat_list_common_class_1);
                                    }
                                }
                                catch (Exception ex)
                                {

                                }
                                using MySqlConnection con6 = new MySqlConnection(connection);
                                try
                                {
                                    MySqlParameter[] param6 = new MySqlParameter[3];
                                    {
                                        param6[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                        param6[0].Value = CustId;

                                        param6[1] = new MySqlParameter("p_Get_User_Chat_List", MySqlDbType.Int64);
                                        param6[1].Value = row["chat_id"].ToString();

                                        param6[2] = new MySqlParameter("p_receiver_user_id", MySqlDbType.Int64);
                                        param6[2].Value = ds2.Tables[0].Rows[0]["user_id"];
            

                                      ds6 = SqlHelpher.ExecuteDataset(con6, CommandType.StoredProcedure, "SP_GetAlluserappChatIdUsersListReceivedUserStatus", param6);
                         
                                       var received_user_blocked_status = Convert.ToBoolean(ds6.Tables[0].Rows[0]["user_blocked_status"]);

                                      //  chat_id_users_list_main _obj_chat_id_users_list_main = new chat_id_users_list_main();

                                       users_chat_list_common_class _obj_users_chat_list_common_class_1 = new users_chat_list_common_class();

                                      _obj_users_chat_list_common_class.received_user_blocked_status = received_user_blocked_status;

                                     // list_obj_chat_id_users_list_main.Add(_obj_chat_id_users_list_main);
                                    // list_obj_users_chat_list_common_class.Add(_obj_users_chat_list_common_class_1);
                                    }
                                }
                                catch (Exception ex)
                                {

                                }

                            }
                            


                            using MySqlConnection con5 = new MySqlConnection(connection);
                            try
                            {
                                MySqlParameter[] param5 = new MySqlParameter[5];
                                {
                                    param5[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                    param5[0].Value = CustId;

                                    param5[1] = new MySqlParameter("p_Get_User_Chat_List", MySqlDbType.Int64);
                                    param5[1].Value = row["chat_id"].ToString();

                                    param5[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                    param5[2].Value = UserId;

                                    param5[3] = new MySqlParameter("p_chat_type", MySqlDbType.Bool);
                                    param5[3].Value = chat_type;   //

                                    param5[4] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                    param5[4].Value = "Get_User_Chat_List_With_Details";

                                    // SP_GetAlluserappChatIdUsersListWithName

                                    ds2 = SqlHelpher.ExecuteDataset(con5, CommandType.StoredProcedure, "SP_GetAlluserappChatIdUsersListWithNames", param5);
                                 
                                       // var user_id = Convert.ToInt32(result["user_id"]);
                                           var user_added_utc_timestamp = Convert.ToString(ds2.Tables[0].Rows[0]["user_added_timestamp"]);
                                           var user_removed_utc_timestamp = Convert.ToString(ds2.Tables[0].Rows[0]["user_removed_timestamp"]);
                                           var user_permissions_category = Convert.ToInt32(ds2.Tables[0].Rows[0]["user_permissions_category"]);
                                           var user_name = Convert.ToString(ds2.Tables[0].Rows[0]["user_name"]);

                                        //  chat_id_users_list_main _obj_chat_id_users_list_main = new chat_id_users_list_main();

                                        users_chat_list_common_class _obj_users_chat_list_common_class_1 = new users_chat_list_common_class();

                                        // _obj_users_chat_list_common_class.Received_user_id = user_id;
                                           _obj_users_chat_list_common_class.user_added_utc_timestamp = user_added_utc_timestamp;
                                           _obj_users_chat_list_common_class.user_removed_utc_timestamp = user_removed_utc_timestamp;
                                           _obj_users_chat_list_common_class.user_permissions_category = user_permissions_category;
                                          _obj_users_chat_list_common_class.user_name = user_name;

                                        // list_obj_chat_id_users_list_main.Add(_obj_chat_id_users_list_main);
                                        // list_obj_users_chat_list_common_class.Add(_obj_users_chat_list_common_class_1);
                                        // ###################################

                                    }
                               
                            }
                            catch (Exception ex)
                            {

                            }

                            using MySqlConnection con3 = new MySqlConnection(connection);
                            try
                            {
                                MySqlParameter[] param3 = new MySqlParameter[2];
                                {
                                    param3[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                    param3[0].Value = CustId;

                                    param3[1] = new MySqlParameter("p_Get_User_Chat_List", MySqlDbType.Int64);
                                    param3[1].Value = row["chat_id"].ToString();


                                    ds3 = SqlHelpher.ExecuteDataset(con3, CommandType.StoredProcedure, "SP_GetAllUserAppChatListWithLastMessage", param3);


                                    var Id = Convert.ToInt32(ds3.Tables[0].Rows[0]["Id"]);
                                    var last_message_by_user_id = Convert.ToString(ds3.Tables[0].Rows[0]["message"]);
                                    var last_message_timestamp = Convert.ToString(ds3.Tables[0].Rows[0]["message_timestamp"]);

                                    var send_last_msg_user_name = Convert.ToString(ds3.Tables[0].Rows[0]["user_name"]);
                                    var send_last_msg_his_designation = Convert.ToString(ds3.Tables[0].Rows[0]["designation"]);
                                    var send_last_msg_his_photo_id = Convert.ToString(ds3.Tables[0].Rows[0]["photo_id"]);
                                  


                                   //    chat_id_messages _obj_chat_id_messages = new chat_id_messages();
                                    //  users_chat_list_common_class _obj_users_chat_list_common_class_2 = new users_chat_list_common_class();

                                    _obj_users_chat_list_common_class.Id = Id;
                                    _obj_users_chat_list_common_class.last_message_by_user_id = last_message_by_user_id;
                                    _obj_users_chat_list_common_class.last_message_timestamp = last_message_timestamp;

                                    _obj_users_chat_list_common_class.send_last_msg_user_name = send_last_msg_user_name;
                                    _obj_users_chat_list_common_class.send_last_msg_his_designation = send_last_msg_his_designation;
                                    _obj_users_chat_list_common_class.send_last_msg_his_photo_id = send_last_msg_his_photo_id;

                                  //  list_obj_chat_id_messages.Add(_obj_chat_id_messages);
                                    // ###################################
                                   //  list_obj_users_chat_list_common_class.Add(_obj_users_chat_list_common_class);
                                }
                            }
                            catch (Exception ex)
                            {

                            }


                            using MySqlConnection con4 = new MySqlConnection(connection);
                            try
                            {
                                MySqlParameter[] param4 = new MySqlParameter[3];
                                {
                                    param4[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                    param4[0].Value = CustId;

                                    param4[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                    param4[1].Value = UserId;

                                    param4[2] = new MySqlParameter("p_Get_User_Chat_List", MySqlDbType.Int64);
                                    param4[2].Value = row["chat_id"].ToString();


                                    ds4 = SqlHelpher.ExecuteDataset(con4, CommandType.StoredProcedure, "SP_GetLastMessageUnReadCount", param4);


                                    var unread_message_count = Convert.ToInt32(ds4.Tables[0].Rows[0]["unread_message_count"]);                                

                       
                                    _obj_users_chat_list_common_class.unread_message_count = unread_message_count;                           
                                    list_obj_users_chat_list_common_class.Add(_obj_users_chat_list_common_class);
                                }
                            }
                            catch (Exception ex)
                            {

                            }




                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
           //   dynamic response_user_chat_list = (list_obj_userapp_chats_list_main, list_obj_user_chat_list_main, list_obj_chat_id_users_list_main, list_obj_chat_id_messages);
          //  var response_user_chat_list = Tuple.Create(list_obj_userapp_chats_list_main, list_obj_user_chat_list_main, list_obj_chat_id_users_list_main, list_obj_chat_id_messages);
          //  return response_user_chat_list;

             return list_obj_users_chat_list_common_class;
        }





        //GetUserAppChatIdMessages

        public List<message_view_details_common_class> GetAllUserAppChatIdMessages(string CustId, Int64 ChatId, Int64 UserId, Int64 PageNo, Int64 PageSize, Boolean ChatType)
        {
            List<message_view_details_common_class> List_message_view_details_common_class = new List<message_view_details_common_class>();

            Response response = new Response();
            DataTable dsetcm = new DataTable();
            DataTable ds = new DataTable();
            DataTable ds1 = new DataTable();

            DataTable ds5 = new DataTable();
            DataTable ds6 = new DataTable();



            MySqlParameter[] param = new MySqlParameter[6];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[1].Value = ChatId;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[2].Value = UserId;

                    param[3] = new MySqlParameter("p_page_no", MySqlDbType.Int64);
                    param[3].Value = PageNo;

                    param[4] = new MySqlParameter("p_page_size", MySqlDbType.Int64);
                    param[4].Value = PageSize;

                    param[5] = new MySqlParameter("p_chat_type", MySqlDbType.Bool);
                    param[5].Value = ChatType;

              
                    if (ChatType == false)
                    { 
                        ds1 = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_CheckGroupNewUserOrOldUser", param);
                        var New_User = Convert.ToInt32(ds1.Rows[0]["New_User"].ToString());

                        if(UserId == New_User)
                        {
                            ds1 = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_Get_HisMessagesBasedOnHisNumberofDays", param);
                            var limit_access_to_chat_messages_from_last_no_of_days = Convert.ToInt32(ds1.Rows[0]["limit_access_to_chat_messages_from_last_no_of_days"].ToString());

                            MySqlParameter[] param2 = new MySqlParameter[8];
                            try
                            {
                                using MySqlConnection con2 = new MySqlConnection(connection);
                                {
                                    param2[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                    param2[0].Value = CustId;

                                    param2[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                    param2[1].Value = ChatId;

                                    param2[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                    param2[2].Value = UserId;

                                    param2[3] = new MySqlParameter("p_page_no", MySqlDbType.Int64);
                                    param2[3].Value = PageNo;

                                    param2[4] = new MySqlParameter("p_page_size", MySqlDbType.Int64);
                                    param2[4].Value = PageSize;

                                    param2[5] = new MySqlParameter("p_chat_type", MySqlDbType.Bool);
                                    param2[5].Value = ChatType;

                                    param2[6] = new MySqlParameter("p_limit_access_to_chat_messages_from_last_no_of_days", MySqlDbType.Int32);
                                    param2[6].Value = limit_access_to_chat_messages_from_last_no_of_days;

                                    param2[7] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                    param2[7].Value = "GetGroupMessages";

                                dsetcm = SqlHelpher.ExecuteDataTable(con2, CommandType.StoredProcedure, "SP_GetAllUserAppChatIdGroupMessagesMessages", param2);
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                            MySqlParameter[] param5 = new MySqlParameter[2];
                            try
                            {
                                using MySqlConnection con5 = new MySqlConnection(connection);
                                {
                                    param5[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                    param5[0].Value = UserId;

                                    param5[1] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                    param5[1].Value = "GetMessageReadUserDetails";

                                    ds5 = SqlHelpher.ExecuteDataTable(con5, CommandType.StoredProcedure, "SP_GetMessageReadUserDetails", param5);
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                            MySqlParameter[] param6 = new MySqlParameter[5];
                            try
                            {
                                var message_read_user_details = ds5.Rows[0]["message_read_user_details"].ToString();

                                using MySqlConnection con6 = new MySqlConnection(connection);
                                {
                                param6[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param6[0].Value = CustId;

                                param6[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                param6[1].Value = ChatId;

                                param6[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                param6[2].Value = UserId;

                                param6[3] = new MySqlParameter("p_message_read_user_details", MySqlDbType.JSON);
                                param6[3].Value = message_read_user_details;

                                param6[4] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                param6[4].Value = "AssignMessageReadUserDetails_Chat_Id_Messages_Table";

                                ds6 = SqlHelpher.ExecuteDataTable(con6, CommandType.StoredProcedure, "SP_AssignMessageReadUserDetails_Chat_Id_Messages_Table", param6);

                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        else
                        {
                            MySqlParameter[] param2 = new MySqlParameter[7];
                            try
                            {
                                using MySqlConnection con2 = new MySqlConnection(connection);
                                {
                                    param2[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                    param2[0].Value = CustId;

                                    param2[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                    param2[1].Value = ChatId;

                                    param2[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                    param2[2].Value = UserId;

                                    param2[3] = new MySqlParameter("p_page_no", MySqlDbType.Int64);
                                    param2[3].Value = PageNo;

                                    param2[4] = new MySqlParameter("p_page_size", MySqlDbType.Int64);
                                    param2[4].Value = PageSize;

                                    param2[5] = new MySqlParameter("p_chat_type", MySqlDbType.Bool);
                                    param2[5].Value = ChatType;

                                    dsetcm = SqlHelpher.ExecuteDataTable(con2, CommandType.StoredProcedure, "SP_GetAllUserAppChatIdMessagesOldUsers", param2);
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            MySqlParameter[] param5 = new MySqlParameter[2];
                            try
                            {
                                using MySqlConnection con5 = new MySqlConnection(connection);
                                {
                                    param5[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                    param5[0].Value = UserId;

                                    param5[1] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                    param5[1].Value = "GetMessageReadUserDetails";

                                    ds5 = SqlHelpher.ExecuteDataTable(con5, CommandType.StoredProcedure, "SP_GetMessageReadUserDetails", param5);
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            MySqlParameter[] param6 = new MySqlParameter[5];
                            try
                            {
                                var message_read_user_details = ds5.Rows[0]["message_read_user_details"].ToString();

                                using MySqlConnection con6 = new MySqlConnection(connection);
                                {
                                    param6[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                    param6[0].Value = CustId;

                                    param6[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                    param6[1].Value = ChatId;

                                    param6[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                    param6[2].Value = UserId;

                                    param6[3] = new MySqlParameter("p_message_read_user_details", MySqlDbType.JSON);
                                    param6[3].Value = message_read_user_details;

                                    param6[4] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                    param6[4].Value = "AssignMessageReadUserDetails_Chat_Id_Messages_Table";

                                    ds6 = SqlHelpher.ExecuteDataTable(con6, CommandType.StoredProcedure, "SP_AssignMessageReadUserDetails_Chat_Id_Messages_Table", param6);

                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                    else if (ChatType == true)
                    {
                        MySqlParameter[] param2 = new MySqlParameter[8];
                        try
                        {
                            using MySqlConnection con2 = new MySqlConnection(connection);
                            {
                                param2[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param2[0].Value = CustId;

                                param2[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                param2[1].Value = ChatId;

                                param2[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                param2[2].Value = UserId;

                                param2[3] = new MySqlParameter("p_page_no", MySqlDbType.Int64);
                                param2[3].Value = PageNo;

                                param2[4] = new MySqlParameter("p_page_size", MySqlDbType.Int64);
                                param2[4].Value = PageSize;

                                param2[5] = new MySqlParameter("p_chat_type", MySqlDbType.Bool);
                                param2[5].Value = ChatType;

                                param2[6] = new MySqlParameter("p_limit_access_to_chat_messages_from_last_no_of_days", MySqlDbType.Int32);
                                param2[6].Value = 0;


                                param2[7] = new MySqlParameter("p_Action", MySqlDbType.Bool);
                                param2[7].Value = "GetOntToOneMessages";

                                dsetcm = SqlHelpher.ExecuteDataTable(con2, CommandType.StoredProcedure, "SP_GetAllUserAppChatIdOntToOneMessagesMessages", param2);
                            }
                        }
                        catch (Exception ex)
                        {

                        }


                        MySqlParameter[] param5 = new MySqlParameter[2];
                        try
                        {
                            using MySqlConnection con5 = new MySqlConnection(connection);
                            {
                                param5[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                param5[0].Value = UserId;

                                param5[1] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                param5[1].Value = "GetMessageReadUserDetails";

                                ds5 = SqlHelpher.ExecuteDataTable(con5, CommandType.StoredProcedure, "SP_GetMessageReadUserDetails", param5);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        MySqlParameter[] param6 = new MySqlParameter[5];
                        try
                        {
                            var message_read_user_details = ds5.Rows[0]["message_read_user_details"].ToString();

                            using MySqlConnection con6 = new MySqlConnection(connection);
                            {
                                param6[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param6[0].Value = CustId;

                                param6[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                param6[1].Value = ChatId;

                                param6[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                param6[2].Value = UserId;

                                param6[3] = new MySqlParameter("p_message_read_user_details", MySqlDbType.JSON);
                                param6[3].Value = message_read_user_details;

                                param6[4] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                param6[4].Value = "AssignMessageReadUserDetails_Chat_Id_Messages_Table";

                                ds6 = SqlHelpher.ExecuteDataTable(con6, CommandType.StoredProcedure, "SP_AssignMessageReadUserDetails_Chat_Id_Messages_Table", param6);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    foreach (DataRow result in dsetcm.Rows)
                    {
                        var Id = Convert.ToInt32(result["Id"].ToString());
                        var message_hide_status = Convert.ToBoolean(result["message_hide_status"].ToString());
                        var message_edit_status = Convert.ToBoolean(result["message_edit_status"].ToString());
                        var message_timestamp = Convert.ToString(result["message_timestamp"].ToString());
                        var message = Convert.ToString(result["message"].ToString());
                        var sent_by_user_id = Convert.ToInt32(result["sent_by_user_id"].ToString());
                        var reply_to_message_timestamp = Convert.ToString(result["reply_to_message_timestamp"].ToString());
                        var attachment_file = Convert.ToString(result["attachment_file"].ToString());
                        var user_name = Convert.ToString(result["user_name"].ToString());
                        var designation = Convert.ToString(result["designation"].ToString());
                        var company_name = Convert.ToString(result["company_name"].ToString());
                        var photo_id = Convert.ToString(result["photo_id"].ToString());
                        var user_read_status = result["user_read_status"];

                        message_view_details_common_class obj_message_view_details_common_class = new message_view_details_common_class();

                        obj_message_view_details_common_class.Id = Id;  // add one field user_read_status
                        obj_message_view_details_common_class.message_hide_status = message_hide_status;
                        obj_message_view_details_common_class.message_edit_status = message_edit_status;            
                        obj_message_view_details_common_class.message_timestamp = message_timestamp;
                        obj_message_view_details_common_class.message = message;
                        obj_message_view_details_common_class.sent_by_user_id = sent_by_user_id;
                        obj_message_view_details_common_class.reply_to_message_timestamp = reply_to_message_timestamp;
                        obj_message_view_details_common_class.attachment_file = attachment_file;
                        obj_message_view_details_common_class.user_name = user_name;
                        obj_message_view_details_common_class.designation = designation;
                        obj_message_view_details_common_class.company_name = company_name;
                        obj_message_view_details_common_class.photo_id = photo_id;
                        obj_message_view_details_common_class.user_read_status = (Microsoft.Ajax.Utilities.JSON)user_read_status;
                    
                        MySqlParameter[] param1 = new MySqlParameter[7];
                        try
                        {
                            using MySqlConnection con1 = new MySqlConnection(connection);
                            {
                                param1[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param1[0].Value = CustId;

                                param1[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                                param1[1].Value = ChatId;

                                param1[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                param1[2].Value = UserId;

                                param1[3] = new MySqlParameter("p_page_no", MySqlDbType.Int64);
                                param1[3].Value = PageNo;

                                param1[4] = new MySqlParameter("p_page_size", MySqlDbType.Int64);
                                param1[4].Value = PageSize;

                                param1[5] = new MySqlParameter("p_message", MySqlDbType.VarChar);
                                param1[5].Value = message;

                                param1[6] = new MySqlParameter("p_message_timestamp", MySqlDbType.VarChar);
                                param1[6].Value = message_timestamp;

                                ds = SqlHelpher.ExecuteDataTable(con1, CommandType.StoredProcedure, "SP_GetAllUserAppChatIdMessagesWithCountAndReadStatus", param1);
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        user_message_read_status_and_read_count_status obj_user_message_read_status_and_read_count_status = new user_message_read_status_and_read_count_status();

                        var status = Convert.ToBoolean(ds.Rows[0]["status"].ToString());
                        var read_status = Convert.ToBoolean(ds.Rows[0]["read_status"].ToString());

                        obj_user_message_read_status_and_read_count_status.status = status;
                        obj_user_message_read_status_and_read_count_status.read_status = read_status;

                        obj_message_view_details_common_class.user_message_read_status_and_read_count_status_Data = (obj_user_message_read_status_and_read_count_status);  // json inside json formate
                        List_message_view_details_common_class.Add(obj_message_view_details_common_class);         
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return List_message_view_details_common_class;
        }


        public Response UpdateUsersUserAppBlockedUserList(userapp_blocked_user_list obj_blocked_user_list)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[10];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = obj_blocked_user_list.user_id;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = obj_blocked_user_list.cust_id;

                    param[2] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[2].Value = obj_blocked_user_list.chat_id;

                    param[3] = new MySqlParameter("p_user_blocked_status", MySqlDbType.Bool);
                    param[3].Value = obj_blocked_user_list.user_blocked_status;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUsersUserAppBlockedUserList", param);
                }
                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {
                    response.Data = "";
                    response.Message = "Blocked  Successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        //InsertUserAppSavedMessages

        public Response AddUserAppSavedMessages(userapp_saved_messages obj_saved_messages)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[6];
                {


                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = obj_saved_messages.user_id;

                    param[1] = new MySqlParameter("p_chat_id", MySqlDbType.VarChar);
                    param[1].Value = obj_saved_messages.chat_id;

                    param[2] = new MySqlParameter("p_message_timestamp", MySqlDbType.VarChar);
                    param[2].Value = obj_saved_messages.message_timestamp;

                    param[3] = new MySqlParameter("p_message", MySqlDbType.LongText);
                    param[3].Value = obj_saved_messages.message;

                    param[4] = new MySqlParameter("p_saved_timestamp", MySqlDbType.VarChar);
                    param[4].Value = obj_saved_messages.saved_timestamp;

                    param[5] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[5].Value = obj_saved_messages.cust_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserAppSavedMessages", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Insert successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }

            }
            catch (Exception ex)
            {

            }
            return response;

        }
        //GetAuditTrailForAppAdministrators
        public DataTable GetAuditTrailForAppAdministrators(string CustId)
        {
            Response response = new Response();
            DataTable dsetcm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;


                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAuditTrailForAppAdministrators", param);
                    return dsetcm;
                }
            }

            catch (Exception ex)
            {

            }
            return dsetcm;
        }

        //UpdateUserUserAppChatList

        public Response UpdateUserUserAppChatList(userapp_chat_list obj_chat_list )
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            using MySqlConnection con = new MySqlConnection(connection);
            try
             {
                if (obj_chat_list.cust_id != null)
                {

                    MySqlParameter[] param = new MySqlParameter[7];
                    {
                        param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                        param[0].Value = obj_chat_list.chat_id;

                        param[1] = new MySqlParameter("p_pin_to_top_of_list_no", MySqlDbType.Int64);
                        param[1].Value = obj_chat_list.pin_to_top_of_list_no;

                        param[2] = new MySqlParameter("p_number_of_unread_messages", MySqlDbType.Bool);
                        param[2].Value = Convert.ToBoolean(obj_chat_list.number_of_unread_messages);

                        param[3] = new MySqlParameter("p_mute_notification_from_this_chat", MySqlDbType.Bool);
                        param[3].Value = Convert.ToBoolean(obj_chat_list.mute_notifications_from_this_chat);

                        param[4] = new MySqlParameter("p_user_blocked_status", MySqlDbType.Bool);
                        param[4].Value = Convert.ToBoolean(obj_chat_list.user_blocked_status);

                        param[5] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param[5].Value = obj_chat_list.cust_id;

                        param[6] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                        param[6].Value = obj_chat_list.user_id;

                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserUserAppChatList", param);
                    }
                }
                if (obj_chat_list.mute_notifications_from_this_chat == "false")
                {

                    MySqlParameter[] param = new MySqlParameter[5];
                    {
                        param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                        param[0].Value = obj_chat_list.chat_id;

                        param[1] = new MySqlParameter("p_mute_notification_from_this_chat", MySqlDbType.Bool);
                        param[1].Value = Convert.ToBoolean(obj_chat_list.mute_notifications_from_this_chat);

                        param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param[2].Value = obj_chat_list.cust_id;

                        param[3] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                        param[3].Value = obj_chat_list.user_id;


                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_MuteNotificationFromThisChat", param);
                    }
                }
                if (obj_chat_list.number_of_unread_messages == "false")
                {
                    MySqlParameter[] param = new MySqlParameter[4];
                    {
                        param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                        param[0].Value = obj_chat_list.chat_id;

                        param[1] = new MySqlParameter("p_number_of_unread_messages", MySqlDbType.Bool);
                        param[1].Value = Convert.ToBoolean(obj_chat_list.number_of_unread_messages);

                        param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param[2].Value = obj_chat_list.cust_id;

                        param[3] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                        param[3].Value = obj_chat_list.user_id;

                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_NumberOfUnreadMessages", param);
                    }
                }

                if (obj_chat_list.user_blocked_status == "false")
                {
                    MySqlParameter[] param = new MySqlParameter[4];
                    {
                        param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                        param[0].Value = obj_chat_list.chat_id;

                        param[1] = new MySqlParameter("p_user_blocked_status", MySqlDbType.Bool);
                        param[1].Value = Convert.ToBoolean(obj_chat_list.user_blocked_status);

                        param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param[2].Value = obj_chat_list.cust_id;

                        param[3] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                        param[3].Value = obj_chat_list.user_id;

                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserUserAppChatList_User_Blocked_Status", param);
                    }
                }




                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "update  successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }

        public Response UpdateUserUserAppNotifications(user_userapp_notification obj_userapp_notifications)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            try
            {

                MySqlParameter[] param = new MySqlParameter[6];
                {


                    using MySqlConnection con = new MySqlConnection(connection);



                    param[0] = new MySqlParameter("p_mute_all_chat_notifications", MySqlDbType.Bool);
                    param[0].Value = obj_userapp_notifications.mute_all_chat_notifications;


                    param[1] = new MySqlParameter("p_mute_pings_from_all_users", MySqlDbType.Bool);
                    param[1].Value = obj_userapp_notifications.mute_pings_from_all_users;


                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[2].Value = obj_userapp_notifications.user_id;


                    param[3] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[3].Value = obj_userapp_notifications.cust_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserAppNotifications", param);

                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Update  successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }

            }
            catch (Exception ex)
            {

            }
            return response;

        }


        public DataTable GetAllUserAppChatIdUsersList(string CustId, Int64 ChatId)
        {
            Response response = new Response();
            DataTable dsetcm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[1].Value = ChatId;
                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllUserAppChatIdUsersList", param);

                    return dsetcm;

                }
            }

            catch (Exception ex)
            {

            }
            return dsetcm;
        }


        // UpdateUserAppChatIdUsersList
        public Response UpdateUserAppChatIdUsersList(userapp_chat_id_users_list Obj_chat_id_users_list)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            try
            {

                MySqlParameter[] param = new MySqlParameter[5];
                {


                    using MySqlConnection con = new MySqlConnection(connection);





                    param[0] = new MySqlParameter("p_user_added_timestamp", MySqlDbType.VarChar);
                    param[0].Value = Obj_chat_id_users_list.user_added_timestamp;

                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[1].Value = Obj_chat_id_users_list.user_id;

                    param[2] = new MySqlParameter("p_user_permissions_category", MySqlDbType.Int64);
                    param[2].Value = Obj_chat_id_users_list.user_permissions_category;

                    param[3] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[3].Value = Obj_chat_id_users_list.cust_id;

                    param[4] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[4].Value = Obj_chat_id_users_list.chat_id;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserAppChatIdUsersList", param);

                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Update  successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }

            }
            catch (Exception ex)
            {

            }
            return response;

        }

        //get user Profiles

        public DataTable GetUserList(string CustId, Int64 UserId)
        {
            Response response = new Response();
            DataTable dsetcm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[1].Value = UserId;
                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUsersList", param);

                    return dsetcm;

                }
            }

            catch (Exception ex)
            {

            }
            return dsetcm;
        }

        public DataTable GetUserAppGroupMemberById(string CustId, Int64 ChatId)
        {
            Response response = new Response();
            DataTable dsetcm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[1].Value = ChatId;
                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserAppGroupMemberById", param);

                    return dsetcm;

                }
            }

            catch (Exception ex)
            {

            }
            return dsetcm;
        }


        public DataTable GetAllUserAppChatIdReadUnreadStatusCount(string CustId, Int64 ChatId, Int64 UserId)
        {
            Response response = new Response();
            DataTable dsetcm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[1].Value = ChatId;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[2].Value = UserId;

                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllUserAppChatIdReadUnreadStatusCount", param);

                    return dsetcm;
                }
            }

            catch (Exception ex)
            {

            }
            return dsetcm;
        }


        public DataTable GetChatIdAdminUsersPermissions(string CustId, Int64 ChatId, Int64 UserId)
        {
            Response response = new Response();
            DataTable dsetcm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[1].Value = ChatId;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[2].Value = UserId;

                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetChatIdAdminUsersPermissions", param);

                    return dsetcm;

                }
            }

            catch (Exception ex)
            {

            }
            return dsetcm;
        }


        public DataTable GetChatIdCustomMemberPermissionsForUserId(string CustId, Int64 ChatId, Int64 UserId)
        {
            Response response = new Response();
            DataTable dsetcm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[1].Value = ChatId;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int32);
                    param[2].Value = Convert.ToInt32(UserId);



                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetChatIdCustomMemberPermissionsForUserId", param);

                    return dsetcm;

                }
            }

            catch (Exception ex)
            {

            }
            return dsetcm;
        }


        public DataTable GetChatIdGroupMemberUserPermission(string CustId, Int64 ChatId, Int64 UserId)
        {
            Response response = new Response();
            DataTable dsetcm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int32);
                    param[1].Value = ChatId;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[2].Value = UserId;



                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetChatIdGroupMemberUserPermission", param);

                    return dsetcm;

                }
            }

            catch (Exception ex)
            {

            }
            return dsetcm;
        }


        public Response UpdateColumnUserAppChatMaster(userapp_chat_master obj_chat_master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            DataSet dsetmaxid = new DataSet();
            DataSet dsetcm = new DataSet();
            try
            {
                if (obj_chat_master.chat_id != null)
                {
                    MySqlParameter[] param = new MySqlParameter[7];
                    {
                        using MySqlConnection con = new MySqlConnection(connection);



                        param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                        param[0].Value = obj_chat_master.chat_id;

                        param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param[1].Value = obj_chat_master.cust_id;


                        param[2] = new MySqlParameter("p_group_chat_name", MySqlDbType.VarChar);
                        param[2].Value = obj_chat_master.group_chat_name;

                        param[3] = new MySqlParameter("p_user_profile", MySqlDbType.VarChar);
                        param[3].Value = obj_chat_master.user_profile;

                        param[4] = new MySqlParameter("p_about_the_chat", MySqlDbType.VarChar);
                        param[4].Value = obj_chat_master.about_the_chat;

                        param[5] = new MySqlParameter("p_businesses_associated_with_this_group", MySqlDbType.VarChar);
                        param[5].Value = obj_chat_master.businesses_associated_with_this_group;


                        param[6] = new MySqlParameter("p_auto_delete_old_messages_no_of_days", MySqlDbType.Int64);
                        param[6].Value = obj_chat_master.auto_delete_old_messages_no_of_days;



                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateColumnUserAppChatMaster", param);


                    }
                }


                if (obj_chat_master.auto_delete_old_messages == "false")
                {
                    MySqlParameter[] param = new MySqlParameter[3];
                    {
                        using MySqlConnection con = new MySqlConnection(connection);



                        param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                        param[0].Value = obj_chat_master.chat_id;

                        param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param[1].Value = obj_chat_master.cust_id;

                        param[2] = new MySqlParameter("p_auto_delete_old_messages", MySqlDbType.Bool);
                        param[2].Value = Convert.ToBoolean(obj_chat_master.auto_delete_old_messages);


                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AutoDeleteOldMessages", param);


                    }
                }


                if (obj_chat_master.auto_delete_old_messages == "true")
                {
                    MySqlParameter[] param = new MySqlParameter[3];
                    {
                        using MySqlConnection con = new MySqlConnection(connection);



                        param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                        param[0].Value = obj_chat_master.chat_id;

                        param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param[1].Value = obj_chat_master.cust_id;

                        param[2] = new MySqlParameter("p_auto_delete_old_messages", MySqlDbType.Bool);
                        param[2].Value = Convert.ToBoolean(obj_chat_master.auto_delete_old_messages);


                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AutoDeleteOldMessages", param);


                    }
                }




                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Update  successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }

            }
            catch (Exception ex)
            {

            }
            return response;

        }


        public Response DeleteUserAppGroupMemberById(Int64 ChatId, string CustId, Int64 UserId)
        {
            Response response = new Response();
            DataSet ds = new DataSet();


            try
            {

                MySqlParameter[] param = new MySqlParameter[3];
                {


                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[0].Value = ChatId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[2].Value = UserId;




                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteUserAppGroupMemberById", param);

                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Delete  Successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }


            }
            catch (Exception ex)
            {

            }
            return response;

        }


        public Response UpdateAssignChatUserListDetails(userapp_chat_master obj_chat_Master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet dsetmaxid = new DataSet();
            DataSet dsetcm = new DataSet();
            DataSet dsetuserlist = new DataSet();
            //JObject json = JObject.Parse(getster_App_About_Demo.getster_app_time_stamp_description);
            try
            {
                MySqlParameter[] param = new MySqlParameter[4];
                {


                    //JObject json = JObject.Parse(getster_App_About_Demo.getster_app_time_stamp_description);
                    //getster_App_About_Demo.getster_app_time_stamp_description = json.ToString();

                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int32);
                    param[0].Value = obj_chat_Master.chat_id;


                    param[1] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int32);
                    param[1].Value = obj_chat_Master.created_by_user_id;



                    param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[2].Value = obj_chat_Master.cust_id;

                    param[3] = new MySqlParameter("p_chat_type", MySqlDbType.Int64);
                    param[3].Value = obj_chat_Master.chat_type;


                    dsetcm = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateAssignUserAppChatMaster", param);



                    string getuserlistid = obj_chat_Master.UserList_Ids.ToString();
                    string[] getuserlistids = getuserlistid.Split(",");



                    if (dsetmaxid.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < getuserlistids.Length; i++)
                        {
                            MySqlParameter[] paramAssginuserlist = new MySqlParameter[6];
                            string GetMaxId = dsetcm.Tables[0].Rows[0]["MaxId"].ToString();
                            using MySqlConnection con1 = new MySqlConnection(connection);

                            using MySqlConnection con2 = new MySqlConnection(connection);
                            {
                                paramAssginuserlist[0] = new MySqlParameter("p_Maxid", MySqlDbType.Int64);
                                paramAssginuserlist[0].Value = GetMaxId;

                                paramAssginuserlist[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                paramAssginuserlist[1].Value = obj_chat_Master.cust_id;

                                paramAssginuserlist[2] = new MySqlParameter("p_UserList_Ids", MySqlDbType.VarChar);
                                paramAssginuserlist[2].Value = getuserlistids[i].ToString();

                                paramAssginuserlist[3] = new MySqlParameter("p_Message", MySqlDbType.LongText);
                                paramAssginuserlist[3].Value = obj_chat_Master.Message;

                                paramAssginuserlist[4] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                                paramAssginuserlist[4].Value = obj_chat_Master.created_by_user_id;

                                paramAssginuserlist[5] = new MySqlParameter("p_chat_type", MySqlDbType.Int64);
                                paramAssginuserlist[5].Value = obj_chat_Master.chat_type;



                                dsetuserlist = SqlHelpher.ExecuteDataset(con2, CommandType.StoredProcedure, "SP_UpdateAssignChatUserListDetails", paramAssginuserlist);

                                //  dsetmaxid = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_TESTCreateDynamicTablesBasedOnChatId", param);
                            }
                        }

                    }

                    if (Convert.ToString(dsetuserlist.Tables[0].Rows[0]["Message"]) == "200")
                    {

                        response.Data = "";
                        response.Message = "Insert  successfully";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = Convert.ToString(dsetuserlist.Tables[0].Rows[0]["Message"]);
                        response.Status = Convert.ToInt32(dsetuserlist.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;

        }




        public Response AddUserAppGroupMemberById(userapp_chat_master obj_chat_master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            string getuserlistid = obj_chat_master.UserList_Ids.ToString();
            string[] getuserlistids = getuserlistid.Split(",");

            try
            {

                for (int i = 0; i < getuserlistids.Length; i++)
                {
                    MySqlParameter[] param = new MySqlParameter[6];
                    {
                        using MySqlConnection con = new MySqlConnection(connection);
                        param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                        param[0].Value = obj_chat_master.chat_id;

                        param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param[1].Value = obj_chat_master.cust_id;

                        param[2] = new MySqlParameter("p_UserList_Ids", MySqlDbType.VarChar);
                        param[2].Value = getuserlistids[i].ToString();

                        param[3] = new MySqlParameter("p_Message", MySqlDbType.LongText);
                        param[3].Value = obj_chat_master.Message;

                        param[4] = new MySqlParameter("p_chat_type", MySqlDbType.Int64);
                        param[4].Value = obj_chat_master.chat_type;

                        param[5] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                        param[5].Value = obj_chat_master.created_timestamp;



                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddUserAppGroupMemberById", param);
                    }
                }
                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Insert  Successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }

            }
            catch (Exception ex)
            {

            }
            return response;

        }

        //




        public DataTable GetSearchChatMessages(string SearchMessage, string CustId, Int64 ChatId)
        {
            Response response = new Response();
            DataTable dsetcm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_search_message", MySqlDbType.LongText);
                    param[0].Value = SearchMessage;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    param[2] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[2].Value = ChatId;

                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetSearchChatMessages", param);

                    return dsetcm;

                }
            }

            catch (Exception ex)
            {

            }
            return dsetcm;
        }


        //InsertUserAppAuditTrailForProfanityText

        public Response AddUserAppAuditTtrailForProfanityText(user_app_audit_trail_for_profanity_text obj_profanity_text)
        {
            Response response = new Response();

            DataSet ds = new DataSet();
            try
            {

                MySqlParameter[] param = new MySqlParameter[5];
                {

                    using MySqlConnection con = new MySqlConnection(connection);


                    param[0] = new MySqlParameter("p_language", MySqlDbType.VarChar);
                    param[0].Value = obj_profanity_text.language;

                    param[1] = new MySqlParameter("p_text_word_words", MySqlDbType.VarChar);
                    param[1].Value = obj_profanity_text.text_word_words;

                    param[2] = new MySqlParameter("p_entry_by_user_id", MySqlDbType.Int64);
                    param[2].Value = obj_profanity_text.entry_by_user_id;

                    param[3] = new MySqlParameter("p_entry_type", MySqlDbType.VarChar);
                    param[3].Value = obj_profanity_text.entry_type;


                    param[4] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[4].Value = obj_profanity_text.cust_id;



                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserAppAuditTrailForProfanityText", param);

                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Insert Successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }


        //GetAllUserAppAuditTrailForProfanityText


        public DataTable GetAllUserAppAuditTrailForProfanityText(string CustId)
        {
            Response response = new Response();
            DataTable dsetcm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {


                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;



                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllUserAppAuditTrailForProfanityText", param);

                    return dsetcm;

                }
            }

            catch (Exception ex)
            {

            }
            return dsetcm;
        }


        //SP_UpdateUserAppAuditTrailForProfanityText

        public Response UpdateUserAppAuditTrailForProfanityText(user_app_audit_trail_for_profanity_text obj_profanity_text)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            try
            {

                MySqlParameter[] param = new MySqlParameter[5];
                {

                    using MySqlConnection con = new MySqlConnection(connection);


                    param[0] = new MySqlParameter("p_language", MySqlDbType.VarChar);
                    param[0].Value = obj_profanity_text.language;

                    param[1] = new MySqlParameter("p_text_word_words", MySqlDbType.VarChar);
                    param[1].Value = obj_profanity_text.text_word_words;

                    param[2] = new MySqlParameter("p_entry_by_user_id", MySqlDbType.Int64);
                    param[2].Value = obj_profanity_text.entry_by_user_id;

                    param[3] = new MySqlParameter("p_entry_type", MySqlDbType.VarChar);
                    param[3].Value = obj_profanity_text.entry_type;


                    param[4] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[4].Value = obj_profanity_text.cust_id;



                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserAppAuditTrailForProfanityText", param);

                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Insert Successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public Response AddUserAppChatIdReplayMessages(userapp_chat_Id_messages obj_chat_messages, userapp_chat_Id_messages mainobj)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            string attach = "[" + mainobj.attachment_file + "]";
            try
            {
                if (mainobj.attachment_file == "")
                {
                    MySqlParameter[] param = new MySqlParameter[6];

                    using MySqlConnection con = new MySqlConnection(connection);

                    {

                        param[0] = new MySqlParameter("p_message", MySqlDbType.LongText);
                        param[0].Value = obj_chat_messages.message;

                        param[1] = new MySqlParameter("p_sent_by_user_id", MySqlDbType.Int64);
                        param[1].Value = obj_chat_messages.sent_by_user_id;


                        param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param[2].Value = obj_chat_messages.cust_id;

                        param[3] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                        param[3].Value = obj_chat_messages.chat_id;

                        param[4] = new MySqlParameter("p_reply_to_message_timestamp", MySqlDbType.VarChar);
                        param[4].Value = obj_chat_messages.reply_to_message_timestamp;


                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserAppChatIdReplayMessages", param);



                    }

                }


                if (mainobj.attachment_file != "")
                {
                    MySqlParameter[] param = new MySqlParameter[6];

                    using MySqlConnection con = new MySqlConnection(connection);

                    {

                        param[0] = new MySqlParameter("p_message", MySqlDbType.LongText);
                        param[0].Value = obj_chat_messages.message;

                        param[1] = new MySqlParameter("p_sent_by_user_id", MySqlDbType.Int64);
                        param[1].Value = obj_chat_messages.sent_by_user_id;


                        param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param[2].Value = obj_chat_messages.cust_id;

                        param[3] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                        param[3].Value = obj_chat_messages.chat_id;

                        param[4] = new MySqlParameter("p_reply_to_message_timestamp", MySqlDbType.VarChar);
                        param[4].Value = obj_chat_messages.reply_to_message_timestamp;

                        param[5] = new MySqlParameter("p_attachment_file", MySqlDbType.VarChar);
                        param[5].Value = attach;


                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserAppChatIdReplayAttachmentMessages", param);




                    }

                }


                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Send   successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return response;



        }

        public Response AddUserappProfanityText(userapp_profanity_text obj_userapp_profanity_text)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[7];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_language", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_profanity_text.language;

                    param[1] = new MySqlParameter("p_text_word_words", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_profanity_text.text_word_words;




                    param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_profanity_text.cust_id;


                    param[3] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[3].Value = obj_userapp_profanity_text.user_id;


                    param[4] = new MySqlParameter("p_entry_type", MySqlDbType.VarChar);
                    param[4].Value = obj_userapp_profanity_text.entry_type;



                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddUserappProfanityTexts", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Added successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }


        public DataTable GetAllUserAppForProfanityText(string CustId, bool IsItUnblocked)
        {
            Response response = new Response();
            DataTable dsetcm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_is_it_unblocked", MySqlDbType.Bool);
                    param[1].Value = IsItUnblocked;

                    dsetcm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserappProfanityText", param);

                    return dsetcm;
                }
            }
            catch (Exception ex)
            {

            }
            return dsetcm;
        }

        public Response UpdateUserappProfanityText(userapp_profanity_text obj_userapp_profanity_text)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[8];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_language", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_profanity_text.language;

                    param[1] = new MySqlParameter("p_text_word_words", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_profanity_text.text_word_words;

                    param[2] = new MySqlParameter("p_is_it_added_by_customer", MySqlDbType.Bool);
                    param[2].Value = obj_userapp_profanity_text.is_it_added_by_customer;

                    param[3] = new MySqlParameter("p_is_it_unblocked", MySqlDbType.Bool);
                    param[3].Value = obj_userapp_profanity_text.is_it_unblocked;

                    param[4] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[4].Value = obj_userapp_profanity_text.cust_id;

                    param[5] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[5].Value = obj_userapp_profanity_text.user_id;

                    param[6] = new MySqlParameter("p_entry_type", MySqlDbType.VarChar);
                    param[6].Value = obj_userapp_profanity_text.entry_type;

                    param[7] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                    param[7].Value = obj_userapp_profanity_text.Id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserAppProfanityText", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Update Successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }



        public Response DeleteMessages(string Cust_Id, Int64 Chat_Id, string Message_Timestamp, Int64 Id)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[4];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[0].Value = Chat_Id;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = Cust_Id;

                    param[2] = new MySqlParameter("p_message_timestamp", MySqlDbType.VarChar);
                    param[2].Value = Message_Timestamp;

                    param[3] = new MySqlParameter("p_id", MySqlDbType.Int64);
                    param[3].Value = Id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteMessages", param);

                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {
                    response.Data = "";
                    response.Message = "Message Deleted Successful !!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }


        public Response EditMessages(userapp_chat_Id_messages obj_userapp_chat_Id_messages)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[5];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_id", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_chat_Id_messages.id;

                    param[1] = new MySqlParameter("p_message_timestamp", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_chat_Id_messages.message_timestamp;

                    param[2] = new MySqlParameter("p_message", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_chat_Id_messages.message;

                    param[3] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[3].Value = obj_userapp_chat_Id_messages.cust_id;

                    param[4] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[4].Value = obj_userapp_chat_Id_messages.chat_id;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_EditMessage", param);
                }
                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {
                    response.Data = "";
                    response.Message = "Message Edited Successful !!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }

















        public Response MarkUnReadMessage(mark_unread_message obj_mark_unread_message)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[6];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_Cust_Id", MySqlDbType.VarChar);
                    param[0].Value = obj_mark_unread_message.cust_id;

                    param[1] = new MySqlParameter("p_Chat_Id", MySqlDbType.Int32);
                    param[1].Value = obj_mark_unread_message.chat_id;

                    param[2] = new MySqlParameter("p_User_Id", MySqlDbType.Int32);
                    param[2].Value = obj_mark_unread_message.user_id;

                    param[3] = new MySqlParameter("p_Message_Timestamp", MySqlDbType.VarChar);
                    param[3].Value = obj_mark_unread_message.message_timestamp;

                    param[4] = new MySqlParameter("p_Count_Status", MySqlDbType.Bool);
                    param[4].Value = obj_mark_unread_message.count_status;

                    param[5] = new MySqlParameter("p_Read_Status", MySqlDbType.Bool);
                    param[5].Value = obj_mark_unread_message.read_status;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_MarkUnReadMessage", param);
                }
                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {
                    response.Data = "";
                    response.Message = "Mark UnReadMessage Successful !!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }



        public Response HideMessage(userapp_chat_Id_messages obj_userapp_chat_Id_messages)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[4];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_Cust_Id", MySqlDbType.VarChar);
                    param[0].Value = obj_userapp_chat_Id_messages.cust_id;

                    param[1] = new MySqlParameter("p_Chat_Id", MySqlDbType.Int32);
                    param[1].Value = obj_userapp_chat_Id_messages.chat_id;
      
                    param[2] = new MySqlParameter("p_Message_Timestamp", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_chat_Id_messages.message_timestamp;

                    param[3] = new MySqlParameter("p_Message_Hide_Status", MySqlDbType.Bool);
                    param[3].Value = obj_userapp_chat_Id_messages.message_hide_status;

             
                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_HideMessage", param);
                }
                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {
                    response.Data = "";
                    response.Message = "HideMessage Successful !!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }















    }
}




