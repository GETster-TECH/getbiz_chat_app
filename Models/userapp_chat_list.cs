using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class userapp_chat_list
    {
        public int chat_id { get; set; }
        public int pin_to_top_of_list_no { get; set; }

       
        public string number_of_unread_messages { get; set; }
     
        public string mute_notifications_from_this_chat { get; set; }
        public string user_blocked_status { get; set; }
        public string cust_id { get; set; }
        public int user_id { get; set; }
    }
}
