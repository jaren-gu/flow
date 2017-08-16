using MySql.Data.MySqlClient;
using System;

namespace FlowServer.Helper
{
    /// <summary>
    /// 进行连接MySql的工具类
    /// </summary>
    public class MySqlDbHelper : IDisposable
    {
        public readonly MySqlConnection Connection;

        public MySqlDbHelper()
        {
            string mysql = ConfigHelper.GetValue("MySql");
            Connection = new MySqlConnection(mysql);
            Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}