using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.V_Models
{
    public class users_chat_list_common_class
    {


        // 11_user_6_userapp_chats_list

        public int chat_id { get; set; }
        public bool received_user_blocked_status { get; set; }

        public int pin_to_top_of_list_no { get; set; }        
        public bool number_of_unread_messages { get; set; }         
        public bool mute_notifications_from_this_chat { get; set; }     
        public bool user_blocked_status { get; set; }                         



        // userapp_chat_master


        public string group_chat_name { get; set; }
        public int chat_type { get; set; }
        public int created_by_user_id { get; set; }
        public string created_timestamp { get; set; }
        public int auto_delete_old_messages_no_of_days { get; set; }
        public string auto_delete_old_messages { get; set; }
        public string about_the_chat { get; set; }

        public string businesses_associated_with_this_group { get; set; }
        public string pin_chat_to_the_top_of_chat_list { get; set; }
        public string pin_message_timestamp { get; set; }
        public string user_profile { get; set; }


        // userapp_128_chat_id_users_list

        // public int sender_user_id { set; get; }
         public int received_user_id { set; get; }
 


        public string user_added_utc_timestamp { set; get; }
        public string user_removed_utc_timestamp { set; get; }
        public int user_permissions_category { set; get; }
        public string user_name { set; get; }

        //6_userapp_128_chat_id_messages

        public int Id { set; get; }
        public string last_message_by_user_id { set; get; }




       // 11_user_6_userapp_read_unread_status


        public int unread_message_count { set; get; }




        // last msg by use_id and his detsila
        public string send_last_msg_user_name { set; get; }

        public string send_last_msg_his_photo_id { set; get; }
    
        public string send_last_msg_his_designation { set; get; }
        public string last_message_timestamp { set; get; }
  






    }
}
