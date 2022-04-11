using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.V_Models
{
    public class message_view_details_common_class
    {

        public int Id { set; get; }
        public string message_timestamp { set; get; }
        public string message { set; get; }
        public int sent_by_user_id { set; get; }
        public string reply_to_message_timestamp { set; get; }
        public string attachment_file { set; get; }
        public bool message_hide_status { set; get; }
        public bool message_edit_status { set; get; }

        public string user_name { set; get; }                 
        public string designation { set; get; }
        public string company_name { set; get; }
        public string photo_id { set; get; }
        public JSON user_read_status { set; get; }

        public object user_message_read_status_and_read_count_status_Data { set; get; }




    }
}
