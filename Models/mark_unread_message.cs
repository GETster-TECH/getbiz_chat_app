using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class mark_unread_message
    {


        public string cust_id { set; get; }
        public int chat_id { set; get; }
        public int user_id { set; get; }
        public string message_timestamp { set; get; }
        public bool count_status { set; get; }
        public bool read_status { set; get; }

    }
}
