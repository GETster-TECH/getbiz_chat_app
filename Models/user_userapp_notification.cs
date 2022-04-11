using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class user_userapp_notification
    {
        public bool mute_all_chat_notifications { get; set; }
        public bool mute_pings_from_all_users { get; set; }
        public string cust_id { get; set; }
       // public int chat_id { get; set; }
        public int user_id { get; set; }
    }
}
