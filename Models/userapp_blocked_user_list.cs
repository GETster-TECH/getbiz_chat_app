using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class userapp_blocked_user_list
    {
        public int user_id { get; set; }
        public int chat_id { get; set; }
        public string blocked_timestamp { get; set; }
        public string cust_id { get; set; }
        public bool user_blocked_status { get; set; }
    }
}
