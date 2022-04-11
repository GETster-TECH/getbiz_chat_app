using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class userapp_profanity_text
    {
        public int  Id { get; set; }
        public string language { get; set; }
        public string text_word_words { get; set; }
        public bool is_it_added_by_customer { get; set; }
        public bool is_it_unblocked { get; set; }

        public string cust_id { get; set; }
        public int user_id { get; set; }
        public string  entry_type { get; set; }
        


    }
}
