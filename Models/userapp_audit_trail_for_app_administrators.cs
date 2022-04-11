using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Models
{
    public class userapp_audit_trail_for_app_administrators
    {
        public int chat_id { get; set; }
        public string entry_type { get; set; }
        public int entry_by_user_id { get; set; }
        public string entry_timestamp { get; set; }
    }
}
