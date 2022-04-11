using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class userapp_chat_Id_messages
    {

        public int id { set; get; }
        public string message_timestamp { set; get; }
        public string message { set; get; }
        public int sent_by_user_id { set; get; }
        public string reply_to_message_timestamp { set; get; }
        public string cust_id { set; get; }
        public int chat_id { set; get; }
        public List<IFormFile> choose_attachment_file { set; get; }
        public string attachment_file { set; get; }
        public string image_source { set; get; }
        public string photo_name { set; get; }


        public bool message_hide_status { set; get; }
        public bool message_edit_status { set; get; }

    }


 
}
