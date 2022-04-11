using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class custom_member_permissions_for_user_id
    {
        public int user_list_id { get; set; }
        public bool add_Invite_group_members { set; get; }
        public bool delete_group_members { set; get; }
        public bool send_messages { set; get; }
        public bool reply_to_messages { set; get; }

        public int edit_messages_sent_by_himself_herself_within_minutes { set; get; }
        public int delete_messages_sent_by_himself_herself_within_minutes { set; get; }
        public int hide_messages_sent_by_himself_herself_within_minutes { set; get; }


        public bool edit_messages_sent_by_himself_herself { set; get; }
        public bool delete_messages_sent_by_himself_herself { set; get; }
        public bool hide_messages_sent_by_himself_herself { set; get; }

        public bool hide_messages_of_other_users { set; get; }
        public bool pin_messages_to_the_top_of_chat_window { set; get; }
        public bool ping_messages  { set; get; }
        public bool forward_share_messages { set; get; }
        public bool export_chat { set; get; }
        public bool copy_message_text { set; get; }

        public int limit_access_to_chat_messages_from_last_no_of_days { set; get; }


        public bool limit_access_to_chat_messages_from{ set; get; }
        public string cust_id { set; get; }
        public int chat_id { set; get; }
 
       
    }
}
