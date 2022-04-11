using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class userapp_saved_messages
    {
        public Int64 chat_id { get; set; }
        public string message_timestamp { get; set; }
        public string message { get; set; }
        public string saved_timestamp { get; set; }
        public int user_id { get; set; }
        public string cust_id { get; set; }
    
    }
}
