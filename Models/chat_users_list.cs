using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class chat_users_list
    {
        [Key]
        public int user_id { get; set; }
        public DateTime user_added_timestamp { get; set; }
        public DateTime user_removed_timestamp { get; set; }
        public Int64 user_permissions_category { get; set; }
        public string p_userId { get; set; }

    }
}


