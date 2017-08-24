using FlowServer.Helper;
using FlowServer.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FlowServer.Controllers
{
    public class BlogController : Controller
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public async Task<JArray> Select()
        {
            using (var mysqlDb = new MySqlDbHelper())
            {
                var cmd = mysqlDb.Connection.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"select * from BlogPost";
                var result = await cmd.ExecuteReaderAsync();
                var posts = new List<Blog>();
                using (result)
                {
                    while (await result.ReadAsync())
                    {
                        var post = new Blog()
                        {
                            Id = await result.GetFieldValueAsync<int>(0),
                            Title = await result.GetFieldValueAsync<string>(1),
                            Content = await result.GetFieldValueAsync<string>(2)
                        };
                        posts.Add(post);
                    }
                }
                return JArray.Parse(JsonConvert.SerializeObject(posts));
            }
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <returns></returns>
        public async Task<string> Insert()
        {
            Stream stream = HttpContext.Request.Body;
            byte[] buffer = new byte[HttpContext.Request.ContentLength.Value];
            stream.Read(buffer, 0, buffer.Length);
            string requestStr = Encoding.UTF8.GetString(buffer);
            LogHelper.GetLogHelper().Info("接收到的数据：" + requestStr);
            JObject json = JObject.Parse(requestStr);
            using (var mysqlDb = new MySqlDbHelper())
            {
                var cmd = mysqlDb.Connection.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO BlogPost (Title,Content) VALUES (@title,@content);";
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@title", DbType = System.Data.DbType.String, Value = json["Title"].ToString() });
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@content", DbType = System.Data.DbType.String, Value = json["Content"].ToString() });
                int count = await cmd.ExecuteNonQueryAsync();
                JObject j = new JObject();
                j.Add("Count", count);
                LogHelper.GetLogHelper().Info("成功插入数据！！");
                return j.ToString();
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        public async Task<string> Update()
        {
            Stream stream = HttpContext.Request.Body;
            byte[] buffer = new byte[HttpContext.Request.ContentLength.Value];
            stream.Read(buffer, 0, buffer.Length);
            string requestStr = Encoding.UTF8.GetString(buffer);
            LogHelper.GetLogHelper().Info("接收到的数据：" + requestStr);
            JObject json = JObject.Parse(requestStr);
            using (var mysqlDb = new MySqlDbHelper())
            {
                var cmd = mysqlDb.Connection.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"UPDATE BlogPost SET Content=@content WHERE Title=@title;";
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@content", DbType = System.Data.DbType.String, Value = json["Content"].ToString() });
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@title", DbType = System.Data.DbType.String, Value = json["Title"].ToString() });
                int count = await cmd.ExecuteNonQueryAsync();
                JObject j = new JObject();
                j.Add("Count", count);
                LogHelper.GetLogHelper().Info("成功更新数据！！！");
                return j.ToString();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public async Task<string> Delete()
        {
            Stream stream = HttpContext.Request.Body;
            byte[] buffer = new byte[HttpContext.Request.ContentLength.Value];
            stream.Read(buffer, 0, buffer.Length);
            string requestStr = Encoding.UTF8.GetString(buffer);
            LogHelper.GetLogHelper().Info("接收到的数据：" + requestStr);
            JObject json = JObject.Parse(requestStr);
            using (var mysqlDb = new MySqlDbHelper())
            {
                var cmd = mysqlDb.Connection.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"DELETE FROM BlogPost WHERE Title=@title;";
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@title", DbType = System.Data.DbType.String, Value = json["Title"].ToString() });
                int count = await cmd.ExecuteNonQueryAsync();
                JObject j = new JObject();
                j.Add("Count", count);
                LogHelper.GetLogHelper().Info("成功删除数据！！");
                return j.ToString();
            }
        }
    }
}