using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.V_Models
{
    public class users_and_groups_profiles_common_class
    {

        public int chat_id { set; get; }
        public string group_chat_name { set; get; }
        public int chat_type { set; get; }   // chat bool to int
        public int created_by_user_id { set; get; }
        public string created_timestamp { set; get; }
        public int auto_delete_old_messages_no_of_days { set; get; }
        public int auto_delete_old_messages { set; get; }
        public string about_the_chat { set; get; }
        public string businesses_associated_with_this_group { set; get; }
        public string pin_chat_to_the_top_of_chat_list { set; get; }
        public string pin_message_timestamp { set; get; }
        public string user_profile { set; get; }


        // 
        public int chat_members { set; get; }
        public int receiver_user_id { set; get; }
        public int sender_user_permissions_category { set; get; }

        //
        public int receiver_pin_to_top_of_list_no { set; get; }
        public bool receiver_number_of_unread_messages { set; get; }
        public bool receiver_mute_notifications_from_this_chat { set; get; }
        public bool receiver_user_blocked_status { set; get; }
        public string receiver_user_name { set; get; }

        //

        public int pin_to_top_of_list_no { set; get; }
        public bool number_of_unread_messages { set; get; }
        public bool mute_notifications_from_this_chat { set; get; }
        public bool user_blocked_status { set; get; }
        public string user_name { set; get; }

        // //////////////////////////////////////////////////////////////

        public Object user_permissions { set; get; }
    }
}
