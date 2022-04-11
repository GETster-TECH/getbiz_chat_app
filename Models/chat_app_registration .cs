using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class chat_app_registration
    {
        [Key]
      
        public int user_id { get; set; } 
        public string cust_id { get; set; } 
        public string user_name { get; set; } 
        public string company_name { get; set; }
        public string designation { get; set; } 
        public string mobile_no { get; set; } 
        public string country_code { get; set; } 
        public string user_blogs { get; set; }
        public string email_id { get; set; }
        public string address { get; set; }
        public string about { get; set; }
        public string share_link { get; set; }
        public string photo_id { get; set; }

    }
}
