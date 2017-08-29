using FlowServer.Helper;
using MySql.Data.MySqlClient;

namespace FlowServer.Model
{
    public class Flow_Log
    {
        private int _id;
        private string _msg;
        private int _logType;
        private string _stackInfoMsg;
        private string _exceptionMsg;

        public int Id { get => _id; set => _id = value; }
        public string Msg { get => _msg; set => _msg = value; }
        public int LogType { get => _logType; set => _logType = value; }
        public string StackInfoMsg { get => _stackInfoMsg; set => _stackInfoMsg = value; }
        public string ExceptionMsg { get => _exceptionMsg; set => _exceptionMsg = value; }

        public Flow_Log(string msg, int logType, string stackInfoMsg, string exceptionMsg)
        {
            _msg = msg;
            _logType = logType;
            _stackInfoMsg = stackInfoMsg;
            _exceptionMsg = exceptionMsg;
        }

        public void Save()
        {
            using (var mysqlDb = new MySqlDbHelper())
            {
                var cmd = mysqlDb.Connection.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO Flow_Log (Msg,LogType,StackInfoMsg,ExceptionMsg) VALUES (@msg,@LogType,@stackInfoMsg,@exceptionMsg);";
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@msg", DbType = System.Data.DbType.String, Value = Msg });
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@LogType", DbType = System.Data.DbType.Int32, Value = LogType });
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@stackInfoMsg", DbType = System.Data.DbType.String, Value = StackInfoMsg });
                cmd.Parameters.Add(new MySqlParameter { ParameterName = "@exceptionMsg", DbType = System.Data.DbType.String, Value = ExceptionMsg });
                cmd.ExecuteNonQueryAsync();
            }
        }
    }
}