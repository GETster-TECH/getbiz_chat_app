using ClosedXML.Excel;
using getbiz_chat_app.Getbiz_DbContext;
using getbiz_chat_app.Models;
using getbiz_chat_app.Repository.Chat_Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace getbiz_chat_app.Controllers
{
    [ApiController]
    public class UserAppChatIdMessagesController : ControllerBase
    {
        private IUserAppChatIdMessagesRepository _chatMessagesRepository;

        public UserAppChatIdMessagesController(IUserAppChatIdMessagesRepository chatMessagesRepository)
        {
            _chatMessagesRepository = chatMessagesRepository;
        }


        [HttpPost]
        [Route("api/AddUserAppChatIdMessages")]
        public async Task<IActionResult> AddUserAppChatIdMessagesAsync([FromForm] userapp_chat_Id_messages obj_chat_messages)
        {
            try
            {
                userapp_chat_Id_messages mainobj = new userapp_chat_Id_messages();

                if (obj_chat_messages.choose_attachment_file != null && obj_chat_messages.image_source == null)
                {
                    var Custidpath = "C:\\GetbizAPPAPIProduction\\broadcast-chat-app\\chat_attachment_files\\" + obj_chat_messages.cust_id;
                    //  var Custidpath = "D:\\.NetProjects\\getbiz_chat_app\\getbiz_chat_app\\chat_attachment_files\\" + obj_chat_messages.cust_id;
                    if (obj_chat_messages.choose_attachment_file != null)
                    {
                        if (!(Directory.Exists(Custidpath)))
                        {
                            Directory.CreateDirectory(Custidpath);

                            var UserIdpath = "C:\\GetbizAPPAPIProduction\\broadcast-chat-app\\chat_attachment_files\\" + obj_chat_messages.cust_id + "\\" + obj_chat_messages.chat_id;
                            //  var UserIdpath = "D:\\.NetProjects\\getbiz_chat_app\\getbiz_chat_app\\chat_attachment_files\\" + obj_chat_messages.cust_id + "\\" + obj_chat_messages.sent_by_user_id;
                            if (!(Directory.Exists(UserIdpath)))
                            {
                                Directory.CreateDirectory(UserIdpath);

                                string filename = string.Empty;
                                obj_chat_messages.choose_attachment_file.ForEach(async file =>
                                {
                                    if (file.Length <= 0) return;
                                    mainobj.attachment_file = file.FileName;
                                    //filename += file.FileName + ",";
                                    filename = filename + '"' + file.FileName + '"' + ',';

                                    var filePath = Path.Combine(UserIdpath, file.FileName);
                                    using (var stream = new FileStream(filePath, FileMode.Create))
                                    {
                                        await file.CopyToAsync(stream);
                                    }
                                });
                                mainobj.attachment_file = filename;
                            }
                        }
                        else
                        {

                            var UserIdpath = "C:\\GetbizAPPAPIProduction\\broadcast-chat-app\\chat_attachment_files\\" + obj_chat_messages.cust_id + "\\" + obj_chat_messages.chat_id;
                            // var UserIdpath = "D:\\.NetProjects\\getbiz_chat_app\\getbiz_chat_app\\chat_attachment_files\\" + obj_chat_messages.cust_id + "\\" + obj_chat_messages.sent_by_user_id;

                            Directory.CreateDirectory(UserIdpath);
                            string filename = string.Empty;
                            obj_chat_messages.choose_attachment_file.ForEach(async file =>
                            {
                                if (file.Length <= 0) return;
                                mainobj.attachment_file = file.FileName;
                                //filename += file.FileName + ",";
                                filename = filename + '"' + file.FileName + '"' + ',';

                                var filePath = Path.Combine(UserIdpath, file.FileName);
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await file.CopyToAsync(stream);
                                }
                            });
                            mainobj.attachment_file = filename;
                        }
                    }
                }





                else if (obj_chat_messages.choose_attachment_file == null && obj_chat_messages.image_source != null)
                {
                    var Custidpath = "C:\\GetbizAPPAPIProduction\\broadcast-chat-app\\chat_attachment_files\\" + obj_chat_messages.cust_id;

                    if (!(Directory.Exists(Custidpath)))
                    {
                        Directory.CreateDirectory(Custidpath);

                        var UserIdpath = "C:\\GetbizAPPAPIProduction\\broadcast-chat-app\\chat_attachment_files\\" + obj_chat_messages.cust_id + "\\" + obj_chat_messages.chat_id;

                        if (!(Directory.Exists(UserIdpath)))
                        {
                            byte[] imageBytes = Convert.FromBase64String(obj_chat_messages.image_source);
                            string file_name = obj_chat_messages.photo_name;

                            Directory.CreateDirectory(UserIdpath);
                            var filePath = Path.Combine(UserIdpath, file_name);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);


                            mainobj.attachment_file = file_name; // assign filename
                        }
                        else
                        {
                            byte[] imageBytes = Convert.FromBase64String(obj_chat_messages.image_source);
                            string file_name = obj_chat_messages.photo_name;

                            Directory.CreateDirectory(UserIdpath);
                            var filePath = Path.Combine(UserIdpath, file_name);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);

                            mainobj.attachment_file = file_name; // assign filename
                        }
                    }
                    else
                    {
                        var UserIdpath = "C:\\GetbizAPPAPIProduction\\broadcast-chat-app\\chat_attachment_files\\" + obj_chat_messages.cust_id + "\\" + obj_chat_messages.chat_id;

                        if (!(Directory.Exists(UserIdpath)))
                        {
                            byte[] imageBytes = Convert.FromBase64String(obj_chat_messages.image_source);
                            string file_name = obj_chat_messages.photo_name;

                            Directory.CreateDirectory(UserIdpath);
                            var filePath = Path.Combine(UserIdpath, file_name);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);


                            mainobj.attachment_file = file_name; // assign filename
                        }
                        else
                        {
                            byte[] imageBytes = Convert.FromBase64String(obj_chat_messages.image_source);
                            string file_name = obj_chat_messages.photo_name + ".jpg";

                            Directory.CreateDirectory(UserIdpath);
                            var filePath = Path.Combine(UserIdpath, file_name);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);
                            mainobj.attachment_file = file_name; // assign filename
                        }
                    }

                }


                var messages = _chatMessagesRepository.AddUserAppChatIdMessages(obj_chat_messages, mainobj);
                if (messages == null)
                {
                    return NotFound();
                }
                return Ok(messages);


            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("api/GetAllUserAppChatIdMessages")]

        public Response GetAllUserAppChatIdMessages(string CustId, Int64 ChatId, Int64 UserId, Int64 PageNo, Int64 PageSize, Boolean ChatType)
        {

            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();

                var messages = Obj_getsetdb.GetAllUserAppChatIdMessages(CustId, ChatId, UserId, PageNo, PageSize, ChatType);
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
                response.Data = messages;
            }

            catch (Exception ex)
            {

            }
            return response;
        }


        [HttpDelete]
        [Route("api/DeleteMessage")]

        public IActionResult DeleteMessages(string Cust_Id, Int64 Chat_Id, string Message_Timestamp, int Id)
        {

            try
            {
                var messages = _chatMessagesRepository.DeleteMessages( Cust_Id,  Chat_Id,  Message_Timestamp,  Id);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }

            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/EditMessage")]
        public IActionResult EditMessages(userapp_chat_Id_messages obj_userapp_chat_Id_messages)
        {
            try
            {
                var messages = _chatMessagesRepository.EditMessages(obj_userapp_chat_Id_messages);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }

            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/MarkUnReadMessage")]

        public IActionResult MarkUnReadMessage(mark_unread_message obj_mark_unread_message)
        {
            try
            {
                var messages = _chatMessagesRepository.MarkUnReadMessage( obj_mark_unread_message);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }

            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/HideMessage")]
        public IActionResult HideMessage(userapp_chat_Id_messages obj_userapp_chat_Id_messages)
        {
            try
            {
                var messages = _chatMessagesRepository.HideMessage(obj_userapp_chat_Id_messages);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }

            catch (Exception ex)
            {
                return BadRequest();
            }
        }



         [HttpGet]
        [Route("api/GetSearchChatMessages")]
        public IActionResult GetSearchChatMessages(string SearchMessage, string CustId, Int64 ChatId)
        {
            try
            {
                var messages = _chatMessagesRepository.GetSearchChatMessages(SearchMessage, CustId, ChatId);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }

            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("api/AddUserAppChatIdReplayMessages")]
        public async Task<IActionResult> AddUserAppChatIdReplayMessages([FromForm] userapp_chat_Id_messages obj_chat_messages)
        {
            try

            {
                userapp_chat_Id_messages mainobj = new userapp_chat_Id_messages();

                var Custidpath = "C:\\GetbizAPPAPIProduction\\broadcast-chat-app\\chat_attachment_files\\" + obj_chat_messages.cust_id;
                //var Custidpath = "E:\\.NetProjects\\getbiz_chat_app\\getbiz_chat_app\\chat_attachment_files\\" + obj_chat_messages.cust_id;

                if (obj_chat_messages.choose_attachment_file != null)
                {
                    if (!(Directory.Exists(Custidpath)))
                    {

                        Directory.CreateDirectory(Custidpath);

                        var UserIdpath = "C:\\GetbizAPPAPIProduction\\broadcast-chat-app\\chat_attachment_files\\" + obj_chat_messages.cust_id + "\\" + obj_chat_messages.sent_by_user_id;
                        //  var UserIdpath = "E:\\.NetProjects\\getbiz_chat_app\\getbiz_chat_app\\chat_attachment_files\\" + obj_chat_messages.cust_id + "\\" + obj_chat_messages.sent_by_user_id;
                        if (!(Directory.Exists(UserIdpath)))
                        {
                            Directory.CreateDirectory(UserIdpath);

                            string filename = string.Empty;
                            obj_chat_messages.choose_attachment_file.ForEach(async file =>
                            {
                                if (file.Length <= 0) return;
                                mainobj.attachment_file = file.FileName;
                                //filename += file.FileName + ",";
                                filename = filename + '"' + file.FileName + '"' + ',';


                                var filePath = Path.Combine(UserIdpath, file.FileName);
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await file.CopyToAsync(stream);
                                }

                            });
                            mainobj.attachment_file = filename;

                        }

                    }
                    else
                    {
                        var UserIdpath = "C:\\GetbizAPPAPIProduction\\broadcast-chat-app\\chat_attachment_files\\" + obj_chat_messages.cust_id + "\\" + obj_chat_messages.sent_by_user_id;
                        // var UserIdpath = "E:\\.NetProjects\\getbiz_chat_app\\getbiz_chat_app\\chat_attachment_files\\" + obj_chat_messages.cust_id + "\\" + obj_chat_messages.sent_by_user_id;
                        if ((Directory.Exists(UserIdpath)))
                        {
                            Directory.CreateDirectory(UserIdpath);


                            string filename = string.Empty;

                            obj_chat_messages.choose_attachment_file.ForEach(async file =>
                            {
                                if (file.Length <= 0) return;
                                mainobj.attachment_file = file.FileName;
                                //filename += file.FileName + ",";
                                filename = filename + '"' + file.FileName + '"' + ',';


                                var filePath = Path.Combine(UserIdpath, file.FileName);
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await file.CopyToAsync(stream);
                                }
                            });
                            mainobj.attachment_file = filename;
                        }

                    }

                }
                var messages = _chatMessagesRepository.AddUserAppChatIdReplayMessages(obj_chat_messages, mainobj);
                if (messages == null)
                {
                    return NotFound();
                }
                return Ok(messages);


            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }










        [HttpGet]
        [Route("api/ExportChatIdMessages")]
        public FileContentResult ExportChatIdMessages(string CustId, Int64 ChatId)
        {
            string connection = "Server=185.252.235.20;User ID=root;Password=GetBizMysqlDatabasePwd2021@;Database=chatbroadcastappdb; Allow User Variables=true";

            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_chat_id", MySqlDbType.Int64);
                    param[1].Value = ChatId;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_ExportChatIdMessages", param);
                }
            }
            catch (Exception ex)
            {

            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(ds);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }
   }


















    //static table data's export code
    //[HttpGet]
    //[Route("api/GetAdapterassembliesshperical")]
    //public IActionResult Export()
    //{
    //    try
    //    {
    //        using (XLWorkbook wb = new XLWorkbook())
    //        {
    //            DataTable dt = GetCustomers().Tables[0];
    //            wb.Worksheets.Add(dt);
    //            using (MemoryStream stream = new MemoryStream())
    //            {
    //                wb.SaveAs(stream);
    //                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
    //            }
    //        }

    //        DataSet GetCustomers()
    //        {
    //            DataSet ds = new DataSet();
    //            string connection = "Server=localhost;User ID=root;Password=mysql;Database=chatbroadcastappdb; Allow User Variables=true";

    //            using (MySqlConnection con = new MySqlConnection(connection))
    //            {
    //                string query = "SELECT * FROM bearingcatalogdb.adapterassembliesshperical;";
    //                using (MySqlCommand cmd = new MySqlCommand(query))
    //                {
    //                    cmd.Connection = con;
    //                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
    //                    {
    //                        sda.Fill(ds);
    //                    }
    //                }
    //            }

    //            return ds;
    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest();
    //    }
    //}






   








}


       






  
