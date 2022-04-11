using getbiz_chat_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app.Getbiz_DbContext
{
    public class ChatBroadCastAppDB_DbContext : DbContext
    {
        public ChatBroadCastAppDB_DbContext(DbContextOptions<ChatBroadCastAppDB_DbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<chat_app_registration> chat_app_registrations { get; set; }
    }
}
