using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Repository.Admin_Users_Permissions;
using getbiz_chat_app.Repository.Chat_App_Registration;
using getbiz_chat_app.Repository.Chat_Broadcast_App_Dynamic_Db;
using getbiz_chat_app.Repository.Chat_Master_Dynamic_Db;
using getbiz_chat_app.Repository.Chat_Messages;

using getbiz_chat_app.Repository.Custom_Member_Permissions_For_User_Id;
using getbiz_chat_app.Repository.Group_Member_Users_Permissions;
using getbiz_chat_app.Repository.User_profiles;
using getbiz_chat_app.Repository.User_Userapp_Notification;
using getbiz_chat_app.Repository.Userapp_Audit_Trail_For_App_Administrators;
using getbiz_chat_app.Repository.Userapp_Audit_Trail_For_Profanity_Text;
using getbiz_chat_app.Repository.Userapp_Chat_Id_Users_List;
using getbiz_chat_app.Repository.Userapp_Chat_List;
using getbiz_chat_app.Repository.Userapp_Group_Info;
using getbiz_chat_app.Repository.Userapp_Profanity_Text;
using getbiz_chat_app.Repository.Userapp_Read_Unread_Status;
using getbiz_chat_app.Repository.Userapp_Saved_Messages;

using getbiz_chat_app.Repository.Users_Userapp_Blocked_User_List;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_chat_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<ChatBroadCastAppDB_DbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "getbiz_chat_broadcast_app", Version = "v1" });
            });


            services.AddScoped<IChatAppDynamicDbRepository, ChatAppDynamicDbRepository>();
            services.AddScoped<IUserAppChatMasterRepository, UserAppChatMasterRepository>();
   

            services.AddScoped<IUserAppChatIdMessagesRepository, UserAppChatIdMessagesRepository>();

            services.AddScoped<IChatIdAdminUsersPermissionsRepository, ChatIdAdminUsersPermissionsRepository>();
            services.AddScoped<IGroupMemberUsersPermissionsRepository, GroupMemberUsersPermissionsRepository>();
            services.AddScoped<ICustomMemberPermissionsForUserIdRepository, CustomMemberPermissionsForUserIdRepository>();
            services.AddScoped<IUserAppChatListRepository, UserAppChatListRepository>();
            services.AddScoped<IUsersUserAppBlockedUserListRepository, UsersUserAppBlockedUserListRepository>();
            services.AddScoped<IUserAppSavedMessagesRepository, UserAppSavedMessagesRepository>();
            services.AddScoped<IUserAppAuditTrailForAppAdministratorsRepository, UserAppAuditTrailForAppAdministratorsRepository>();
            services.AddScoped<IUserUserAppNotificationRepository, UserUserAppNotificationRepository>();
            services.AddScoped<IUserAppChatIdUsersListRepository, UserAppChatIdUsersListRepository>();
            services.AddScoped<IUserProfilesRepository, UserProfilesRepository>();
            services.AddScoped<IUserAppGroupMemberByIdRepository, UserAppGroupMemberByIdRepository>();
            services.AddScoped<IUserAppReadUnreadStatusRepository, UserAppReadUnreadStatusRepository>();
            services.AddScoped<IChatAppRegistrationRepository, ChatAppRegistrationRepository>();
            services.AddScoped<IUserAppAuditTtrailForProfanityTextRepository, UserAppAuditTtrailForProfanityTextRepository>();
            services.AddScoped<IUserappProfanityTextRepository, UserappProfanityTextRepository>();


            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });


            services.AddCors(option => option.AddPolicy("getbiz_chat_broadcast_app", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "getbiz_chat_broadcast_app v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true)
              .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
