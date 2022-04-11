using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class group_member_users_permissions
    {
        public int  user_list_id { get; set; }
        public bool add_group_members { get; set; }
        public bool delete_group_members { get; set; }
        public bool send_messages { get; set; }
        public bool reply_to_messages { get; set; }

        public int edit_messages_sent_by_himself_herself_within_minutes { get; set; }
        public int delete_messages_sent_by_himself_herself_within_minutes { get; set; }
        public int hide_messages_sent_by_himself_herself_within_minutes { get; set; }


        public bool edit_messages_sent_by_himself_herself { get; set; }
        public bool delete_messages_sent_by_himself_herself { get; set; }
        public bool hide_messages_sent_by_himself_herself { get; set; }

        public bool hide_messages_of_other_users { get; set; }
        public bool pin_messages_to_the_top_of_chat_window { get; set; }
        public bool ping_messages { get; set; }
        public bool forward_share_messages { get; set; }
        public bool export_chat { get; set; }
        public bool copy_message_text { get; set; }

        public int limit_access_to_chat_messages_from_last_no_of_days { get; set; }
        public bool limit_access_to_chat_messages_from { get; set; }
        public string cust_id { get; set; }
        public int chat_id { get; set; }

    }
}
