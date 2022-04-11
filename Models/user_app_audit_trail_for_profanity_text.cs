using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class user_app_audit_trail_for_profanity_text
    {
         
        public  string language { get;set;}
        public  string text_word_words { get;set;}
        public int entry_by_user_id { get;set;}
        public string entry_type { get;set;}
        public string cust_id { get; set; }

     
    }
}
