using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class userapp_chat_id_users_list
    {
        public string user_added_timestamp { get; set; }
        public string user_removed_timestamp { get; set; }
        public int user_id { get; set; }
        public int user_permissions_category { get; set; }

        public string cust_id { get; set; }
        public int chat_id { get; set; }
    }
}
