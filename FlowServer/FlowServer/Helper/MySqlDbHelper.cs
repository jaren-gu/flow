using MySql.Data.MySqlClient;
using System;

namespace FlowServer.Helper
{
    public class MySqlDbHelper : IDisposable
    {
        public readonly MySqlConnection Connection;

        public MySqlDbHelper()
        {
            string mysql = ConfigHelper.GetValue("MySql");

            Connection = new MySqlConnection(mysql);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}